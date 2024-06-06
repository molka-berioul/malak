using malak.Entities;
using malak.Pagination;

namespace malak.Repositories
{
    public interface ICourRepository
    {
        void DeleteCour(Cour Cour);
        Guid AddCour(Cour Cour);
        Cour GetCour(Guid idCour);
        IList<Cour> GetCour();
        IList<Cour> SearchCour(string nomCour);
        Guid UpdateCour(Cour Cour);
        Guid AddCourOffer(Cour cour);
        PagedResult<Cour> GetCurrentOffredCour(int page, int pageSize);
    }
}
