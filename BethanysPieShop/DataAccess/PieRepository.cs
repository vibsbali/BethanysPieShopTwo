using System.Collections.Generic;
using System.Linq;
using BethanysPieShop.Models;

namespace BethanysPieShop.DataAccess
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext _context;

        public PieRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Pie> GetAllPies()
        {
            return _context.Pies;
        }

        public Pie GetPieById(int pieId)
        {
            return _context.Pies.SingleOrDefault(p => p.Id == pieId);
        }
    }
}
