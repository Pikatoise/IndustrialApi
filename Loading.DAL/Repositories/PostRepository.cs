using Loading.DAL.Interfaces;
using Loading.Domain.Models;

namespace Loading.DAL.Repositories
{
    public class PostRepository: BaseRepository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public Post? GetById(int id) =>
            _appDbContext.Set<Post>().Where(x => x.Id == id).FirstOrDefault();
    }
}
