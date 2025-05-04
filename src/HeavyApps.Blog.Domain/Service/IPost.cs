using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeavyApps.Blog.Domain.Model;

namespace HeavyApps.Blog.Domain.Service
{
    public interface IPostService
    {
        void Publicar(Post post);


    }
}
