using NSE.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Cliente.API.Models
{
    public interface IClientesRepository : IRepository<Clientes>
    {
        void Adicionar(Clientes clientes);

        Task<IEnumerable<Clientes>> ObterTodosClientes();
        Task<Clientes> ObterPorCpf(string cpf);
    }
}
