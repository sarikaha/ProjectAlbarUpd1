using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectAlbar.Models;
using ProjectAlbar.DL;

namespace ProjectAlbar.BL
{
    public class productBL : IProductBL
    {
        public IProductDL _IProductDL;
        public productBL(IProductDL productDL)
        {
            this._IProductDL = productDL;
        }

        public Task<List<Product>> getAllProduct()
        {
            var products = _IProductDL.getAllProduct();
            if (products == null)
                return null;
            return products;
        }

        public async Task<List<Product>> getProductByCategory(string Category)
        {
            var products = await _IProductDL.getProductByCategory(Category);
            if (products == null)
                return null;
            return products;
        }
        public async Task<List<Product>> getProductByProductName(string ProductName)
        {
            var products = await _IProductDL.getProductByProductName(ProductName);
            if (products == null)
                return null;
            return products;
        }
        public async Task<List<Product>> getProductByPrice(int Price)
        {
            var products = await _IProductDL.getProductByPrice(Price);
            if (products == null)
                return null;
            return products;
        }

        public async Task<int> postProduct(Product product)
        {
            return await _IProductDL.postProduct(product);
        }
        public async Task<Product> putProduct(Product product, int id)
        {
            await _IProductDL.putProduct(product, id);
            return product;
        }
    }
}

