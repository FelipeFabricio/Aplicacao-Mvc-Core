using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcCore.App.Models;

namespace MvcCore.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("error/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelErro = new ErrorViewModel();

            if(id == 404)
            {
                modelErro.Titulo = "Essa página não existe :(";
                modelErro.Mensagem = "Em caso de dúvidas, entre em contato com o Administrador.";
                modelErro.id = id;
            }
            else if (id == 500)
            {
                modelErro.Titulo = "Oops! Um erro aconteceu";
                modelErro.Mensagem = "Tente novamente mais tarde.";
                modelErro.id = id;
            }
            else if (id == 403)
            {
                modelErro.Titulo = "Acesso Negado !";
                modelErro.Mensagem = "Você não tem permissão para fazer isso";
                modelErro.id = id;
            }
            else
            {
                return StatusCode(500);
            }

            return View("Error", modelErro);
            
        }
    }
}
