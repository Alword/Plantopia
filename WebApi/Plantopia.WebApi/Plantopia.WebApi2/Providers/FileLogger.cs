using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace Plantopia.WebApi.Providers
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class FileLogger : ILogger
    {
        private readonly object _lock = new object();
        private readonly string filePath;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public FileLogger(string path)
        {
            filePath = path;
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <typeparam name="TState"></typeparam>
        /// <returns></returns>
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logLevel"></param>
        /// <returns></returns>
        public bool IsEnabled(LogLevel logLevel)
        {
            //return logLevel == LogLevel.Trace;
            return true;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="eventId"></param>
        /// <param name="state"></param>
        /// <param name="exception"></param>
        /// <param name="formatter"></param>
        /// <typeparam name="TState"></typeparam>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            if (formatter == null) return;
            lock (_lock)
            {
                File.AppendAllText(filePath, formatter(state, exception) + Environment.NewLine);
            }
        }
    }
}