using Crm.Comercial.Domain.Model;
using Crm.Comercial.Domain.Response;
using Crm.Comercial.Repository;
using Crm.Comercial.Service.Generic;
using Crm.Comercial.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Crm.Comercial.Api.Controllers.Generic
{


    /// <summary>
    /// CONTROLLER BASE DA APLICAÇÃO
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericController<T> : ControllerBase where T : EntityBase
    {
 
        /// <summary>
        /// Buscar todos objetos cadastrado
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public virtual async Task<ActionResult<ResponseModel<T>>> Get()
        {
            IGenericService<T> service = new GenericService<T>();

            ResponseModel<T> result = new ResponseModel<T>();
            try
            {
                result = await service.Buscar();
            }
            catch (Exception e)
            {
                result = new ResponseModel<T>();
                string error = e.Message;
                result.success = false;
                result.message.Add(error);
            }
            return result;
        }

        /// <summary>
        /// Buscar Objeto por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public virtual async Task<ActionResult<ResponseModel<T>>> GetBuscarPorId(long id)
        {
            IGenericService<T> service = new GenericService<T>();
            ResponseModel<T> result = new ResponseModel<T>();
            try
            {
                if (id > 0)
                {
                    result = await service.BuscaPorId(id);
                }
                else
                {
                    string error = "ID inválido!";
                    result.success = false;
                    result.message.Add(error);
                }
                
            }
            catch (Exception e)
            {
                string error = e.Message;
                result.success = false;
                result.message.Add(error);
            }
            return result;
        }

        /// <summary>
        ///  Get all itens 
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public virtual ActionResult<ResponseModel<T>> Post([FromBody] T classe)
        {
            IGenericService<T> service = new GenericService<T>();

            ResponseModel<T> result = new ResponseModel<T>();
            try
            {
                result = service.Cadastar(classe);
            }
            catch (Exception e)
            {
                result = new ResponseModel<T>();
                string error = e.Message;
                result.success = false;
                result.message.Add(error);
            }
            return result;
        }

        /// <summary>
        /// Editar objeto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="classe"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        [Route("{id}")]
        public virtual ActionResult<ResponseModel<T>> Put(long id, T classe)
        {
            IGenericService<T> service = new GenericService<T>();
            ResponseModel<T> result = new ResponseModel<T>();
            try
            {
                if (id > 0 && classe != null)
                {
                    result = service.Editar(id, classe);
                }
                else
                {
                    string error = "Id ou objeto inválido!";
                    result.success = false;
                    result.message.Add(error);
                }

            }
            catch (Exception e)
            {
                string error = e.Message;
                result.success = false;
                result.message.Add(error);
            }
            return result;
        }

        /// <summary>
        /// Deletar objeto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public virtual ActionResult<ResponseModel<T>> Delete(long id)
        {
            IGenericService<T> service = new GenericService<T>();
            ResponseModel<T> result = new ResponseModel<T>();
            try
            {
                if (id > 0)
                {
                    result = service.Deletar(id);
                }
                else
                {
                    string error = "Id inválido!";
                    result.success = false;
                    result.message.Add(error);
                }

            }
            catch (Exception e)
            {
                string error = e.Message;
                result.success = false;
                result.message.Add(error);
            }
            return result;
        }

    }
}
