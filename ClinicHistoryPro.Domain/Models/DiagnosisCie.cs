using System;
using System.Collections.Generic;

namespace ClinicHistoryPro.Domain.Models
{
    public partial class DiagnosisCie
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int InitialAge { get; set; }
        public int EndAge { get; set; }
        public int CodeGender { get; set; }
        public Guid GuidId { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
