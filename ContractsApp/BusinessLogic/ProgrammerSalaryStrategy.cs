using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContractsApp.Models;

namespace ContractsApp.BusinessLogic
{
    public class ProgrammerSalaryStrategy : AbstractMinimalWageBasedSalaryStrategy
    {
        public ProgrammerSalaryStrategy(IMinSalaryEntryRepository repository)
        {
            Initialize(repository);
        }

        public override decimal CalculateSalary(ContractMinData minData)
        {
            return base.CalculateSalary(minData) + minData.Experience * 125;
        }
    }
}