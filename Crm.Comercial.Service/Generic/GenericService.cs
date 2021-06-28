using Crm.Comercial.Domain.Model;
using Crm.Comercial.Domain.Repository;
using Crm.Comercial.Domain.Response;
using Crm.Comercial.Repository;
using Crm.Comercial.Repository.Repository;
using Crm.Comercial.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Comercial.Service.Generic
{
   public class GenericService<T> : IGenericService<T> where T : EntityBase
    {
        protected IGenericRepository<T> repository;


        public GenericService()
        {
            repository = new GenericRepository<T>();

        }

        private ResponseModel<T> PopularResponse(T data, IList<T> list,  Boolean success,String message)
        {
            ResponseModel<T> response = new ResponseModel<T>()
            {
                data = data,
                list = list,
                message = new List<string>(),
                success = success
            };
            response.message.Add(message);
            return response;
         }

        public async Task<ResponseModel<T>> Buscar()
        {
            try
            {
                IList<T> list = await repository.Buscar();
                String msg = "Consulta realizada com sucesso!";
                return PopularResponse(null, list, true, msg);
            }
            catch (Exception ex)
            {
                String msg = string.Format("Erro: {0}", ex.Message);
                return PopularResponse(null, null, false, msg);
            }
        }

        public async Task<ResponseModel<T>> BuscaPorId(long id)
        {
            try
            {
                T data = await repository.BuscaPorId(id);
                String msg = "Consulta realizada com sucesso!";
                return PopularResponse(data, null, true, msg);
            }
            catch (Exception ex)
            {
                String msg = string.Format("Erro: {0}", ex.Message);
                return PopularResponse(null, null, false, msg);
            }
        }

        public ResponseModel<T> Cadastar(T classe)
        {
            try
            {
                T data = repository.Inserir(classe);
                String msg = "Cadastrado com Sucesso!";
                return PopularResponse(data, null, true, msg);
            }
            catch (Exception ex)
            {
                String msg = string.Format("Erro: {0}", ex.Message);
                return PopularResponse(null, null, false, msg);
            }
        }

        public ResponseModel<T> Editar(long id, T classe)
        {
            try
            {
                T data = repository.Editar(id, classe);
                String msg = "Editado com sucesso!";
                return PopularResponse(data, null, true, msg);
            }
            catch (Exception ex)
            {
                String msg = string.Format("Erro: {0}", ex.Message);
                return PopularResponse(null, null, false, msg);
            }
        }

        public ResponseModel<T> Deletar(long id)
        {
            try
            {
                repository.Deletar(id);
                String msg = "Deletado com sucesso!";

                return PopularResponse(null, null, true, msg);
            }
            catch (Exception ex)
            {
                String msg = string.Format("Erro: {0}", ex.Message);
                return PopularResponse(null, null, false, msg);
            }

        }
    }


}
