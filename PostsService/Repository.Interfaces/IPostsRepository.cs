using System;
using System.Collections.Generic;

namespace MicroservicesQuickStart.PostsService.Repository.Interfaces
{
    using Models;

    public interface IPostsRepository
    {
        IEnumerable<Post> All();
        Post Get(int id);
        void Insert(Post post);
        void Update(Post post);
        void Delete(int id);
        bool Save();
    }
}
