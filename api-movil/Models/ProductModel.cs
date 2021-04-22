using System.Net.Http.Headers;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_movil.Models
{
      public class  ProductInputModel
    {


        
        public String Name { get; set; }
        public decimal Unit_Price { get; set; }
        public String CategoryId { get; set; }
        public int QuantityStock  { get; set; }
        public String State { get; set; }

         
    }

    public class ProductViewModel : ProductInputModel {

        public CategoryViewModel Category { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel  (){}
        public ProductViewModel (Product product){
            
            ProductId = product.ProductId;
            Name = product.Name;
            Unit_Price = product.Unit_Price;
            Category = new CategoryViewModel(product.Category);
            QuantityStock = product.QuantityStock;
            State = product.State;
            
        }
    }
}