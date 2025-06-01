using FluentAssertions;
using HeavyApps.Blog.Domain.Model;

namespace HeavyApps.Blog.Domain.Tests;

public class AutorTests
{
    [Fact(DisplayName = "Create Autor With Valid State")]
    public void CreateAutor_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Autor("Joao", "joao@outlook.com", "Biografia");

        action.Should()
             .NotThrow<HeavyApps.Blog.Domain.Exceptions.DomainExceptionValidation>();
    }
}
