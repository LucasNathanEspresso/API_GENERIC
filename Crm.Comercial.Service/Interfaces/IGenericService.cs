using Crm.Comercial.Domain.Model;
using Crm.Comercial.Domain.Response;
using System.Threading.Tasks;

namespace Crm.Comercial.Service.Interfaces
{
    public interface IGenericService<T> where T : EntityBase
    {
        public Task<ResponseModel<T>> Buscar();
        public Task<ResponseModel<T>> BuscaPorId(long id);
        public ResponseModel<T> Cadastar(T classe);
        public ResponseModel<T> Editar(long id, T classe);
        public ResponseModel<T> Deletar(long id);
    }
}
