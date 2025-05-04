using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyApps.Blog.Domain.Model;
public class Autor : EntityBase
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Biografia { get; set; }

    public List<Post> Posts { get; set; } = new List<Post>();

}
