using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Crm.Comercial.Domain.Model
{
    [Table("TBL_PERFIL")]
    public class Perfil : EntityBase
    {
        public String Flag { get; set; }
        public String Descricao { get; set; }
        public DateTime DtCadastro { get; set; }

    }


}
