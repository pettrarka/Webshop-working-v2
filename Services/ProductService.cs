using Core.Abstractions.Repositories;
using Core.Abstractions.Services;
using Core.Domain;
using System.Reflection.Metadata.Ecma335;

namespace Services
{
    public class ProductService : IProductsService
    {
        private readonly IProductsRepository _repository;

        public ProductService(IProductsRepository productRepository)
        {
            _repository = productRepository;
        }

        public bool Delete(int productId)
        {
            return _repository.Delete(productId);
        }

        public List<Proizvod> GetAllProducts()
        {
           return _repository.GetAllProducts();
        }

        public Proizvod? GetID(int productId)
        {
            return _repository.GetID(productId);
        }

        public void Insert(Proizvod product)
        {
            if(product == null)
                throw new ArgumentNullException(nameof(product));

            _repository.Insert(product);
        }

        public List<Proizvod> SearchByKeyWord(string keyword)
        {
            return _repository.SearchByKeyWord(keyword);
        }

        public bool Update(int productId, Proizvod proizvod)
        {
            return _repository.Update(productId, proizvod);
        }
    }
}