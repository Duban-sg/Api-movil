using System;
using DAl;
using Entidad;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class ClientService{

        private readonly PulpFreshContext _context;
        public ClientService(PulpFreshContext context){
            _context = context;
        }


       public Response<Client> save(Client client){

            try
            {
                
                _context.Clients.Add(client);
                _context.SaveChanges();
                return new Response<Client>(client);
            }
            catch (System.Exception error)
            {
                
                return new Response<Client>("Error:"+error);
            }
            
        }
        public ResponseAll<Client> AllCLients( ){

            try
            {
                List<Client> procts = _context.Clients.Include(p=>p.Person).ToList();
                return new ResponseAll<Client>(procts);
            }
            catch (System.Exception error)
            {
                
                return new ResponseAll<Client>("Error:"+error);
            }
            
        }
    }
}