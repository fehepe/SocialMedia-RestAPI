using SocialMedia.Core.Data;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialMediaContext _socialMediaContext;
        private readonly IPostRepository _postRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Comment> _commentRepository;        
        private readonly ISecurityRepository _securityRepository;

        public UnitOfWork(SocialMediaContext socialMediaContext)
        {
            _socialMediaContext = socialMediaContext;
        }
        public IPostRepository PostRepository => _postRepository ?? new PostRepository(_socialMediaContext);

        public IRepository<User> UserRepository => _userRepository ?? new BaseRepository<User>(_socialMediaContext);

        public IRepository<Comment> CommentRepository => _commentRepository ?? new BaseRepository<Comment>(_socialMediaContext);
        public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_socialMediaContext);

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
