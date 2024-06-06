using malak.Entities;

namespace malak.Repositories
{
    public interface IAdminRepository
    {
        Guid AddAdmin(Admin Admin);
        Admin GetAdmin(Guid idAdmin);
        IList<Admin> GetAdmin();
        void DeleteAdmin(Admin Admin);
    }
}
