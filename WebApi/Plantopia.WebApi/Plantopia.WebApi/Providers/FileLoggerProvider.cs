using Microsoft.Extensions.Logging;

namespace Plantopia.WebApi.Providers
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly string path;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public FileLoggerProvider(string path)
        {
            this.path = path;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(path);
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public void Dispose()
        {
        }
    }
}