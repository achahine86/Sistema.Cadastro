using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema.Cadastro.Models;

namespace Sistema.Cadastro.Controllers
{
    //Herdando a classe
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult Cadastrar(){
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(IFormCollection form)
        {
            UsuarioModel usuario = new UsuarioModel();
            /*?????*/ usuario.IdUsuario = usuario.Count +1; /*?????*/
            usuario.Nome = form["nome"];
            usuario.Email = form["email"];
            usuario.Senha = form["senha"];
            usuario.TipoUsuario = int.Parse(form["tipoUsuario"]);

            //Escrevendo um arquivo .csv
            using(StreamWriter sw = new StreamWriter("usuarios.csv", true)){
                sw.WriteLine($"{usuario.Nome};{usuario.Email};{usuario.Senha};{usuario.TipoUsuario}");
            }

            ViewBag.Mensagem = "Usuário cadastrado";

            return View();
        }

        [HttpGet]
        public ActionResult Login(){
            return View();
        }

        [HttpPost]
        public ActionResult Login(IFormCollection form){
            UsuarioModel usuario = new UsuarioModel();
            usuario.Email = form["email"];
            usuario.Senha = form["senha"];

            //Percorrendo os registros
            using(StreamReader sr = new StreamReader("usuario.csv")){
                //Lendo os registros, enquanto houverem
                while (!sr.EndOfStream)
                {
                    string[] linha = sr.ReadLine().Split(";");
                    //Validando email e senha do usuário
                    if(linha[1] == usuario.Email && linha[2] == usuario.Senha)
                    {
                        HttpContext.Session.SetString("emailUsuario",usuario.Email);
                        return RedirectToAction("Cadastrar","Tarefa");
                    }
                }
                ViewBag.Mensagem = "Usuário inválido";
                return View();
            }
        }
    }
}