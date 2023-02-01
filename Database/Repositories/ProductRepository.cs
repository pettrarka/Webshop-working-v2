using Core.Abstractions.Repositories;
using Core.Domain;
using System.Text.Json;

namespace Database.Repositories
{
    public class ProductRepository : IProductsRepository
    {
        private readonly Dictionary<int,Proizvod> _products;
        private int _id = 0;

        public ProductRepository()
        {
            if (File.Exists("proizvodi.json"))
                _products = JsonSerializer.Deserialize<Dictionary<int, Proizvod>>(File.ReadAllText("proizvodi.json"));
            else
                _products = new Dictionary<int, Proizvod>();
            
           _id=_products.Count==0 ? 0:_products.Values.Select(p => p.Id).Max();
        }

        public void SaveRepository()
        {
            File.WriteAllText("proizvodi.json", JsonSerializer.Serialize(_products));
        }

        public void Insert(Proizvod product)
        {
            product.Id= ++_id;
            _products.Add(product.Id,product);
            SaveRepository();
        }

        public List<Proizvod> GetAllProducts()
        {
            return _products.Values.ToList();
        }

        public bool Delete(int productId)
        {
                
            if(_products.Remove(productId))
            {
                SaveRepository();
                return true;
            }
            return false;
        }

        public Proizvod? GetID(int productId)
        {
            if (_products.ContainsKey(productId))
            {
                return _products[productId];
            }
            return null;

        }

        public List<Proizvod> SearchByKeyWord(string keyword)
        {
            return _products
                .Values
                .Where(p=>
                    p.Ime.Contains(keyword, StringComparison.OrdinalIgnoreCase) 
                    || p.Opis.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
            
        }

        public bool Update(int productId, Proizvod proizvod)
        {
            if(! _products.ContainsKey(productId)) 
            {
                return false;
            }

            _products[productId] = proizvod;
            SaveRepository();
            return true;
        }
    }
}