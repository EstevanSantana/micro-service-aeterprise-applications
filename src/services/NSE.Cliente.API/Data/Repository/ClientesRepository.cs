using Microsoft.EntityFrameworkCore;
using NSE.Cliente.API.Models;
using NSE.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Cliente.API.Data
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly ClientesContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ClientesRepository(ClientesContext context)
        {
            _context = context;
        }

        public async Task<Clientes> ObterPorCpf(string cpf)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Cpf.Numero == cpf);
        }

        public async Task<IEnumerable<Clientes>> ObterTodosClientes()
        {
            return await _context.Clientes.AsNoTracking().ToListAsync();
        }

        public void Adicionar(Clientes clientes)
        {
            _context.Clientes.Add(clientes);
        }

        public void Dispose()
        {
            _context?.Dispose();   
        }
    }
}
