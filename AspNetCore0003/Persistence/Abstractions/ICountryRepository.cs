using System.Linq;
using AspNetCore0003.Persistence.Model;

namespace AspNetCore0003.Persistence.Abstractions
{
    public interface ICountryRepository
    {
        IQueryable<Country> All();
        Country Find(string code);
        IQueryable<Country> AllBy(string filter);
    }
}
