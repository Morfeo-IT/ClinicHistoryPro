using ClinicHistoryPro.Application.DTOs;
using MediatR;

namespace ClinicHistoryPro.Application.Cqrs.Patients
{
    public class CreateOnePatientRequest: IRequest<RequestResult<bool>>
    {
        public PatientDTO patient { get; set; }
    }
}
