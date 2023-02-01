using Core.Domain;

namespace Core.Abstractions.Repositories
{
    public interface IProductsRepository
    {
        void Insert(Proizvod product);

        List<Proizvod> GetAllProducts();

        bool Delete(int productId);

        Proizvod? GetID(int productId);

        List<Proizvod> SearchByKeyWord(string keyword);

        bool Update(int productId, Proizvod proizvod);

    }
}