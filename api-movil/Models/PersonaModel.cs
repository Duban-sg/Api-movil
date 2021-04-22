using System.Net.Http.Headers;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_movil.Models
{
    public class PersonInputModel{
        public String Identificacion { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Phone { get; set; }
        public String  E_mail { get; set; }
        public String Password { get; set; }

    }

    public class PersonViewModel:PersonInputModel{

        public PersonViewModel(){}
        public PersonViewModel(Person person){
            Identificacion= person.Identificacion;
            Name = person.Name;
            LastName = person.LastName;
            Phone = person.Phone;
            E_mail = person.E_mail;
            Password = person.Password;
        }
    }
}