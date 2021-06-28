using Crm.Comercial.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Comercial.Domain.ViewModel
{
   public class UsuarioViewModel
    {
        public Usuario usuario { get; set; }
        public Perfil perfil { get; set; }
        public List<Menu> Menus { get; set; }
        public string access_token { get; set; }
    }
}
