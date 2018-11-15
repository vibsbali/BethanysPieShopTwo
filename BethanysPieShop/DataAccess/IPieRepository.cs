using System.Collections.Generic;
using BethanysPieShop.Models;

namespace BethanysPieShop.DataAccess
{
    public interface IPieRepository
    {
        IEnumerable<Pie> GetAllPies();

        Pie GetPieById(int pieId);
    }
}
