using Crm.Comercial.Domain.Model;
using Crm.Comercial.Domain.ViewModel;
using Crm.Comercial.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Comercial.Domain.Repository
{
    public class LoginRepository
    {
        private readonly ApplicationDbContext _context;
        private DbSet<Usuario> entities;
        public LoginRepository()
        {
            _context = new ApplicationDbContext();
            entities = _context.Set<Usuario>();
        }


        public Usuario BuscaLogin(LoginViewModel usr)
        {
            try
            {
                List<Usuario> usuarios = new List<Usuario>();

                usuarios = entities
                    .Include(m => m.Login)
                    .Where(m => m.Login.NomeUsr == usr.NomeUsr && m.FlgAtivo).ToList();


                if (usuarios.Count == 0)
                {
                    usuarios = entities
                   .Include(m => m.Login)
                   .Where(m => (m.Cpf == usr.NomeUsr) && m.FlgAtivo).ToList();

                }

                else if (usuarios.Count == 0)
                {
                    usuarios = entities
                       .Include(m => m.Login)
                       .Where(m => (m.Cnpj == usr.NomeUsr) && m.FlgAtivo).ToList();
                }

                if (usuarios.Count > 0)
                {
                    return usuarios[0];
                }

                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
        }

    }
}
