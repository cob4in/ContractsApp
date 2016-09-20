using ContractsApp.Models;
using ContractsApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContractsApp.BusinessLogic
{
    public class SalaryStrategyProvider
    {
        internal static ISalaryStrategy GetSalaryStrategy(JobPosition position, IMinSalaryEntryRepository repository)
        {
            return position == JobPosition.Programmer ? new ProgrammerSalaryStrategy(repository) : new TesterSalaryStrategy(repository) as ISalaryStrategy;
        }
    }
}