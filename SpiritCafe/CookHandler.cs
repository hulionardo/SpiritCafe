using SpiritCafe.Data;
using SpiritCafe.Entities;

namespace SpiritCafe;

public class CookHandler
    {
        private readonly OrderingSystemContext _context;

        public CookHandler(OrderingSystemContext context)
        {
            _context = context;
        }
    }