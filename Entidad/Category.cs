using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace Entidad
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public String Name { get; set; }

    }
}