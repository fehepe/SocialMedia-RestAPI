using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Data;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(SocialMediaContext socialMediaContext) : base (socialMediaContext){}
        public async Task<IEnumerable<Post>> GetPostsByUserId(int userId)
        {
            return await _entities.Where(x => x.UserId == userId).ToListAsync();
        }



    }


}
