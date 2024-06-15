namespace ClinicHistoryPro.Application.DTOs
{
    public class FormDTO: AuditoryDTO
    {
        public string Name { get; set; }
        public List<InputDTO> Inputs { get; set; }
    }
}
