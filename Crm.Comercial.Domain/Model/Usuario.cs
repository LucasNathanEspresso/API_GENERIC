using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Crm.Comercial.Domain.Model
{
    [Table("TBL_USUARIO")]
    public class Usuario : EntityBase
    {
        public String Nome { get; set; }
        public String Cpf { get; set; }
        public String Cnpj { get; set; }
        public String NomeFatasia { get; set; }
        public DateTime DtNascimento { get; set; }
        [Required]
        public DateTime DtCadastro { get; set; }

        public Boolean FlgAtivo { get; set; }

        [ForeignKey("TBL_LOGIN"), Required]
        public long? LoginId { get; set; }
        public virtual Login Login { get; set; }

        [ForeignKey("TBL_CONTATO")]
        public long? ContatoId { get; set; }
        public virtual Contato Contato { get; set; }

        [ForeignKey("TBL_PERFIL")]
        public long PerfilId { get; set; }



    }
}
