using Microsoft.EntityFrameworkCore;
using ProiectVisual.Data;
using ProiectVisual.Models;
using ProiectVisual.Repositories.GenericRepository;

namespace ProiectVisual.Repositories.MemberRepository
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(Context context) : base(context)
        {

        }
        public List<Member> GetAlWithInclude()
        {
            return _table.Include(x => x.Department).Include(x => x.ModelsRelation).ToList();
        }

        public List<Member> GetAlWithJoin()
        {
            var result = _table.Join(_context.Departments, member => member.DepartmentId, dep => dep.Id,
                (member, dep) => new { member, dep }).Select(obj => obj.member);

            return result.ToList();
        }

        public List<Member> GetByStatus(string status)
        {
            var result = from member in _table
                         where member.Status == status
                         select member;
            return result.ToList<Member>();
        }
        
        public Member GetById(int id)
        {
            return _table.FirstOrDefault(x => x.Id.Equals(id));

        }
    }
}
