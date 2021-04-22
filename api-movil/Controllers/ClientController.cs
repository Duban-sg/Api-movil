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
    public class ClientController : ControllerBase
    {
        private readonly ClientService _ClientService;

        
        public ClientController( PulpFreshContext _context)
        {
            _ClientService = new ClientService(_context);
        }


        // Post: api/Client
        [HttpPost]
        public ActionResult<ClientViewModel> Post(ClientInputModel clientInputModel)
        {   
            Client client = MapearClient(clientInputModel);
            var response = _ClientService.save(client);
            if(response.Error==false)return Ok(response.Object);
            else return BadRequest(response.Menssage);
 		
        }

        private Client MapearClient(ClientInputModel clientInputModel)
        {
           var client = new Client
           {
                Address = clientInputModel.Address,
                City = clientInputModel.City,
                Department = clientInputModel.Department,
                Neighborhood = clientInputModel.Neighborhood,
                Person = MapPerson(clientInputModel.Person),

           };
            
            
           return client;
        }

        private Person MapPerson(PersonInputModel personModel)
        {
           var person = new Person
           {
                Identificacion= personModel.Identificacion,
                Name = personModel.Name,
                LastName = personModel.LastName,
                E_mail = personModel.E_mail,
                Password = personModel.Password,
                Phone = personModel.Phone,

           };
            
            
           return person;
        }

        // GET: api/Presentation
        [HttpGet]
        public ActionResult<IEnumerable<ClientViewModel>> Gets()
        {
            var response = _ClientService.AllCLients(); 
            if(response.Error){
           
                return BadRequest(response.Menssage);
            }
            var personas = response.List.Select(p => new ClientViewModel(p));
            return Ok(personas);
        }



    }
}


