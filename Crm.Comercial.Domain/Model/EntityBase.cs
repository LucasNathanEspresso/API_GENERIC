using Crm.Comercial.Domain.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Crm.Comercial.Domain.Model
{
    public class EntityBase : IEntityBase
    {
        [Key]
        public long Id { get; set; }
    }
}
