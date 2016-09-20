using ContractsApp.Utils;
using FluentValidation;

namespace ContractsApp.Models.Validations
{
    public class ContractValidator : AbstractValidator<Contract>
    {
        public ContractValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage(ValidationMsg.CONTRACT_NAME_NOT_EMPTY);
            RuleFor(c => c.Salary).GreaterThan(0m).WithMessage(ValidationMsg.CONTRACT_SALARY_MUST_BE_GREATER_THAN_ZERO);
        }
    }
}