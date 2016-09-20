using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContractsApp.Models
{
    public class ContractRepository : IContractRepository
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();

        public int ContractNameOccurences(string name)
        {
            return _dbContext.Contracts.Count(x => x.Name.ToUpper() == name.ToUpper());
        }

        public IEnumerable<Contract> FindAll()
        {
            return _dbContext.Contracts.ToList();
        }

        public void Insert(Contract newContract)
        {
            _dbContext.Contracts.Add(newContract);
            _dbContext.SaveChanges();
        }
    }
}