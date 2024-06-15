using System;
using System.Collections.Generic;

namespace ClinicHistoryPro.Domain.Models
{
    public partial class Prescription
    {
        public int Id { get; set; }
        public int ConsultationId { get; set; }
        public int MedicineId { get; set; }
        public string? Dose { get; set; }
        public string? Frequency { get; set; }
        public string? Duration { get; set; }
        public string? Notes { get; set; }
        public Guid GuidId { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Consultation Consultation { get; set; } = null!;
        public virtual Medicine Medicine { get; set; } = null!;
    }
}
