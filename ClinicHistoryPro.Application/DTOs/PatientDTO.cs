namespace ClinicHistoryPro.Application.DTOs
{
    public class PatientDTO: AuditoryDTO
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateBirth { get; set; }
        public int DocumentTypeId { get; set; }
        public string? DocumentNumber { get; set; }
        public int ExpeditionCityId { get; set; }
        public int BloodTypeId { get; set; }
        public int GenderId { get; set; }
        public int localizationCityId { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MovilNumber { get; set; }
        public string? Email { get; set; }
    }
}
