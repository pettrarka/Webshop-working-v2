using Core.Abstractions.Services;
using Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;

namespace WebShop.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productService;

        public ProductsController(IProductsService productService)
        {
            _productService = productService;
        }

        [HttpPost("products")]
        public IActionResult Insert([FromBody] ProizvodViewModel productModel)
        {
            var p = new Proizvod
            {
                Cena = productModel.Cena,
                Ime = productModel.Ime,
                Kategorija = productModel.Kategorija,
                Opis = productModel.Opis,

            };

            _productService.Insert(p);

            return Ok();
        }

        [HttpGet("products")]
        public List<Proizvod> GetAllProducts()
        {
            List<Proizvod> proizvodi = _productService.GetAllProducts();

            return proizvodi;
        }

        [HttpGet("products/search/{keyword}")]

        public List<Proizvod> SearchByKeyWord(string keyword)
        {
            return _productService.SearchByKeyWord(keyword);
        }

        [HttpGet("products/{productId}")]

        public Proizvod? GetID(int productId)
        {
            return _productService.GetID(productId);
        }

        [HttpDelete("products/{productId}")]

        public bool DeleteByID(int productId)
        {
            return _productService.Delete(productId);
        }

        [HttpPut("products")]

        public bool UpdateProducts(int productId, ProizvodViewModel product)
        {
            var p = new Proizvod()
            {
                Id = productId,
                Cena = product.Cena,
                Ime = product.Ime,
                Opis = product.Opis,
                Kategorija = product.Kategorija,

            };
            
            return _productService.Update(productId, p);
        }
    }
}