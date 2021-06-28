using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Crm.Comercial.Domain.Model
{
    [Table("TBL_VALIDACAO")]
    public class Validacao : EntityBase
    {
        [Required]
        public string CodValidacao { get; set; }
        [Required]
        public DateTime DtCadastro { get; set; }
        public DateTime DtEnvio { get; set; }
        public DateTime DtValidacao { get; set; }
        [Required]
        public long UsuarioId { get; set; }
    }
}
