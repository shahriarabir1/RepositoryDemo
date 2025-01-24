using RepositoryDemo.Data;
using RepositoryDemo.Model;
using RepositoryDemo.Repositories;

namespace RepositoryDemo.Services
{
    public class HomeService : IHomeRepositories
    {
        private readonly ApplicationDbContext _context;

        public HomeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Product CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void DeleteProduct(int id)
        {
            var y = _context.Products.Where(x => x.Id == id).FirstOrDefault() ?? null;
            if (y != null)
            {
                _context.Products.Remove(y);
                _context.SaveChanges();
            }
        }
       

        public void Dispose()
        {
            _context?.Dispose();
        }

        public IEnumerable<Product> GetAllProducts()
        {
           return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            var y= _context.Products.Where(x => x.Id == id).FirstOrDefault() ?? null;
            return y;
        }

        public Product GetProductByName(string name)
        {
            var y=_context.Products.Where(x=>x.Name==name).FirstOrDefault() ?? null;
            return y;
        }

        public Product UpdateProduct(Product product)
        {
            var y = _context.Products.Where(x => x.Id == product.Id).FirstOrDefault() ?? null;
            if (y != null)
            {
               y.Id = product.Id;
               y.Name = product.Name;
                y.Description = product.Description;
  
                _context.SaveChanges();
                return y;
            }
            throw new KeyNotFoundException("Product not found.");

        }
    }
}
