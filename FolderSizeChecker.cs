using System;
using System.IO;
using System.Timers;

class Program
{
    private static Timer _timer;
    private static string _folderPath;

    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide the path of the folder as an argument.");
            Console.WriteLine("Usage: FolderSizeChecker.exe <folderPath> [intervalInSeconds]");
            return;
        }

        _folderPath = args[0];
        if (!Directory.Exists(_folderPath))
        {
            Console.WriteLine("The provided folder path does not exist: " + _folderPath);
            return;
        }

        int interval = 5; // default interval in seconds
        int providedInterval;
        if (args.Length > 1 && int.TryParse(args[1], out providedInterval))
        {
            interval = providedInterval;
        }

        _timer = new Timer(interval * 1000); // Convert to milliseconds
        _timer.Elapsed += OnTimedEvent;
        _timer.AutoReset = true;
        _timer.Enabled = true;

        Console.WriteLine("Press 'q' to quit the sample.");
        while (Console.Read() != 'q') ;
    }

    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        try
        {
            int fileCount;
            long sizeInBytes = GetDirectorySize(_folderPath, out fileCount);
            string humanReadableSize = BytesToString(sizeInBytes);
            Console.WriteLine("Folder Size: " + humanReadableSize + " - Number of Files: " + fileCount + " at " + DateTime.Now);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occurred: " + ex.Message);
        }
    }

    private static long GetDirectorySize(string folderPath, out int fileCount)
    {
        long size = 0;
        string[] fileNames = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);
        fileCount = fileNames.Length;

        foreach (string fileName in fileNames)
        {
            FileInfo info = new FileInfo(fileName);
            size += info.Length;
        }

        return size;
    }

    static string BytesToString(long byteCount)
    {
        string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; 
        if (byteCount == 0)
            return "0" + suf[0];
        long bytes = Math.Abs(byteCount);
        int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
        double num = Math.Round(bytes / Math.Pow(1024, place), 1);
        return (Math.Sign(byteCount) * num).ToString() + suf[place];
    }
}
