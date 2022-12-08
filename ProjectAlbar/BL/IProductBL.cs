using System.Collections.Generic;
using System.Threading.Tasks;

using ProjectAlbar.Models;
namespace ProjectAlbar.BL
{
    public interface IProductBL
    {

        Task<List<Product>> getAllProduct();
        public Task<List<Product>> getProductByCategory(string Category);
        public Task<List<Product>> getProductByProductName(string ProductName);
        public Task<List<Product>> getProductByPrice(int Price);
        public Task<int> postProduct(Product product);
        public Task<Product> putProduct(Product product, int id);

    }
}
