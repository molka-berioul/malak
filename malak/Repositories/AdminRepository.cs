using malak.DbContexts;
using malak.Entities;
using Microsoft.EntityFrameworkCore;

namespace malak.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly icfContext icfContext;

        public AdminRepository(icfContext icfContext)
        {
            this.icfContext = icfContext;
        }

        public Guid AddAdmin(Admin Admin)
        {
            icfContext.Admins.Add(Admin);
            icfContext.SaveChanges();
            return Admin.idAdmin;
        }
        public void DeleteAdmin(Admin Admin)
        {
            icfContext.Admins.Remove(Admin);
            icfContext.SaveChanges();
        }
        public Admin GetAdmin(Guid idAdmin)
        {
            return icfContext.Admins.FirstOrDefault(p => p.idAdmin == idAdmin);


        }
        public IList<Admin> GetAdmin()
        {
            return icfContext.Admins.ToList();
        }
    }
}
