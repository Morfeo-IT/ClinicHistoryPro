using ClinicHistoryPro.Application.Cqrs.Patients;
using FluentValidation;

namespace ClinicHistoryPro.Api.Validator
{
    public class CreateOnePatientValidator: AbstractValidator<CreateOnePatientRequest>
    {
        public CreateOnePatientValidator()
        {
            RuleFor(rule => rule.patient.DocumentTypeId).NotEmpty();
            RuleFor(rule => rule.patient.DocumentTypeId).NotNull();
        }
    }
}
