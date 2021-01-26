using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using category.DataAccess;
using category.Interfaces;
using category;
using Microsoft.EntityFrameworkCore;
using Product = category.Model.Product;

namespace category.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _context;

        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProduct(ProductModel product)
        {
            var newProduct = new Product()
            {
                Name = product.Name,
                CategoryId = product.CategoryId,
                Description = product.Description,
                Price = product.Price,
            };

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return await Task.FromResult(newProduct);
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var productToDelete = await _context.Products.FirstOrDefaultAsync(x => x.Id.Equals(id));
            _context.Products.Remove(productToDelete);
            await _context.SaveChangesAsync();

            return await Task.FromResult(productToDelete);
        }

        public async Task<Product> ModifyProduct(ProductModifyModel product)
        {
            var productToModify = await _context.Products.FirstOrDefaultAsync(x => x.Id.Equals(product.Id));

            productToModify.Name = product.Name;
            productToModify.CategoryId = product.CategoryId;
            productToModify.Price = product.Price;
            productToModify.Description = product.Description;

            await _context.SaveChangesAsync();

            return await Task.FromResult(productToModify);
        }

        public async Task<Product> ChangeCategory(ChangeProductCategoryModel product)
        {
            var productToModify = await _context.Products.FirstOrDefaultAsync(x => x.Id.Equals(product.ProductId));
            productToModify.CategoryId = product.CategoryId;

            await _context.SaveChangesAsync();

            return await Task.FromResult(productToModify);
        }

        public async Task<List<Product>> GetProductsByCategory(int id)
        {
            return await _context.Products.Where(x => x.Category.Id.Equals(id)).ToListAsync();
        }
    }
}