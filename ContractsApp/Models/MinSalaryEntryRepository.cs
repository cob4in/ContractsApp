using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContractsApp.Models
{
    public class MinSalaryEntryRepository : IMinSalaryEntryRepository
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        public IEnumerable<MinSalaryEntry> FindAll()
        {
            return _dbContext.MinSalaryEntries.ToList();
        }
    }
}