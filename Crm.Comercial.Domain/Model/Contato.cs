using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Comercial.Domain.Model
{
    [Table("TBL_CONTATO")]
    public class Contato : EntityBase
    {
        [Required, MaxLength(200)]
        public String Email { get; set; }
        [Required, MaxLength(3)]
        public String DD { get; set; }
        [Required, MaxLength(9)]
        public String NumTelefone { get; set; }
    }
}
