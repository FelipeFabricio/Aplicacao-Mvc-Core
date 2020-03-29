using Microsoft.EntityFrameworkCore;
using MvcCore.Business.Interfaces;
using MvcCore.Business.Models;
using MvcCore.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcCore.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MyDbContext context): base(context){}

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.Enderecos.AsNoTracking()
                  .FirstOrDefaultAsync(e => e.FornecedorId == fornecedorId);
        }
    }
}
