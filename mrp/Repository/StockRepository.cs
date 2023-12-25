using mrp.Data;
using mrp.Interfaces;

namespace mrp.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly DataContext _context;
        public StockRepository(DataContext context)
        {
            _context = context;
        }
    }
}
