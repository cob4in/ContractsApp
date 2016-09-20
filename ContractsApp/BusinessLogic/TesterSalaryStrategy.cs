using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContractsApp.Models;

namespace ContractsApp.BusinessLogic
{
    public class TesterSalaryStrategy : AbstractMinimalWageBasedSalaryStrategy
    {
        public TesterSalaryStrategy(IMinSalaryEntryRepository repository)
        {
            Initialize(repository);
        }
        public override decimal CalculateSalary(ContractMinData minData)
        {
            decimal minSalary = base.CalculateSalary(minData);
            return minSalary + minData.Experience * (100 + minSalary/4);
        }
    }
}