using BookStore.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Data.Services
{
    public class LogsService
    {
        // reference to the
        // db context:
        private AppDbContext _context;

        public LogsService(AppDbContext context)
        {
            _context = context;
        }

        public List<Log> GetAllLogs()
        {
            var logs = _context.Logs.ToList();
            return logs;
        }
            
    }
}
