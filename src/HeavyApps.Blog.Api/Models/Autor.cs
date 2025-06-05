namespace OpenAPI3.Api.Models;
public class Autor : EntityBase
{
    public virtual string Nome { get; set; }
    public virtual string Email { get; set; }
    public virtual List<Post> Posts { get; set; } = new List<Post>();

    public Autor()
    {

    }

    private void AddPost(Post post)
    {
        ArgumentNullException.ThrowIfNull(post);

        if (Posts == null) Posts = new List<Post>();

        Posts.Add(post);
    }

}
