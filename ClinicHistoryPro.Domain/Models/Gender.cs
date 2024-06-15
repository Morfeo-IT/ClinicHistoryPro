using System;
using System.Collections.Generic;

namespace ClinicHistoryPro.Domain.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public Guid GuidId { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
