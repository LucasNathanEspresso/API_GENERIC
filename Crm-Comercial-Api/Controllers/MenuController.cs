using Crm.Comercial.Api.Controllers.Generic;
using Crm.Comercial.Domain.Model;
using Crm.Comercial.Domain.Response;
using Crm.Comercial.Domain.ViewModel;
using Crm.Comercial.Repository;
using Crm.Comercial.Service.Generic;
using Crm.Comercial.Service.Interfaces;
using Crm.Comercial.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crm.Comercial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : GenericController<Menu>
    {
       
    }
}
