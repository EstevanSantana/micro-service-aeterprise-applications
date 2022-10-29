using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        [Route("sistema-indisponivel")]
        public IActionResult SistemaIndisponivel()
        {
            var modelError = new ErrorViewModel()
            {
                Mensagem = "Infelizmente, o sistema esta temporariamente indisponivel! Tente novamente em alguns instantes ou entre em contato com nosso suporte.",
                Titulo = "Sistema indisponivel.",
                ErrorCode = 500,
            };

            return View("Error", modelError);
        }


        [Route("erro/{id:length(3,3)}")]
        public IActionResult Erro(int id)
        {
            var modelError = new ErrorViewModel();

            if (id == 500)
            {
                modelError.Mensagem = "Infelizmente, ocorreu um erro! Tente novamente em alguns instantes ou entre em contato com nosso suporte.";
                modelError.Titulo = "Ocorreu um erro.";
                modelError.ErrorCode = id;
            }
            else if (id == 404)
            {
                modelError.Mensagem = "A página que você está procurando não existe! <br /> Se você acha que isso não poderia acontecer, entre em contato com nosso suporte.";
                modelError.Titulo = "Ops! Pagina não encontrada.";
                modelError.ErrorCode = id;
            }
            else if (id == 403)
            {
                modelError.Mensagem = "Você não pode fazer isso.";
                modelError.Titulo = "Acesso negado.";
                modelError.ErrorCode = id;
            }
            else
            {
                return StatusCode(404);
            }

            return View("Error", modelError);
        }
    }
}
