using System;
using DAl;
using Entidad;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class ProductService{

        private readonly PulpFreshContext _context;
        public ProductService(PulpFreshContext context){
            _context = context;
        }


       public Response<Product> save(Product product){

            try
            {
                
                _context.Products.Add(product);
                _context.SaveChanges();
                return new Response<Product>(product);
            }
            catch (System.Exception error)
            {
                
                return new Response<Product>("Error:"+error);
            }
            
        }
        public ResponseAll<Product> AllProducts( ){

            try
            {
                List<Product> procts = _context.Products.Include(p=>p.Category).ToList();
                return new ResponseAll<Product>(procts);
            }
            catch (System.Exception error)
            {
                
                return new ResponseAll<Product>("Error:"+error);
            }
            
        }
    }
}