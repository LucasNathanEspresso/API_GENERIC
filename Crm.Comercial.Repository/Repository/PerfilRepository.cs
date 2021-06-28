using Crm.Comercial.Domain.Model;
using Crm.Comercial.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Comercial.Domain.Repository
{
    public class PerfilRepository
    {
        private readonly ApplicationDbContext _context;
        private DbSet<Perfil> entities;
        public PerfilRepository()
        {
            _context = new ApplicationDbContext();
            entities = _context.Set<Perfil>();
        }


        public Task<Perfil> BuscaPefil(long id)
        {
            try
            {
                return entities.FirstOrDefaultAsync(m => m.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
        }

    }
}
