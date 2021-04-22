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
        private readonly CategoryService _categoryService;
        public ProductService(PulpFreshContext context){
            _context = context;
            _categoryService = new CategoryService(context);
        }


       public Response<Product> save(Product product){

            try
            {
                product.State = "Disponible";
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
                var ListUpdate = new List<Product>();
                foreach (var item in procts)
                {
                    item.Category = _context.Categories.Include(p=>p.Presentations)
                        .Where(p=>p.CategoryId==item.Category.CategoryId).FirstOrDefault();
                    ListUpdate.Add(item);
                }

                return new ResponseAll<Product>(ListUpdate);
            }
            catch (System.Exception error)
            {
                
                return new ResponseAll<Product>("Error:"+error);
            }
            
        }
    }
}