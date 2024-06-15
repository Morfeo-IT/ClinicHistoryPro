using System;
using System.Collections.Generic;

namespace ClinicHistoryPro.Domain.Models
{
    public partial class Consultation
    {
        public Consultation()
        {
            Prescriptions = new HashSet<Prescription>();
        }

        public int Id { get; set; }
        public int HistoryClinicId { get; set; }
        public string? ReasonConsultation { get; set; }
        public string? Diagnosis { get; set; }
        public string? Treatment { get; set; }
        public string? Notes { get; set; }
        public Guid GuidId { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual HistoryClinic HistoryClinic { get; set; } = null!;
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
