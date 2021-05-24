using EnterprisesX.API.Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnterprisesX.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion(Constants.API_VERSION_V1, Deprecated = false)]
    public class PermissionController : ControllerBase
    {

    }
}
