using Dominos.Core.Base;
using Dominos.Core.Domain;
using Dominos.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominos.Infrastructure.Service
{
    public class ProductService : BaseService<Product>, IProductService
    {

        public ProductService(IRepository<Product> productRepository) : base(productRepository)
        {
        }

        public void AddProduct(Product product)
        {
            BaseRepository.Insert(product);
        }

        public List<Product> GetProducts()
        {
            return BaseRepository.Table.ToList();
        }
    }

    public interface IProductService : IBaseService<Product>
    {
        void AddProduct(Product product);
        List<Product> GetProducts();
    }
}
