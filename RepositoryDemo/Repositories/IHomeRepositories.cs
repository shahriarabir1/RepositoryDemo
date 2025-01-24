using RepositoryDemo.Model;

namespace RepositoryDemo.Repositories
{
    public interface IHomeRepositories:IDisposable
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProductById(int id);
        
        Product GetProductByName(string name);

        Product CreateProduct(Product product);
        Product UpdateProduct(Product product);

        void DeleteProduct(int  id);
    }
}
