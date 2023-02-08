using ProiectVisual.Repositories.MemberRepository;

namespace ProiectVisual.UnitOfWork
{
    public interface IUnitOfWork
    {
        IMemberRepository memberRepository { get; }
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
