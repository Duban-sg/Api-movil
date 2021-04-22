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
    public class CateogryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        private readonly PresentationService _PresentationService;

        
        public CateogryController( PulpFreshContext _context)
        {
            _categoryService = new CategoryService(_context);
            _PresentationService = new PresentationService (_context);
        }


        // Post: api/Category
        [HttpPost]
        public ActionResult<CategoryViewModel> Post(CategoryInputModel categoryInputModel)
        {
            Category category = MapearCategory(categoryInputModel);
            var response = _categoryService.save(category);
            if(response.Error==false)return Ok(new CategoryViewModel(response.Object));
            else return BadRequest(response.Menssage);
        }

        private Category MapearCategory(CategoryInputModel categoryInputModel)
        {
           var category = new Category
           {
            Name = categoryInputModel.Name,
            Presentations = _PresentationService.SelectPresentations(categoryInputModel.PresentationsIds).List,

           };
            
            
           return category;
        }

        // GET: api/Category
        [HttpGet]
        public ActionResult<IEnumerable<CategoryViewModel>> Gets()
        {
            var response = _categoryService.AllCategories(); 
            if(response.Error){
           
                return BadRequest(response.Menssage);
            }
            var categories = response.List.Select(p => new CategoryViewModel(p));
            return Ok(categories);
        }
    }
}

