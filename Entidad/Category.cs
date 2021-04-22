using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace Entidad
{
    public class Category
    {
        // [Key]
        public int CategoryId { get; set; }
        public String Name { get; set; }
        public List<Presentation> Presentations { get; set; }


         //Relacion
        // public int PresentationId { get; set; }
        public virtual Product Product { get; set; }
        



//         +idCategory: int
// +Name: String
// +Presentations:Presentation
    }
}