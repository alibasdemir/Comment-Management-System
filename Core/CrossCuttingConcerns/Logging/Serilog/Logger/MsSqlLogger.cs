using Microsoft.Extensions.Configuration;
using Serilog.Sinks.MSSqlServer;
using Serilog;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Logging.Serilog.Messages;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Logger
{
    public class MsSqlLogger : LoggerServiceBase
    {
        public MsSqlLogger(IConfiguration configuration)
        {
            MsSqlConfiguration logConfiguration =
            configuration.GetSection("SeriLogConfigurations:MsSqlConfiguration").Get<MsSqlConfiguration>()
            ?? throw new Exception(SerilogMessages.NullOptionsMessage);

            MSSqlServerSinkOptions sinkOptions =
                new() { TableName = logConfiguration.TableName, AutoCreateSqlTable = logConfiguration.AutoCreateSqlTable };

            ColumnOptions columnOptions = new();

            global::Serilog.Core.Logger serilogConfig = new LoggerConfiguration().WriteTo
                .MSSqlServer(logConfiguration.ConnectionString, sinkOptions, columnOptions: columnOptions)
                .CreateLogger();

            Logger = serilogConfig;
        }
    }
}
