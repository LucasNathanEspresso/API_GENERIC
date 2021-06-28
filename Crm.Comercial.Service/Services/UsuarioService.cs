using Crm.Comercial.Domain.Model;
using Crm.Comercial.Domain.Repository;
using Crm.Comercial.Domain.Response;
using Crm.Comercial.Repository;
using Crm.Comercial.Repository.Repository;
using Crm.Comercial.Service.Generic;
using Crm.Comercial.Service.Interfaces;
using Crm.Comercial.Utility.Email;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crm.Comercial.Service.Services
{
    public class UsuarioService
    {
        protected IGenericRepository<Usuario> repository;
        protected UsuarioRepository _repositoryUsr;
        protected ValidacaoService _repositoryVld;
        public UsuarioService()
        {
            repository = new GenericRepository<Usuario>();
            _repositoryUsr = new UsuarioRepository();
            _repositoryVld = new ValidacaoService();
        }

        private ResponseModel<Usuario> PopularResponse(Usuario data, IList<Usuario> list, Boolean success, String message)
        {
            ResponseModel<Usuario> response = new ResponseModel<Usuario>()
            {
                data = data,
                list = list,
                message = new List<string>(),
                success = success
            };
            response.message.Add(message);
            return response;
        }

        public ResponseModel<Usuario> Cadastar(Usuario usr)
        {
            try
            {
                String msg;
                if (_repositoryUsr.NomeUsrExists(usr.Login.NomeUsr))
                {
                    msg = "Nome de usuário indisponível!";
                    return PopularResponse(null, null, false, msg);
                }
                else if (_repositoryUsr.CpfExists(usr.Cpf))
                {
                    msg = " Cpf já Cadastrado!";
                    return PopularResponse(null, null, false, msg);
                }
                else if (_repositoryUsr.CnpjExists(usr.Cnpj))
                {
                    msg = " CNPJ já Cadastrado!";
                    return PopularResponse(null, null, false, msg);
                }
                else if (_repositoryUsr.EmailExists(usr.Contato.Email))
                {
                    msg = " E-mail já Cadastrado!";
                    return PopularResponse(null, null, false, msg);
                }
                ////============================= SALVAR USUÁRIO =====================================
                Usuario data = new Usuario();
                try
                {
                    CryptoUtil Crypto = new CryptoUtil();
                    usr.Login.Senha = Crypto.Criptografar(usr.Login.Senha);
                    usr.FlgAtivo = false;
                    usr.PerfilId = 1;
                    usr.DtCadastro = DateTime.Now;
                    //SALVAR USUÁRIO
                    data = repository.Inserir(usr);
                }
                catch (Exception ex)
                {
                    msg = string.Format("Erro ao salvar novo usuário! MSG: {0}", ex.Message);
                    return PopularResponse(data, null, true, msg);
                }

                ///==========================================================
                
                //INSERIR VALIDAÇÃO
                String codigo = _repositoryVld.InserirValidacao(usr.Id);
                //ENVIAR EMAIL COM O CÓDIGO DE VALIDAÇÃO
                try
                {
                    Email email = new Email();
                    String MsgEmail = string.Format("CÓDIGO DE VALIDAÇÃO: {0}", codigo);
                    email.EnviarEmail(MsgEmail, data.Contato.Email);

                    //REGISTRAR A DATA DE ENVIO DO CÓDIGO DE VALÍDAÇÃO
                    _repositoryVld.RegistrarEnvio(codigo);
                }
                catch (Exception)
                {

                    msg = "Cadastrado com Sucesso! Erro ao enviar email";
                    return PopularResponse(data, null, true, msg);
                }


                msg = "Cadastrado com Sucesso! Código de válidação enviado ao e-mail do usuário.";
                return PopularResponse(data, null, true, msg);
            }
            catch (Exception ex)
            {
                String msg = string.Format("Erro: {0}", ex.Message);
                return PopularResponse(null, null, false, msg);
            }
        }

        public ResponseModel<Usuario> HabilitarUsuario(string Codigo)
        {
            String msg;
            try
            {
                long UsuarioId = _repositoryVld.ValidarCodigo(Codigo);
                if (UsuarioId > 0)
                {
                    Usuario usr = repository.BuscaPorId(UsuarioId).Result;
                    if (usr != null)
                    {
                        usr.FlgAtivo = true;
                        repository.Editar(usr.Id, usr);
                        msg = "Habilitado com Sucesso";
                        return PopularResponse(null, null, true, msg);
                    }
                    else
                    {
                        msg = "Código inválido!";
                        return PopularResponse(null, null, true, msg);
                    }

                }
                else
                {
                    msg = "Código inválido!";
                    return PopularResponse(null, null, false, msg);
                }
            }
            catch (Exception ex)
            {
                 msg = string.Format("Erro ao habilitar usuário: MSG: {0}", ex.Message);
                return PopularResponse(null, null, false, msg);
            }
        }

    }
}
