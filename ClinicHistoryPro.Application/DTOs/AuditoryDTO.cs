namespace ClinicHistoryPro.Application.DTOs
{
    public abstract class AuditoryDTO
    {
        public int Id { get; set; }
        public Guid GuidId { get; set; } = Guid.NewGuid();
        public bool Status { get; set; } = true;
        public DateTime Created_at { get; set; } = DateTime.Now;
        public DateTime? Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }
    }
}
