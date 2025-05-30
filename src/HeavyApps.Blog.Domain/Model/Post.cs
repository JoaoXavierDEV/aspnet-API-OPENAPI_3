using HeavyApps.Blog.Domain.Enum;

namespace HeavyApps.Blog.Domain.Model
{
    public class Post : EntityBase
    {
        public virtual string Titulo { get; set; }
        public virtual string SubTitulo { get; set; }
        public virtual string Corpo { get; set; }
        public virtual DateTime DataPublicacao { get; }
        public virtual string Fonte { get; set; }

        public virtual Autor Autor { get; set; }
        public virtual Guid AutorID { get; set; }

        public virtual string Imagem { get; set; }
        public virtual string Categoria { get; set; }
        public virtual string Resumo { get; set; }
        public virtual string Link { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public List<string> Tags { get; set; }
        public virtual StatusPostEnum Status { get; private set; }

        public Post()
        {
            Status = StatusPostEnum.Pendente;
        }

    }
}
