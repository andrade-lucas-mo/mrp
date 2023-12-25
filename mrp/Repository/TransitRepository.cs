using mrp.Data;
using mrp.Interfaces;

namespace mrp.Repository
{
    public class TransitRepository : ITransitRepository
    {
        private readonly DataContext _context;
        public TransitRepository(DataContext context)
        {
            _context = context;
        }
    }
}
