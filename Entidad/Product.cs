using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public String Name { get; set; }
        public decimal Unit_Price { get; set; }
        public int QuantityStock  { get; set; }
        public String State { get; set; }

         //Relacion
         [ForeignKey("Category")]
         public int CategoryId { get; set; }
         public Category Category { get; set; }



//         +IdProdut:int
//         +Name:String
//         +Unit_price:Decimal
//         +Category:Category
//         +QuantityStock:int
//         +State:String
    }
}