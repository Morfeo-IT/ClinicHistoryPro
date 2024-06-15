using AutoMapper;
using ClinicHistoryPro.Application.Services.Interfaces;
using ClinicHistoryPro.Domain.Models;
using MediatR;

namespace ClinicHistoryPro.Application.Cqrs.Patients
{
    public class CreateOnePatientHandler : IRequestHandler<CreateOnePatientRequest, RequestResult<bool>>
    {
        private readonly IPatientAppService patientAppService;
        private readonly IMapper mapper;
        public CreateOnePatientHandler(IPatientAppService patientAppService, IMapper mapper)
        {
            this.patientAppService = patientAppService;
            this.mapper = mapper;
        }

        public async Task<RequestResult<bool>> Handle(CreateOnePatientRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var patient = mapper.Map<Patient>(request.patient);
                var result = await patientAppService.CreateOnePatient(patient);

                if(!result) return RequestResult<bool>.CreateUnsuccessful(new string[] { "No se pude crear el paciente." });
                
                return RequestResult<bool>.CreateSuccessful(true);
            }
            catch(Exception ex)
            {
                return RequestResult<bool>.CreateError(new string[] { ex.Message });
            }
        }
    }
}
