using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZanettiClod.AppCore.Interfaces.Data;
using ZanettiClod.AppCore.Interfaces.Services;
using ZanettiClod.Domain;

namespace ZanettiClod.AppCore.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.Delete(id);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAll();
        }

        public async Task InsertProduct(Product product)
        {
            await _productRepository.Insert(product);
        }
    }
}
