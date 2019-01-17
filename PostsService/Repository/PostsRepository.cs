using System;
using System.Linq;

namespace TVX.Test.PostsService.Repository
{
    using System.Collections.Generic;
    using Interfaces;
    using TVX.Test.PostsService.Models;

    public class PostsRepository : IPostsRepository
    {
        private readonly List<Post> storage;
        private readonly object syncRoot;

        public PostsRepository()
        {
            storage = new List<Post>();
            syncRoot = new object();
        }

        public IEnumerable<Post> All()
        {
            lock (syncRoot)
            {
                Post[] copy = new Post[storage.Count];
                storage.CopyTo(copy);
                return copy.AsEnumerable();
            }
        }

        public Post Get(int id)
        {
            lock (syncRoot)
            {
                return storage.SingleOrDefault(post => post.Id == id);
            }
        }

        public void Insert(Post post)
        {
            lock (syncRoot)
            {
                if (!storage.Any(p => p.Id == post.Id))
                {
                    storage.Add(post);
                }
            }
        }


        public void Update(Post post)
        {
            lock (syncRoot)
            {
                if (storage.Any(p => p.Id == post.Id))
                {
                    var index = storage.FindIndex(p => p.Id == post.Id);
                    storage[index] = null;
                    storage[index] = post;
                }
                else
                {
                    storage.Add(post);
                }
            }
        }

        public void Delete(int id)
        {
            lock (syncRoot)
            {
                if (storage.Any(post => post.Id == id))
                {
                    storage.RemoveAll(post => post.Id == id);
                }
            }
        }

        public bool Save()
        {
            return true;
        }
    }
}
