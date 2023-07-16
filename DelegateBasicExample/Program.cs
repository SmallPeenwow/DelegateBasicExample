namespace DelegateBasicExample;

class Program
{
    delegate void LogDel(string text);

    static void Main(string[] args)
    {
        Log log = new Log();

        LogDel LogTextToScreenDel, LogTextToFileDel;

        LogTextToScreenDel = new LogDel(log.LogTextToScreen);
        LogTextToFileDel = new LogDel(log.LogTextToFile);

        LogDel multiLogDel = LogTextToScreenDel + LogTextToFileDel;

        //LogDel logDel = new LogDel(log.LogTextToScreen);
        //LogDel logDel = new LogDel(LogTextToFile);
        //LogDel logDel = new LogDel(LogTextToScreen);

        Console.WriteLine("Please enter your name");

        string? name = Console.ReadLine();

        if (name != null)
        {
            //logDel(name);
            //multiLogDel(name);
            LogText(multiLogDel, name);
            //LogText(LogTextToScreenDel, name);
        }

        Console.ReadKey();
    }

    static void LogText(LogDel logDel, string text)
    {
        logDel(text);
    }

    //static void LogTextToScreen(string text)
    //{
    //    Console.WriteLine($"{DateTime.Now}: {text}");
    //}

    //static void LogTextToFile(string text)
    //{
    //    using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
    //    {
    //        sw.WriteLine($"{DateTime.Now}: {text}");
    //    }
    //}  
}

public class Log
{
    public void LogTextToScreen(string text)
    {
        Console.WriteLine($"{DateTime.Now}: {text}");
    }

    public void LogTextToFile(string text)
    {
        using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
        {
            sw.WriteLine($"{DateTime.Now}: {text}");
        }
    }
}