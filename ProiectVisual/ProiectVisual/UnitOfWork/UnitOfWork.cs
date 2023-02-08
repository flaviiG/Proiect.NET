using ProiectVisual.Data;
using ProiectVisual.Repositories.MemberRepository;

namespace ProiectVisual.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private IMemberRepository _memberRepository;    

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public IMemberRepository memberRepository
        {
            get { return _memberRepository = _memberRepository ?? new MemberRepository(_context); }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            _context.Dispose();
        }

        public async Task RollbackAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
