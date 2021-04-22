using System.Net.Http.Headers;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_movil.Models
{
      public class  PresentationInputModel
    {


        
        public String Measure { get; set; }
        public String NPresentation { get; set; }

         
    }

    public class PresentationViewModel : PresentationInputModel {

        public int PresentationId { get; set; }
        public PresentationViewModel  (){}
        public PresentationViewModel (Presentation presentation){
            PresentationId = presentation.PresentationId;
            Measure = presentation.Measure;
            NPresentation = presentation.NPresentation;
               
        }
    }
}