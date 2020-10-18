﻿using SocialMedia.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostService
    {
        IEnumerable<Post> GetPosts();
        Task<Post> GetPostByPostId(int id);
        Task InsertPost(Post post);
       
        Task<bool> UpdatePost(Post post);
        Task<bool> DeletePost(int id);
    }
}