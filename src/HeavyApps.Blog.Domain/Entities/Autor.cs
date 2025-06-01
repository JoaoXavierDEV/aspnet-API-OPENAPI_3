using HeavyApps.Blog.Domain.Exceptions;

namespace HeavyApps.Blog.Domain.Model;
public class Autor : EntityBase
{
    public virtual string Nome { get; set; }
    public virtual string Email { get; set; }
    public virtual string Biografia { get; set; }
    public virtual List<Post> Posts { get; set; } = new List<Post>();

    public Autor()
    {

    }

    public Autor(string nome, string email, string biografia)
    {
        Validate(nome, email);

        Nome = nome;
        Email = email;
        Biografia = biografia;
    }

    public Autor(string nome, string email, string biografia, List<Post> posts)
    {
        Nome = nome;
        Email = email;
        Biografia = biografia;
        Posts = posts;
    }

    private void AddPost(Post post)
    {
        ArgumentNullException.ThrowIfNull(post);

        if (Posts == null) Posts = new List<Post>();

        Posts.Add(post);
    }

    private void Validate(string nome, string email)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome com espaço vazio");

        DomainExceptionValidationEnitites.ThrowIfNullOrWhiteSpace(Email, "Email vazio");

        //ArgumentNullException.ThrowIfNull(Biografia, nameof(Biografia));
        //if (Posts == null) Posts = new List<Post>();
    }


}
