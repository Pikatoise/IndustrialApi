using Loading.Domain.Models;

namespace Loading.DAL.Interfaces
{
    public interface IPostRepository: IBaseRepository<Post>
    {
        public Post? GetById(int id);   
    }
}
