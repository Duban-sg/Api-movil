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
                client.Person.Status = true;
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

        public Response<Client> Find(String Identificacion ){

            try
            {
                var _listaClientes = _context.Clients.Include(p=>p.Person).ToList();
                var _Client = _listaClientes.Where(p=>p.Person.Identificacion == Identificacion).FirstOrDefault();
                if(_Client == null)return new Response<Client>("No se encontro ningun cliente con este numero de identificacion");
                return new Response<Client>(_Client);
            }
            catch (System.Exception error)
            {
                
                return new Response<Client>("Error:"+error);
            }
            
        }

        

        public Response<Client> Modify( Client newClient){
            try
            {
                var oldClient = Find(newClient.Person.Identificacion);
                if(oldClient.Error) return oldClient;
                else{
                    oldClient.Object.Address = newClient.Address;
                    oldClient.Object.City = newClient.City;
                    oldClient.Object.Department = newClient.Department;
                    oldClient.Object.Neighborhood = newClient.Neighborhood;
                    oldClient.Object.Person.E_mail = newClient.Person.E_mail;
                    oldClient.Object.Person.Phone = newClient.Person.Phone;
                    oldClient.Object.Person.Name = newClient.Person.Name;
                    oldClient.Object.Person.LastName = newClient.Person.LastName;
                    oldClient.Object.Person.Status = newClient.Person.Status;
                    _context.Clients.Update(oldClient.Object);
                    _context.SaveChanges();
                    return oldClient;
                }
            }
            catch (System.Exception error)
            {
                return new Response<Client>("Error:"+error);
                
            }
        }

        public Response<Client> Delete( String Identificacion){
            try
            {
                var Client = Find(Identificacion);
                if(Client.Error) return Client;
                else{
                    Client.Object.Person.Status = false;
                    _context.Clients.Update(Client.Object);
                    _context.SaveChanges();
                    return Client;
                }
            }
            catch (System.Exception error)
            {
                return new Response<Client>("Error:"+error);
                
            }
        }

        public Response<Client> ModifyPass( String Identificacion , String Contraseña){
            try
            {
                var Client = Find(Identificacion);
                if(Client.Error) return Client;
                else{
                    Client.Object.Person.Password = Contraseña;
                    _context.Clients.Update(Client.Object);
                    _context.SaveChanges();
                    return Client;
                }
            }
            catch (System.Exception error)
            {
                return new Response<Client>("Error:"+error);
                
            }
        }
    }
}