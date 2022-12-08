using Microsoft.EntityFrameworkCore;
using ProjectAlbar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAlbar.DL
{
    public class ProductDL : IProductDL
    {
        DBprojectAlbar DBprojectAlbar;

        public ProductDL(DBprojectAlbar DBprojectAlbar)
        {
            this.DBprojectAlbar = DBprojectAlbar;
        }

        public async Task<List<Product>> getAllProduct()
        {
            var productsToGet = await DBprojectAlbar.Products.ToListAsync();
            if (productsToGet == null)
                return null;
            return productsToGet;
        }

        public async Task<List<Product>> getProductByCategory(string category)
        {
            var productsToGet = await DBprojectAlbar.Products.Where(p => p.Category == category).ToListAsync();
            if (productsToGet == null)
                return null;
            return productsToGet;
        }
        public async Task<List<Product>> getProductByProductName(string productName)
        {
            var productsToGet = await DBprojectAlbar.Products.Where(p => p.ProductName == productName).ToListAsync();
            if (productsToGet == null)
                return null;
            return productsToGet;
        }
        public async Task<List<Product>> getProductByPrice(int price)
        {
            var productsToGet = await DBprojectAlbar.Products.Where(p => p.Price == price).ToListAsync();
            if (productsToGet == null)
                return null;
            return productsToGet;
        }
        public async Task<int> postProduct(Product product)
        {
            try
            {
                using (var context = new DBprojectAlbar())
                {
                    await context.Products.AddAsync(product);
                    await context.SaveChangesAsync();
                }
                return 1;
            }
            catch
            {
                Console.WriteLine($"Failed to save product to DB. Product Name: {product.ProductName}");
                return -1;
            }
         
        }
        public async Task<Product> putProduct(Product product, int id)
        {
            var productToChange = await DBprojectAlbar.Products.FindAsync(id);
            product.ProductId = id;
            DBprojectAlbar.Entry(productToChange).CurrentValues.SetValues(product);
            await DBprojectAlbar.SaveChangesAsync();
            return productToChange;
        }


    }
}
