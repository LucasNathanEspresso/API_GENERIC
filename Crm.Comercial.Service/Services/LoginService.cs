using Crm.Comercial.Domain.Model;
using Crm.Comercial.Domain.Repository;
using Crm.Comercial.Domain.Response;
using Crm.Comercial.Domain.ViewModel;
using Crm.Comercial.Repository;
using Crm.Comercial.Repository.Repository;
using System;
using System.Collections.Generic;

namespace Crm.Comercial.Service.Services
{
    public class LoginService
    {
        protected LoginRepository repository;
        protected PerfilRepository repositoryPerfil;
        protected VinculoMenuRepository repositoryVinculo;

        public LoginService()
        {

            repositoryPerfil = new PerfilRepository();
            repositoryVinculo = new VinculoMenuRepository();
            repository = new LoginRepository();
        }

        private ResponseModel<UsuarioViewModel> PopularResponse(UsuarioViewModel data, IList<UsuarioViewModel> list, Boolean success, String message)
        {
            ResponseModel<UsuarioViewModel> response = new ResponseModel<UsuarioViewModel>()
            {
                data = data,
                list = list,
                message = new List<string>(),
                success = success
            };
            response.message.Add(message);
            return response;
        }

        public  ResponseModel<UsuarioViewModel> Auth(LoginViewModel usr)
        {
            try
            {
                CryptoUtil Crypto = new CryptoUtil();
                UsuarioViewModel DataResponse = new UsuarioViewModel();
                //Buscar Usuário
                Usuario data =  repository.BuscaLogin(usr);
                string msg;
                //Verificar de a senha é válida
                if (data != null)
                {
                    if (Crypto.ValidarSenha(usr.Senha, data.Login.Senha))
                    {
                        msg = "Usuário válido!";
                        DataResponse.usuario = data;
                        //Buscar perfil e Menus
                        DataResponse.perfil = repositoryPerfil.BuscaPefil(data.PerfilId).Result;
                        DataResponse.Menus = repositoryVinculo.BuscaMenus(DataResponse.perfil.Id);
                        //Obter token
                        TokenService token = new TokenService();
                        DataResponse.access_token = token.GenerateToken(data);
                    }
                    else
                    {
                        msg = "Senha inválida!";
                        return PopularResponse(null, null, false, msg);
                    }
                }
                else
                {
                    msg = "Usuário inválida ou não habilitado!";
                    return PopularResponse(null, null, false, msg);
                }
                return PopularResponse(DataResponse, null, true, msg);
            }
            catch (Exception ex)
            {
                String msg = string.Format("Erro: {0}", ex.Message);
                return PopularResponse(null, null, false, msg);
            }
        }

    }
}
