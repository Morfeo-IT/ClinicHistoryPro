namespace ClinicHistoryPro.Application.DTOs
{
    public class InputDTO
    {
        public int Id { get; set; }
        public int? FormId { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public string? Label { get; set; }
        public bool? Required { get; set; }
        public int? NumberColumns { get; set; }
        public string? Url { get; set; }
        public int? InputSuperiorId { get; set; }
    }
}
