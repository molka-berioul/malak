using malak.DbContexts;
using malak.Entities;

namespace malak.Repositories
{
    public class CentreRepository : ICentreRepository
    {
        private readonly icfContext icfContext;

        public CentreRepository(icfContext icfContext)
        {
            this.icfContext = icfContext;
        }
        public Guid AddCentre(Centre Centre)
        {
            icfContext.centres.Add(Centre);
            icfContext.SaveChanges();
            return Centre.idCentre;
        }
    }
}
