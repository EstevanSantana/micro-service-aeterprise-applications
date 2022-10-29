using Microsoft.AspNetCore.Mvc;
using NSE.Cliente.API.Application.Commands;
using NSE.Core.Mediator;
using NSE.WebAPI.Core.Controllers;
using System;
using System.Threading.Tasks;

namespace NSE.Cliente.API.Controllers
{
    //[Authorize]
    public class ClientesController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ClientesController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("cliente")]
        public async Task<IActionResult> Index()
        {
            var result = await _mediatorHandler.EnviarCommand(new RegistrarClienteCommand(Guid.NewGuid(), "teste", "teste@teste.com", "46894424870"));

            return CustomResponse(result);
        }
    }
}
