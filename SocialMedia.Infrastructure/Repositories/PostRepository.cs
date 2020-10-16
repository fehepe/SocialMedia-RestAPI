using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Data;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialMediaContext _context;

        public PostRepository(SocialMediaContext context)
        {
            _context = context;
        }

        public async Task<Post> GetPostByPostId(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.PostId == id);
            return post;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await _context.Posts.ToListAsync();

            return posts;
        }

        public async Task InsertPost(Post post)
        {
            _context.Posts.Add(post);
        }

        public async Task<bool> SaveChanges()
        {
            var rows = await _context.SaveChangesAsync();

            return (rows > 0);
        }

        public async Task<bool> UpdatePost(Post post)
        {
            var currentPost = await GetPostByPostId(post.PostId);

            currentPost.Date = post.Date;
            currentPost.Description = post.Description;            
            currentPost.Image = currentPost.Image;

            var result = await SaveChanges();

            return result;            
        }

        public async Task<bool> DeletePost(int id)
        {
            var currentPost = await GetPostByPostId(id);
            _context.Remove(currentPost);

            var result = await SaveChanges();

            return result;
        }
    }
}
