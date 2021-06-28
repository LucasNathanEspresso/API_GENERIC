using Crm.Comercial.Domain.Model;
using Crm.Comercial.Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crm.Comercial.Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {


        private readonly ApplicationDbContext _context;
        private DbSet<T> entities;
        public GenericRepository()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            _context = context;
            entities = context.Set<T>();
        }


        public async Task<IList<T>> Buscar()
        {
            try
            {
                return await entities.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }  
        }

        public Task<T> BuscaPorId(long id)
        {
            try
            {
                return entities.FirstOrDefaultAsync(m => m.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
        }

        public T Inserir(T classe)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                
                entities.Add(classe);
                _context.SaveChanges();

                transaction.Commit();
                return classe;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
        }

        public T Editar(long id, T classe)
        {
            using var transaction = _context.Database.BeginTransaction();
            if (id == 0 || classe == null)
            {
                throw new Exception("Erro: Não encontrado objeto");
            }
            try
            {
           
                _context.Entry(classe).State = EntityState.Modified;
                _context.SaveChanges();
                transaction.Commit();
                return classe;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                transaction.Rollback();
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
        }

        public void Deletar(long id)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entityToDelete = entities.FirstOrDefault(e => e.Id == id);
                if (entityToDelete != null)
                {
                    entities.Remove(entityToDelete);
                }
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }

        }
    }
}
