using System;
using System.ComponentModel.DataAnnotations;


namespace Entidad
{
    public class Person
    {
        [Key]
        public String Identificacion { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Phone { get; set; }
        public String  E_mail { get; set; }
        public String Password { get; set; }
   

        //relacion
        public virtual Client Client { get; set; }

//         +Identificacion: String
//         +Names: String
//         +Surnames: String
//         +Phone: String
//         +E-mail: String
//         Password: String
    }
}