using System;
using System.Collections.Generic;

namespace ClinicHistoryPro.Domain.Models
{
    public partial class Patient
    {
        public Patient()
        {
            HistoryClinics = new HashSet<HistoryClinic>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateBirth { get; set; }
        public int GenderId { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int DocumentTypeId { get; set; }
        public string? DocumentNumber { get; set; }
        public Guid GuidId { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual DocumentType DocumentType { get; set; } = null!;
        public virtual Gender Gender { get; set; } = null!;
        public virtual ICollection<HistoryClinic> HistoryClinics { get; set; }
    }
}
