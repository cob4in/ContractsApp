using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContractsApp.Models;
using ContractsApp.Utils;

namespace ContractsApp.BusinessLogic
{
    public class AbstractMinimalWageBasedSalaryStrategy : ISalaryStrategy
    {
        #region private members 

        protected Dictionary<JobPosition, List<MinSalaryEntry>> minSalaryDict;

        protected IMinSalaryEntryRepository _repository;

        protected void Initialize(IMinSalaryEntryRepository repository)
        {
            _repository = repository;
            minSalaryDict = _repository.FindAll()
                .GroupBy(m => m.Position)
                .ToDictionary(g => g.Key, g => g.ToList());
        }
        #endregion
        public virtual decimal CalculateSalary(ContractMinData minData)
        {
            return minSalaryDict[minData.Position].Single(minSalary=>minSalary.InRange(minData.Experience)).Salary;
        }
    }
}