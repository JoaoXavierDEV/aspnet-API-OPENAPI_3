using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HeavyApps.Blog.Presentation.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected ILogger? _logger;
    }

}
