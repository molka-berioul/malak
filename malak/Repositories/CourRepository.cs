using malak.DbContexts;
using malak.Entities;
using malak.Pagination;
using Microsoft.EntityFrameworkCore;

namespace malak.Repositories
{
    public class CourRepository : ICourRepository
    {
        private readonly icfContext icfContext;

        public CourRepository(icfContext icfContext)
        {
            this.icfContext = icfContext;
        }

        public void DeleteCour(Cour Cour)
        {
            icfContext.cours.Remove(Cour);
            icfContext.SaveChanges();
        }
        public Guid AddCour(Cour Cour)
        {
            icfContext.cours.Add(Cour);
            icfContext.SaveChanges();
            return Cour.idCour;
        }
        public Cour GetCour(Guid idCour)
        {
            return icfContext.cours.FirstOrDefault(p => p.idCour == idCour);
            

        }
        public IList<Cour> GetCour()
        {
            return icfContext.cours.Include(p => p.NomCour).ToList();
        }
        public IList<Cour> SearchCour(string nomCour)
        {
            return icfContext.cours.Where(p => p.NomCour.Contains(nomCour)).ToList();
        }

        public Guid UpdateCour(Cour Cour)
        {
            icfContext.cours.Update(Cour);
            icfContext.SaveChanges();
            return Cour.idCour;

        }
        public PagedResult<Cour> GetCurrentOffredCour(int page, int pageSize)
        {
            return icfContext.cours.Where(c => c.IsOffred == true)
                .Where(a => a.StarTime < DateTime.Now)
                .Where(a => a.EndTime > DateTime.Now)
                .GetPaged(page, pageSize);
        }
        public Guid AddCourOffer(Cour Cour)
        {
            icfContext.cours.Add(Cour);
            icfContext.SaveChanges();
            return Cour.idCour;

        }
    }
}
