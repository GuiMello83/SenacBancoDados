using atividade2.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace atividade2.Controllers
{
    public class PacotesTuristicosController : Controller
    {
        
        public IActionResult Editar(int Id)
        {
                if(HttpContext.Session.GetInt32("IdUsuario")==null){
                return RedirectToAction("Login","Usuario");
            }
            PacotesTuristicosRepository ur = new PacotesTuristicosRepository();

            PacotesTuristicos pacoteLocalizado = ur.BuscarPorId(Id);
            return View(pacoteLocalizado);
        }

        [HttpPost]
        public IActionResult Editar(PacotesTuristicos pacote)
        {
            
           PacotesTuristicosRepository ur = new PacotesTuristicosRepository();
           ur.Alterar(pacote);
            return RedirectToAction("Lista", "PacotesTuristicos");
        }

        public IActionResult Remover(int Id)
        {
                if(HttpContext.Session.GetInt32("IdUsuario")==null){
                return RedirectToAction("Login","Usuario");
            }

            PacotesTuristicosRepository ur = new PacotesTuristicosRepository();

            PacotesTuristicos pacoteLocalizado = ur.BuscarPorId(Id);
            ur.Excluir(pacoteLocalizado);
            return RedirectToAction("Lista", "PacotesTuristicos");

        }

        public IActionResult Lista()
        {
                if(HttpContext.Session.GetInt32("IdUsuario")==null){
                return RedirectToAction("Login","Usuario");
            }

            PacotesTuristicosRepository ur = new PacotesTuristicosRepository();
            List<PacotesTuristicos> listagem = ur.Listar();
            return View(listagem);
        }
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(PacotesTuristicos pacote)
        {
                if(HttpContext.Session.GetInt32("IdUsuario")==null){
                return RedirectToAction("Login","Usuario");
            }
            
            PacotesTuristicosRepository ur = new PacotesTuristicosRepository();
            ur.Inserir(pacote);
            ViewBag.mensagem = "Pacote cadastrado com sucesso!";
            return View();
        }
    }
}


