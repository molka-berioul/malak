using malak.Entities;

namespace malak.Repositories
{
    public interface IProfRepository
    {
        void DeleteProf(Prof Prof);
        Guid AddProf(Prof Prof);
        Prof GetProf(Guid idProf);
        IList<Prof> GetProf();
        IList<Prof> SearchProf(string NomProf);
    }
}
