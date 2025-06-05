using Microsoft.AspNetCore.Mvc;
using OpenAPI3.Api.Data;
using OpenAPI3.Api.Models;

namespace OpenAPI3.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class PostsController : Controller
{
    private readonly ILogger<PostsController> _logger;
    private readonly AppDbContext appDbContext;

    public PostsController(ILogger<PostsController> logger, AppDbContext appContext)
    {
        _logger = logger;
        appDbContext = appContext;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<Post> GetPosts()
    {
        var posts = appDbContext.Posts.ToList();

        var autores = appDbContext.Autores.ToList();

        return posts;
    }
}
