using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad;
using DAl;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using api_movil.Models;

namespace api_movil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly CategoryService _CategoryService;
        private readonly PresentationService _PresentationService;

        
        public ProductoController( PulpFreshContext _context)
        {
            _productService = new ProductService(_context);
            _CategoryService = new CategoryService(_context);
            _PresentationService = new PresentationService (_context);
        }


        // Post: api/Producto
        [HttpPost]
        public ActionResult<ProductViewModel> Post(ProductInputModel productoInputModel)
        {
            Product producto = MapearProducto(productoInputModel);
            var response = _productService.save(producto);
            if(response.Error==false)return Ok(new ProductViewModel(response.Object));
            else return BadRequest(response.Menssage);

        }

        private Product MapearProducto(ProductInputModel productoInputModel)
        {
            var product = new Product
            {
            
                Name = productoInputModel.Name,
                Unit_Price = productoInputModel.Unit_Price,
                QuantityStock = productoInputModel.QuantityStock,
                Category = _CategoryService.Find(int.Parse(productoInputModel.CategoryId)).Object,
                Presentations = _PresentationService.SelectPresentations(productoInputModel.PresentationsIds).List,

            };
            
            
            
            return product;
        }

        // GET: api/Producto
        [HttpGet]
        public ActionResult<IEnumerable<ProductViewModel>> Gets()
        {
            var response = _productService.AllProducts(); 
            if(response.Error){
           
                return BadRequest(response.Menssage);
            }
            var products = response.List.Select(p => new ProductViewModel(p));
            return Ok(products);
        }
    }
}