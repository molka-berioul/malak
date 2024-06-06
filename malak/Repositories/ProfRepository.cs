using malak.DbContexts;
using malak.Entities;
using Microsoft.EntityFrameworkCore;

namespace malak.Repositories
{
    public class ProfRepository : IProfRepository
    {
        private readonly icfContext icfContext;

        public ProfRepository(icfContext icfContext)
        {
            this.icfContext = icfContext;
        }

      
        public void DeleteProf(Prof prof)
        {
            icfContext.profs.Remove(prof);
            icfContext.SaveChanges();
        }
        public Guid AddProf(Prof prof)
        {
            icfContext.profs.Add(prof);
            icfContext.SaveChanges();
            return prof.idProf;
        }
        public Prof GetProf(Guid idProf)
        {
            return icfContext.profs.FirstOrDefault(p => p.idProf == idProf);

            throw new NotImplementedException();

        }
        public IList<Prof> GetProf()
        {
            return icfContext.profs.Include(p => p.idProf).ToList();
        }
        public IList<Prof> SearchProf(string NomProf)
        {
            return icfContext.profs.Where(p => p.NomProf.Contains(NomProf)).ToList();
        }


    }
}
