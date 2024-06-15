namespace ClinicHistoryPro.Application.DTOs
{
    public class MenuItemDTO: AuditoryDTO
    {
        public string Name { get; set; }
        public string? Url { get; set; }
        public List<MenuItemDTO>? MenuItems { get; set; }
    }
}
