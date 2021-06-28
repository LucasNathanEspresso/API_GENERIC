using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Comercial.Domain.Repository
{
    public interface IGenericRepository<T> 
    {
        public Task<IList<T>> Buscar();
        public Task<T> BuscaPorId(long id);
        public T Inserir(T classe);
        public T Editar(long id, T classe);
        public void Deletar(long id);
    }
}
