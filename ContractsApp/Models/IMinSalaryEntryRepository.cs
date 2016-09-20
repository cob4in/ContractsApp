using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContractsApp.Models
{
    public interface IMinSalaryEntryRepository : IRepository<MinSalaryEntry, int>
    {
        IEnumerable<MinSalaryEntry> FindAll();
    }
}