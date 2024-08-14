using System;

public class Logger
{
    // Static instance of the Logger class
    private static Logger _instance;

    // Private constructor to prevent instantiation
    private Logger()
    {
        Console.WriteLine("Logger is Instantiated.");
    }

    // Public method to get the instance of Logger
    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Logger();
        }
        return _instance;
    }

    // Method to log a message
    public void LogMessage(string message)
    {
        Console.WriteLine($"Log: {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Logger logger = Logger.GetInstance();
        logger.LogMessage("This is a log message.");
    }
}
