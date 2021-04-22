using System.Net.Http.Headers;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_movil.Models
{
      public class  ClientInputModel
    {

                public PersonInputModel Person { get; set; }
                public String Address { get; set; }
                public String City { get; set; }
                public String Department { get; set; }
                public String Neighborhood { get; set; }
        

         
    }

    public class ClientViewModel : ClientInputModel {

        
        public ClientViewModel  (){}
        public ClientViewModel (Client client){

            Address = client.Address;
            City = client.City;
            Department = client.Department;
            Neighborhood = client.Neighborhood;
            Person = new PersonViewModel(client.Person);
               
        }
    }


}