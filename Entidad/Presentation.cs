using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace Entidad
{
    public class Presentation
    {
        // [Key]
        public int PresentationId { get; set; }
        public String Measure { get; set; }
        public String NPresentation { get; set; }

        //realcion
        public virtual List<Category> Categories { get; set; }


    }
}