using ContractsApp.Models.Validations;
using FluentValidation.Attributes;

namespace ContractsApp.Models
{
    [Validator(typeof(ContractValidator))]
    public class Contract : ContractMinData
    {
        public long ContractId { get; set; }
        
        public decimal Salary { get; set; }
    }
}