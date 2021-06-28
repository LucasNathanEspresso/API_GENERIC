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
    public class UsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository()
        {
            _context = new ApplicationDbContext();
        }

        public bool NomeUsrExists(string NomeUsr)
        {
            try
            {
                bool result = false;
                if (!string.IsNullOrEmpty(NomeUsr))
                {
                    result = _context.Login.Any(e => e.NomeUsr == NomeUsr.Trim());
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Erro ao verificar Nome de Usuário; ERRO: ", e.Message));
            }
        }

        public bool CpfExists(string Cpf)
        {
            try
            {
                bool result = false;
                if (!string.IsNullOrEmpty(Cpf))
                {
                    result = _context.Usuario.Any(e => e.Cpf == Cpf.Trim());
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Erro ao verificar CPF; ERRO: ", e.Message));
            }
        }

        public bool CnpjExists(string Cnpj)
        {
            try
            {
                bool result = false;
                if (!string.IsNullOrEmpty(Cnpj))
                {
                    result = _context.Usuario.Any(e => e.Cpf == Cnpj.Trim());
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Erro ao verificar CPF; ERRO: ", e.Message));
            }
        }

        public bool EmailExists(string email)
        {
            try
            {
                bool result = false;
                if (!string.IsNullOrEmpty(email))
                {
                    result = _context.Contato.Any(e => e.Email == email.Trim());
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Erro ao verificar Email de Usuário; ERRO: ", e.Message));
            }
        }

    }
}
