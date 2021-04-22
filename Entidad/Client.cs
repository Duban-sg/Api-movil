using System;
using System.ComponentModel.DataAnnotations;


namespace Entidad
{
    public class Client
    {
        // [Key]
        public int ClientId { get; set; }
        public Person Person { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String Department { get; set; }
        public String Neighborhood { get; set; }


        // Relacion
        public String Identificacion { get; set; }

// +Address: String
// +Neighborhood: String
// +City: String
// +Department: String

   




    }
}