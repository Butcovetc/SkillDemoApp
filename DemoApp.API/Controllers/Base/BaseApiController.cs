using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Monee.RestApi.Controllers.Base
{
    /// <summary>
    /// Basic API controller
    /// </summary>  
    [ApiController]
    [Route("demoSubArea/[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public abstract class BaseApiController : ControllerBase
    {

    }
}