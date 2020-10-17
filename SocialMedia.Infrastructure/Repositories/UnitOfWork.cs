using SocialMedia.Core.Data;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialMediaContext _socialMediaContext;
        private readonly IRepository<Post> _postRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Comment> _commentRepository;
        public UnitOfWork(SocialMediaContext socialMediaContext)
        {
            _socialMediaContext = socialMediaContext;
        }
        public IRepository<Post> PostRepository => _postRepository ?? new BaseRepository<Post>(_socialMediaContext);

        public IRepository<User> UserRepository => _userRepository ?? new BaseRepository<User>(_socialMediaContext);

        public IRepository<Comment> CommentRepository => _commentRepository ?? new BaseRepository<Comment>(_socialMediaContext);

        public void Dispose()
        {
            if (_socialMediaContext != null)
            {
                _socialMediaContext.Dispose();
            }
        }

        public void SaveChanges()
        {
            _socialMediaContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _socialMediaContext.SaveChangesAsync();
        }
    }
}
