using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZanettiClod.Domain;

namespace ZanettiClod.AppCore.Interfaces.Data
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetAll();
        public Task Insert(Product product);
        public Task Delete(int id);
    }
}
