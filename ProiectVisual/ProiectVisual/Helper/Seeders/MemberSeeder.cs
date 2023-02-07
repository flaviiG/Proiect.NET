using ProiectVisual.Data;
using ProiectVisual.Models;

namespace ProiectVisual.Helper.Seeders
{
    public class MemberSeeder
    {
        public readonly Context _context;

        public MemberSeeder(Context context)
        {
            _context = context;
        }

        public void seedInitialMembers()
        {
            if(!_context.Members.Any())
            {
                var member1 = new Member
                {
                    First_Name = "David",
                    Last_Name = "Pham",
                    Status = "VIP",
                    DepartmentId = 1
                };
                var member2 = new Member
                {
                    First_Name = "Vavalutzu",
                    Last_Name = "Lescai",
                    Status = "VIP",
                    DepartmentId = 1
                };
                _context.Members.Add(member1);
                _context.Members.Add(member2);

                _context.SaveChanges();
            }
        }
    }
}
