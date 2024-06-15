using System;
using System.Collections.Generic;

namespace ClinicHistoryPro.Domain.Models
{
    public partial class Input
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
        public Guid GuidId { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? OrderVisualization { get; set; }
    }
}
