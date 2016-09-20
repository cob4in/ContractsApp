using ContractsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContractsApp.BusinessLogic
{
    public interface ISalaryStrategy
    {
        decimal CalculateSalary(ContractMinData minData);
    }
}