using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Crm.Comercial.Domain.Model
{
    [Table("TBL_VINCULO_MENU")]
    public class VinculoMenu : EntityBase
    {

        [ForeignKey("TBL_MENU")]
        public long MenuId { get; set; }
        public Menu Menu { get; set; }

        public long? PerfilId { get; set; }


       

        [Required]
        public Boolean Visualizar { get; set; }
        [Required]
        public Boolean Criar { get; set; }
        [Required]
        public Boolean Editar { get; set; }
        [Required]
        public Boolean Deletar { get; set; }

    }
}
