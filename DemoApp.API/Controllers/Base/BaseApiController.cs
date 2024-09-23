using System.Net.Mime;
using DemoApp.Model.Dal;
using DemoApp.Model.Dal.Requests.Base;
using DemoApp.Model.Dal.Response.Base;
using DemoApp.Model.Exceptions;
using DemoApp.Model.Exceptions.Critical;
using DemoApp.Model.Units.Base;
using DemoApp.Model.Utils.Factories;
using Microsoft.AspNetCore.Mvc;

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