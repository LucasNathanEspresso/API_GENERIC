using Crm.Comercial.Domain.Model;
using Crm.Comercial.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Comercial.Domain.Repository
{
    public class ValicacoRepository
    {
        private readonly ApplicationDbContext _context;
        private DbSet<Validacao> entities;
        public ValicacoRepository()
        {
            _context = new ApplicationDbContext();
            entities = _context.Set<Validacao>();
        }


        public Validacao BuscaValidacao(string CodValidacao)
        {
            try
            {
                Validacao Validacao = entities.FirstOrDefaultAsync(m => m.CodValidacao == CodValidacao).Result;
                return Validacao;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
        }


    }
}
