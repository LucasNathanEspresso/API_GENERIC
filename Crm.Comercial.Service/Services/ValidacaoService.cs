using Crm.Comercial.Domain.Model;
using Crm.Comercial.Domain.Repository;
using Crm.Comercial.Domain.Response;
using Crm.Comercial.Repository;
using Crm.Comercial.Repository.Repository;
using Crm.Comercial.Service.Generic;
using Crm.Comercial.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crm.Comercial.Service.Services
{
    public class ValidacaoService
    {
        protected IGenericRepository<Validacao> repository;
        protected ValicacoRepository _repositoryVld;

        public ValidacaoService()
        {
            repository = new GenericRepository<Validacao>();
            _repositoryVld = new ValicacoRepository();
        }


        public string InserirValidacao(long IdUsuario)
        {
            try
            {
                Validacao validacao = new Validacao();
                validacao.CodValidacao = GerarCodigoValidacaoUsuario(IdUsuario);
                Validacao Val = _repositoryVld.BuscaValidacao(validacao.CodValidacao);

                while (Val != null)
                {
                    validacao.CodValidacao = GerarCodigoValidacaoUsuario(IdUsuario);
                    Val = _repositoryVld.BuscaValidacao(validacao.CodValidacao);
                }



                validacao.DtCadastro = DateTime.Now;
                validacao.UsuarioId = IdUsuario;
                



                //Inserir validaçao
                repository.Inserir(validacao);
                return validacao.CodValidacao;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro ao inserir código de validação", ex.Message));
            }

        }

        public long ValidarCodigo(string codigo)
        {
            Validacao validacao = new Validacao();
            long result = 0;

            try
            {
                validacao = _repositoryVld.BuscaValidacao(codigo);
                if (validacao != null)
                {
                    validacao.DtValidacao = DateTime.Now;

                    if (codigo.Trim() == validacao.CodValidacao.Trim())
                    {
                        repository.Editar(validacao.Id, validacao);
                        result = validacao.UsuarioId;
                    }
                }
            

                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Erro ao registrar data de envio do código de validação", ex.Message));
            }
        }

        public Boolean RegistrarEnvio(string codigo)
        {
            try
            {
                Validacao validacao = new Validacao();
                validacao = _repositoryVld.BuscaValidacao(codigo);
                validacao.DtEnvio = DateTime.Now;
                repository.Editar(validacao.Id, validacao);
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Erro ao registrar data de envio do código de validação", ex.Message));
            }

        }

        private String GerarCodigoValidacaoUsuario(long IdUsuario)
        {
            Random randNum = new Random();
            int codigo = randNum.Next(100000, 999999);

            String CodValidacao = codigo.ToString();

            return CodValidacao;
        }
    }
}
