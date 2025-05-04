using HeavyApps.Blog.Domain.Enum;
using HeavyApps.Blog.Domain.Model;

namespace HeavyApps.Blog.Domain.Repository
{
    public interface IPostRepository
    {
        void Add(Post post);
        void Update(Post post);
        void Delete(Guid id);
        Post GetById(Guid id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetByAutor(Guid autorId);
        IEnumerable<Post> GetByStatus(StatusPostEnum status);
    }
}
