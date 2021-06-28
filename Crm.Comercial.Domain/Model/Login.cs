using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Crm.Comercial.Domain.Model
{
    [Table("TBL_LOGIN")]
    public class Login : EntityBase
    {

        [Required, MaxLength(100)]
        public String NomeUsr { get; set; }

        [MaxLength(200), DataType(DataType.Password), Required]
        public String Senha { get; set; }


    }
}
