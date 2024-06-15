using System;
using System.Collections.Generic;

namespace ClinicHistoryPro.Domain.Models
{
    public partial class HistoryClinic
    {
        public HistoryClinic()
        {
            Consultations = new HashSet<Consultation>();
        }

        public int Id { get; set; }
        public int PatientId { get; set; }
        public Guid GuidId { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Patient Patient { get; set; } = null!;
        public virtual ICollection<Consultation> Consultations { get; set; }
    }
}
