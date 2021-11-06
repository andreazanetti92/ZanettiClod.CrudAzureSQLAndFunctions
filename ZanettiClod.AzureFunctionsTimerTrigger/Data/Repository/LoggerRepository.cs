using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZanettiClod.AzureFunctionsTimerTrigger.Data.Interfaces;
using ZanettiClod.AzureFunctionsTimerTrigger.Models;

namespace ZanettiClod.AzureFunctionsTimerTrigger.Data.Repository
{
    public class LoggerRepository : ILoggerRepository
    {
        private readonly string cs;
        private SqlConnection DB;

        public LoggerRepository(IConfiguration config)
        {
            cs = config.GetConnectionString("its-zanetti");
            DB = new SqlConnection(cs);
        }

        private async Task<int> GetProductCountAsync()
        {
            try
            {
                await DB.OpenAsync();

                const string queryCount = "SELECT COUNT(*) FROM Products";

                var count = await DB.QueryFirstOrDefaultAsync<int>(queryCount);

                return count;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                await DB.CloseAsync();
            }
        }

        public async Task GetProductCountAndWriteAsync()
        {
            try
            {
                await DB.OpenAsync();

                int count = await GetProductCountAsync();

                DateTime datetime = DateTime.UtcNow;

                string message = $"Logger: on {datetime} there was {count} Products";

                const string queryInsert = @"
                INSERT INTO [dbo].[Logger]
                       ([Date]
                       ,[Message])
                 VALUES
                       (@Date
                       ,@Message)";

                Logger logger = new Logger
                {
                    Date = datetime,
                    Message = message
                };

                await DB.ExecuteAsync(queryInsert, logger);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                await DB.CloseAsync();
            }
        }
    }
}
