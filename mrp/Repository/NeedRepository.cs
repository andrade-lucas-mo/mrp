using mrp.Data;
using mrp.Interfaces;

namespace mrp.Repository
{
    public class NeedRepository : INeedRepository
    {
        private readonly DataContext _context;
        public NeedRepository(DataContext context)
        {
            _context = context;
        }
    }
}
