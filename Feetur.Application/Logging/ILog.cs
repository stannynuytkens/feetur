namespace Feetur.Application.Logging;

public interface ILog
{
    Task Write(string message, LogLevel logLevel);
    
    Task Error(string message);
    Task Error(string message, Exception exception);
}