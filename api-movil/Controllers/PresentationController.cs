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
    public class PresentationController : ControllerBase
    {
        private readonly PresentationService _presentationService;

        
        public PresentationController( PulpFreshContext _context)
        {
            _presentationService = new PresentationService(_context);
        }


        // Post: api/Presentation
        [HttpPost]
        public ActionResult<PresentationViewModel> Post(PresentationInputModel presentationInputModel)
        {
            Presentation presentation = MapearPresentation(presentationInputModel);
            var response = _presentationService.save(presentation);
            if(response.Error==false)return Ok(response.Object);
            else return BadRequest(response.Menssage);
            
        }

        private Presentation MapearPresentation(PresentationInputModel presentationInputModel)
        {
           var presentation = new Presentation
           {
            Measure = presentationInputModel.Measure,
            NPresentation = presentationInputModel.NPresentation

           };
            
            
           return presentation;
        }

        // GET: api/Presentation
        [HttpGet]
        public ActionResult<IEnumerable<PresentationViewModel>> Gets()
        {
            var response = _presentationService.AllPresentations(); 
            if(response.Error){
           
                return BadRequest(response.Menssage);
            }
            var presentations = response.List.Select(p => new PresentationViewModel(p));
            return Ok(presentations);
        }
    }
}