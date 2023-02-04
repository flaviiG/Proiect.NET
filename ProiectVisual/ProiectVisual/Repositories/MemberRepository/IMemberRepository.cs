using ProiectVisual.Models;
using ProiectVisual.Repositories.GenericRepository;

namespace ProiectVisual.Repositories.MemberRepository
{
    public interface IMemberRepository : IGenericRepository<Member>
    {
        List<Member> GetAlWithInclude();
        List<Member> GetAlWithJoin();
    }
}
