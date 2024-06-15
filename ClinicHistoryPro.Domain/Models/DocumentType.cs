using System;
using System.Collections.Generic;

namespace ClinicHistoryPro.Domain.Models
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid GuidId { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
