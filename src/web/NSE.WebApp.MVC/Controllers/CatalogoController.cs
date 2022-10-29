using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    public class CatalogoController : MainController
    {
        private readonly ICatalogoService _catalogoService;

        public CatalogoController(ICatalogoService catalogoService)
        {
            _catalogoService = catalogoService;
        }

        [HttpGet]
        [Route("")]
        [Route("vitrine")]
        public async Task<IActionResult> Index()
        {
            return View(await _catalogoService.ObterTodos());
        }

        [HttpGet]
        [Route("produto-detalhes/{id}")]
        public async Task<IActionResult> ProdutoDetalhe(Guid id)
        {
            return View(await _catalogoService.ObterPorId(id));
        }
    }
}
