using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concurso_Interno_De_Personal.Models
{
    public class Postulante
    {
        public string ordenMerito { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set;}
        public string dni { get; set;}
    
        public Postulante() { } 
    }
}