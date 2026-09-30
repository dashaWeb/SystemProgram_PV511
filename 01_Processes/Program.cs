using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        /*Process current = Process.GetCurrentProcess();
        current.PriorityClass = ProcessPriorityClass.High;


        Console.WriteLine(" ---------- Current proccess info --------");
        Console.WriteLine($" PriorityClass      : {current.PriorityClass}");
        Console.WriteLine($" ProcessName        : {current.ProcessName}");
        Console.WriteLine($" ID                 : {current.Id}");
        Console.WriteLine($" MachineName        : {current.MachineName}");
        Console.WriteLine($" PrivateMemory      : {current.PrivateMemorySize64}");
        Console.WriteLine($" StartTime          : {current.StartTime}");
        Console.WriteLine($" TotalProcessorTime : {current.TotalProcessorTime}");

        Console.ReadKey();
        Console.WriteLine($" TotalProcessorTime : {current.TotalProcessorTime}");*/

        //Process[] processes = Process.GetProcesses();

        //Console.WriteLine("Process Name\t\t\tPID\t\t\tPriority\tStart Time");
        //Console.WriteLine("-------------------------------------------------");
        //foreach (var p in processes)
        //{
        //    try
        //    {
        //        Console.WriteLine($"{p.ProcessName}\t{p.Id}\t{p.PriorityClass}\t{p.StartTime}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine($"Error with {p.ProcessName} ({ex.Message})");
        //        Console.ResetColor();

        //    }
        //}
        //Console.ReadKey();

        //Process.Start("mspaint.exe");
        //Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "stackoverflow.com github.com google.com");

        /*ProcessStartInfo info = new ProcessStartInfo()
        {
            FileName = "notepad",
            Arguments = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\777.txt",
            WindowStyle = ProcessWindowStyle.Normal
        };

        Process pr = Process.Start(info)!;*/
        Process pr = Process.Start("mspaint.exe");
        Console.WriteLine("Press key to do operation ....");
        //Console.ReadKey();

        //pr.Close();
        //pr.Refresh();
        //pr.CloseMainWindow(); // alt + F4

        Thread.Sleep(5000);
        pr.Kill(); 
        Console.WriteLine("Operation done .....");

        Console.ReadKey();
    }
}