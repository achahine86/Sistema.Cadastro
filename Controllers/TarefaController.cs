using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema.Cadastro.Models;

namespace Sistema.Cadastro.Controllers
{
    public class TarefaController : Controller
    {
        [HttpGet]
        public IActionResult Cadastrar(){
            if(string.IsNullOrEmpty(HttpContext.Session.GetString("emailUsuario"))){
                return RedirectToAction("Login","Usuario");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(IFormCollection form){
            TarefaModel tarefa = new TarefaModel();
            tarefa.IdTarefa = 1;
            tarefa.Descricao = form["descricao"];
            tarefa.TipoTarefa = form["tipoTarefa"];
            

            return View();
        }
    }
}