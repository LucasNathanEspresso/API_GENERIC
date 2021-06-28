using Crm.Comercial.Api.Controllers.Generic;
using Crm.Comercial.Domain.Model;
using Crm.Comercial.Domain.Response;
using Crm.Comercial.Repository;
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
    public class UsuarioController : GenericController<Usuario>
    {
        [HttpPost]
        [Route("/Cadastro")]
        public virtual ActionResult<ResponseModel<Usuario>> PostCadastro([FromBody] Usuario classe)
        {
            UsuarioService service = new UsuarioService();

            ResponseModel<Usuario> result = new ResponseModel<Usuario>();
            try
            {
                result = service.Cadastar(classe);
            }
            catch (Exception e)
            {
                result = new ResponseModel<Usuario>();
                string error = e.Message;
                result.success = false;
                result.message.Add(error);
            }
            return result;
        }


        [HttpGet]
        [Route("/Habilitar/{codigo}")]
        public virtual ActionResult<ResponseModel<Usuario>> PostHabilitar(String codigo)
        {
            UsuarioService service = new UsuarioService();

            ResponseModel<Usuario> result = new ResponseModel<Usuario>();
            try
            {
                result = service.HabilitarUsuario(codigo);
            }
            catch (Exception e)
            {
                result = new ResponseModel<Usuario>();
                string error = e.Message;
                result.success = false;
                result.message.Add(error);
            }
            return result;
        }


    }
}
