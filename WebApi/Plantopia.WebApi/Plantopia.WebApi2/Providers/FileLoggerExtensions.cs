using Microsoft.Extensions.Logging;

namespace Plantopia.WebApi2.Providers
{
    /// <summary>
    /// 
    /// </summary>
    public static class FileLoggerExtensions
    {
        public static ILoggerFactory AddFile(this ILoggerFactory factory,
            string filePath)
        {
            factory.AddProvider(new FileLoggerProvider(filePath));
            return factory;
        }

    }
}
