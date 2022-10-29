using FluentValidation.Results;
using MediatR;
using NSE.Cliente.API.Application.Events;
using NSE.Cliente.API.Models;
using NSE.Core.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Cliente.API.Application.Commands
{
    public class ClienteCommandHandler : CommandHandler, IRequestHandler<RegistrarClienteCommand, ValidationResult>
    {
        private readonly IClientesRepository _clientesRepository;

        public ClienteCommandHandler(IClientesRepository clientesRepository)
        {
            _clientesRepository = clientesRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var cliente = new Clientes(message.Id, message.Nome, message.Email, message.Cpf);

            var clienteExistente = await _clientesRepository.ObterPorCpf(message.Cpf);

            if (clienteExistente != null)
            {
                AdicionarErro("Este CPF já esta em uso.");
                return ValidationResult;
            }

            _clientesRepository.Adicionar(cliente);

            cliente.AdicionarEvento(new ClienteRegistradoEvent(message.Id, message.Nome, message.Email, message.Cpf));

            return await PersistirDados(_clientesRepository.UnitOfWork);
        }
    }
}
