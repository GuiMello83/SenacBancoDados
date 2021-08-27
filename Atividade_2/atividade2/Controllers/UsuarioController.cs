using atividade2.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace atividade2.Controllers
{
    public class UsuarioController : Controller
    {
        //o objetivo é ter as rotas com as actions - as ações são na ideia do crud

        public IActionResult Editar(int Id)
        {
               if(HttpContext.Session.GetInt32("IdUsuario")==null){
                return RedirectToAction("Login","Usuario");
            }

            UsuarioRepository ur = new UsuarioRepository();

            Usuario userLocalizado = ur.BuscarPorId(Id);
            return View(userLocalizado);
        }

        [HttpPost]
        public IActionResult Editar(Usuario user)
        {
            UsuarioRepository ur = new UsuarioRepository();
           ur.Alterar(user);
            return RedirectToAction("Lista", "Usuario");
        }

        public IActionResult Remover(int Id)
        {
               if(HttpContext.Session.GetInt32("IdUsuario")==null){
                return RedirectToAction("Login","Usuario");
            }

            UsuarioRepository ur = new UsuarioRepository();

            Usuario userLocalizado = ur.BuscarPorId(Id);
            ur.Excluir(userLocalizado);
            return RedirectToAction("Lista", "Usuario");

        }

        public IActionResult Lista()
        {
            if(HttpContext.Session.GetInt32("IdUsuario")==null){
                return RedirectToAction("Login","Usuario");
            }

            UsuarioRepository ur = new UsuarioRepository();
            List<Usuario> listagem = ur.Listar();
            return View(listagem);
        }
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario user)
        {
            UsuarioRepository ur = new UsuarioRepository();
            ur.Inserir(user);
            ViewBag.mensagem = "Cadastro realizado com sucesso!";
            return View();
        }

        public IActionResult Login(){
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario user){
            UsuarioRepository ur = new UsuarioRepository();
            Usuario usuarioEncontrado = ur.ValidarLogin(user);

            if(usuarioEncontrado==null) {
                ViewBag.mensagem = "Falha no Login";
                return View();

            }else {

                    //iremos gravar na sessão nossas credenciais 
                HttpContext.Session.SetInt32("IdUsuario",usuarioEncontrado.Id);
                HttpContext.Session.SetString("NomeUsuario",usuarioEncontrado.Nome);

                return RedirectToAction("Lista","Usuario"); //action,  controller
            }
        }
        public IActionResult Logout(){
            //objetivo é limpar os dados da sessão
            HttpContext.Session.Clear();
            return View("Login");
        }
    }
}