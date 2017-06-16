using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

namespace OutputCapturer
{
    class OutputCapturerProgram
    {
        static void Main(string[] args)
        {
            string solutionPath = Path.GetFullPath(typeof(OutputCapturerProgram).GetTypeInfo().Assembly.Location + "../../../../../..");
            string assemblyPath = Path.GetFullPath(solutionPath + "/OutputGenerator/bin/Debug/netcoreapp1.1/OutputGenerator.dll");

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = $"\"{assemblyPath}\"",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
            };

            Process process = new Process { StartInfo = startInfo };

            process.OutputDataReceived += new DataReceivedEventHandler(
                (sender, eventArgs) =>
                {
                    if (eventArgs.Data != null)
                    {
                        Thread.Sleep(200);
                        Debug.WriteLine(eventArgs.Data);
                    }
                }
            );

            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit();
            process.Dispose();
        }
    }
}