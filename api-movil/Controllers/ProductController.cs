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

        
        public ProductoController( PulpFreshContext _context)
        {
            _productService = new ProductService(_context);
            _CategoryService = new CategoryService(_context);
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
                State = productoInputModel.State,

            };
            if(_CategoryService.Find(int.Parse(productoInputModel.CategoryId)).Object!=null) product.CategoryId = int.Parse(productoInputModel.CategoryId);
            
            
            return product;
        }
    }
}