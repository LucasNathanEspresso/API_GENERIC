using Crm.Comercial.Api.Controllers.Generic;
using Crm.Comercial.Domain.Model;
using Crm.Comercial.Domain.Response;
using Crm.Comercial.Domain.ViewModel;
using Crm.Comercial.Repository;
using Crm.Comercial.Service.Generic;
using Crm.Comercial.Service.Interfaces;
using Crm.Comercial.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crm.Comercial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        ///  Get all itens 
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/Auth/login")]
        public virtual ResponseModel<UsuarioViewModel> PostCadastro([FromBody] LoginViewModel login)
        {
            LoginService service = new LoginService();
            Usuario usr = new Usuario();

            ResponseModel<UsuarioViewModel> result = new ResponseModel<UsuarioViewModel>();
            try
            {
                result = service.Auth(login);
            }
            catch (Exception e)
            {
                result = new ResponseModel<UsuarioViewModel>();
                string error = e.Message;
                result.success = false;
                result.message.Add(error);
            }
            return result;
        }

    }
}
