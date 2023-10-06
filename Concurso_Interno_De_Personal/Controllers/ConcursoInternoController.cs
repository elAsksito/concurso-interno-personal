using Concurso_Interno_De_Personal.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Concurso_Interno_De_Personal.Controllers
{
    public class ConcursoInternoController : Controller
    {
        private static List<ConcursoInterno> conInterno = new List<ConcursoInterno>()
       {
           new ConcursoInterno() {ordenMerito = "001-2023", nombres = "Brandon Allan", apellidos = "Sagastegui Herrada", dni = "73122219", idEva = "001-SMV", puesto = "x", desempenio = 20, conocimiento = 20, evaCurricular = 20, entrevista = 20, bonificacion = 0},
           new ConcursoInterno() {ordenMerito = "002-2023", nombres = "Jose", apellidos = "Sullcapuma", dni = "12345678", idEva = "002-SMV", puesto = "y", desempenio = 15, conocimiento = 15, evaCurricular = 13, entrevista = 13, bonificacion = 1},
           new ConcursoInterno() {ordenMerito = "003-2023", nombres = "Cesar", apellidos = "Alayo", dni = "87654321", idEva = "003-SMV", puesto = "z", desempenio = 10, conocimiento = 9, evaCurricular = 2, entrevista = 15, bonificacion = 0}
       };

        public ActionResult Listar(string filtro = "")
        {
            if (string.IsNullOrEmpty(filtro))
            {
                return View(conInterno);
            }
            else
            {
                string filtroLimpio = filtro.Trim().ToLower();
                return View(conInterno.Where(conInterno
                    => conInterno.ordenMerito.ToLower().Contains(filtroLimpio) ||
                        conInterno.dni.ToLower().Contains(filtroLimpio) ||
                        conInterno.idEva.ToLower().Contains(filtroLimpio) ||
                        conInterno.resultado.ToLower().Contains(filtroLimpio)));

            }
        }

        [HttpGet]
        public ActionResult AgregarParticipante()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarParticipante(ConcursoInterno postulante)
        {
            if (ModelState.IsValid)
            {
                postulante.idEva = "";
                postulante.desempenio = 0;
                postulante.conocimiento = 0;
                postulante.evaCurricular = 0;
                postulante.entrevista = 0;
                postulante.bonificacion = 0;
                conInterno.Add(postulante);
                return RedirectToAction("Listar");
            }
            return View(postulante);
        }

        public ActionResult Detalles(string id = "")
        {
            ConcursoInterno ci = conInterno.SingleOrDefault(c => c.ordenMerito == id);
            return View(ci);
        }

        [HttpGet]
        public ActionResult Editar(string id)
        {
            ConcursoInterno post = conInterno.FirstOrDefault(c => c.ordenMerito == id);

            if (post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }

        [HttpPost]
        public ActionResult Editar(ConcursoInterno notas)   
        {
            if (ModelState.IsValid)
            {
                var postExistente = conInterno.FirstOrDefault(p => p.ordenMerito == notas.ordenMerito);

                if (postExistente != null)
                {
                    postExistente.ordenMerito = notas.ordenMerito;
                    postExistente.nombres = notas.nombres;
                    postExistente.apellidos = notas.apellidos;
                    postExistente.dni = notas.dni;
                    postExistente.idEva = notas.idEva;

                    return RedirectToAction("Listar");
                }
                else
                {
                    return HttpNotFound();
                }
            }

            return View(notas);


        }
    }
}