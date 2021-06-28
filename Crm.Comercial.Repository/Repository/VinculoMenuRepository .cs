using Crm.Comercial.Domain.Model;
using Crm.Comercial.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;


namespace Crm.Comercial.Domain.Repository
{
    public class VinculoMenuRepository 
    {
        private readonly ApplicationDbContext _context;
        private DbSet<VinculoMenu> entities;
        public VinculoMenuRepository()
        {
            _context = new ApplicationDbContext();
            entities = _context.Set<VinculoMenu>();
        }


        public List<Menu> BuscaMenus(long PerfilId)
        {
            try
            {
                List<Menu> Menus = new List<Menu>();
                IList<VinculoMenu> vincilos = entities
                    .Include(x => x.Menu)
                    .Where(x => x.PerfilId == PerfilId).ToListAsync().Result;

                if (vincilos.Count > 0)
                {
                    foreach (var item in vincilos)
                    {
                        Menus.Add(item.Menu);
                    }
                }

                return Menus;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
        }

    }
}
