using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Crm.Comercial.Domain.Model
{
    [Table("TBL_MENU")]
   public class Menu : EntityBase
    {
        public String Path { get; set; }
        public String Title { get; set; }
        public String Icon { get; set; }
        public String Classe { get; set; }
        public Boolean Visible { get; set; }
        public String IconColor { get; set; }
        public Boolean FlagAtivo { get; set; }

    }
}
