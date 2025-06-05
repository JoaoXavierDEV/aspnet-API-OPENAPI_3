namespace OpenAPI3.Api.Models
{
    public class Post : EntityBase
    {
        public virtual string Titulo { get; set; }
        public virtual string Corpo { get; set; }
        public virtual int Likes { get; set; } = 0;
        public virtual DateTime DataPublicacao { get; set; }
        public virtual StatusPostEnum Status { get; set; }

        public virtual Autor Autor { get; set; }
        public virtual int AutorID { get; set; }

        public Post()
        {
            Likes = 0;
            Status = StatusPostEnum.Rascunho;
        }
    }

    public enum StatusPostEnum
    {
        Rascunho = 0,
        Publicado = 1,
        Arquivado = 2
    }
}
