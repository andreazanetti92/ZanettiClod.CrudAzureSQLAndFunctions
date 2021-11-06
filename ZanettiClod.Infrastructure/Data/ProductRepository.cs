using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZanettiClod.AppCore.Interfaces.Data;
using ZanettiClod.Domain;
using Dapper;

namespace ZanettiClod.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _cs;
        private SqlConnection DB;

        public ProductRepository(IConfiguration config)
        {
            _cs = config.GetConnectionString("its-zanetti");
            DB = new SqlConnection(_cs);
        }

        public async Task Delete(int id)
        {
            try
            {
                await DB.OpenAsync();

                const string queryDelete = @"DELETE FROM Products WHERE Id=@id";

                await DB.ExecuteAsync(queryDelete, new { id });
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

        public async Task<IEnumerable<Product>> GetAll()
        {
            try
            {
                await DB.OpenAsync();

                const string queryGetAll = "SELECT * FROM Products";

                var products = await DB.QueryAsync<Product>(queryGetAll);

                return products;
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

        public async Task Insert(Product product)
        {
            try
            {
                await DB.OpenAsync();

                const string queryInsert = 
                @"INSERT INTO [dbo].[Products]
                    ([Name]
                    ,[Code]
                    ,[Price]
                    ,[CategoryId])
                VALUES
                    (@Name
                    ,@Code
                    ,@Price
                    ,@CategoryId)";

                await DB.ExecuteAsync(queryInsert, product);
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
