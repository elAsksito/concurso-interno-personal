using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace Concurso_Interno_De_Personal.Models
{
    public class ConcursoInterno : Postulante
    {
        public ConcursoInterno() { }

        public string idEva { get; set; }
        public string puesto { get; set; }
        public double desempenio { get; set; }
        public double conocimiento { get; set; }
        public double evaCurricular { get; set; }
        public double entrevista { get; set; }
        public double bonificacion { get; set; }
        public double puntajeFinal { get{  return promedio(); }}
        
        public string resultado { get { return resultadoS(); } }


        private double promedio()
        {
            return bonificacion +((desempenio + conocimiento + evaCurricular + entrevista ) / 4);
        }

        private string resultadoS()
        {
            double promedioFinal = promedio();
            if(promedioFinal == 0){
                return "Sin Calificar";
            }
            else if(promedioFinal < 12)
            {
                return "Descalifica";
            }
            else if (promedioFinal < 16)
            {
                return "No Pasa";
            }
            else { return "Aprobado"; }
        }
    }
}