using Feetur.Application.Logging;
using Serilog.Events;

namespace Feetur.Infrastructure.Logging.Debug;

public class Log: ILog
{
    private readonly Func<LogLevel, LogEventLevel> _mapLogLevel = _ => LogEventLevel.Error;
    
    public async Task Write(string message, LogLevel logLevel)
        => await Task.Factory.StartNew(() => Serilog.Log.Write(_mapLogLevel(logLevel), message));

    public async Task Error(string message)
        => await Task.Factory.StartNew(() => Serilog.Log.Error(message));

    public async Task Error(string message, Exception exception)
        => await Task.Factory.StartNew(() => Serilog.Log.Error(exception, ""));
}