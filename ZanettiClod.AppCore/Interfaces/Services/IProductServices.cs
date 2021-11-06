using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZanettiClod.Domain;

namespace ZanettiClod.AppCore.Interfaces.Services
{
    public interface IProductServices
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task InsertProduct(Product product);
        public Task DeleteProduct(int id);

    }
}
