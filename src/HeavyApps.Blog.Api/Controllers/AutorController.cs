using Microsoft.AspNetCore.Mvc;
using OpenAPI3.Api.Data;
using OpenAPI3.Api.Models;

namespace OpenAPI3.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class AutorController : Controller
{
    private readonly ILogger<PostsController> _logger;
    private readonly AppDbContext appDbContext;

    public AutorController(ILogger<PostsController> logger, AppDbContext appContext)
    {
        _logger = logger;
        appDbContext = appContext;
    }

    [HttpGet("GetWeatherForecast")]
    public IEnumerable<Autor> GetPosts()
    {
        var posts = appDbContext.Posts.ToList();

        var autores = appDbContext.Autores.ToList();

        return autores;
    }
}
