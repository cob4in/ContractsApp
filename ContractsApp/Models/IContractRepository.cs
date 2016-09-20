using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractsApp.Models
{
    public interface IContractRepository : IRepository<Contract, int>
    {
        IEnumerable<Contract> FindAll();

        void Insert(Contract newContract);

        int ContractNameOccurences(String name);
    }
}
