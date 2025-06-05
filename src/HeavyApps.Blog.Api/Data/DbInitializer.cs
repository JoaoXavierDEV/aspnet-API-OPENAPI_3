using OpenAPI3.Api.Models;

namespace OpenAPI3.Api.Data;

public static class DbInitializer
{

    public static readonly List<Autor> Autores = new List<Autor>
        {
            new Autor { ID= 500 , Nome = "João", Email = "joao@outlook.com", Posts = new List<Post>
                {
                    new Post
                    {
                        ID = 1,
                        Titulo = "Primeiro Post",
                        Corpo = "Conteúdo do primeiro post",
                        DataPublicacao = DateTime.Now,
                        Status = StatusPostEnum.Publicado,
                    },
                    new Post
                    {
                        ID = 2,
                        Titulo = "Segundo Post",
                        Corpo = "Conteúdo do segundo post",
                        DataPublicacao = DateTime.Now.AddDays(-80),
                        Status = StatusPostEnum.Rascunho,
                    }
                }},
            new Autor { ID = 98, Nome = "Alexandre", Email = "ale@gmail.com" },
            new Autor { ID = 41 ,Nome = "Caio", Email = "caio@outlook.com" },
        };

    public static readonly List<Post> Posts = new List<Post>
        {
            new Post
            {
                Titulo = "Terceiro Post",
                Corpo = "Conteúdo do terceiro post",


                DataPublicacao = DateTime.Now.AddDays(-20),

            },
            new Post
            {
                Titulo = "Quarto Post",
                Corpo = "Conteúdo do quarto post",

                DataPublicacao = DateTime.Now.AddDays(-30),

            }
        };


}
