//base model:

using System.Net.Http.Headers;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_movil.Models
{
      public class  CategoryInputModel
    {

        
        public String Name { get; set; }
        public List<String> PresentationsIds { get; set; }
 

         
    }

    public class CategoryViewModel : CategoryInputModel {

        public int CategoryId { get; set; }
        public List<PresentationViewModel> Presentations { get; set; }
        public CategoryViewModel  (){}
        public CategoryViewModel (Category category){
            CategoryId = category.CategoryId;
            Name = category.Name;
            Presentations =  category.Presentations.Select(p=> new PresentationViewModel(p)).ToList();
            
        }
    }
}