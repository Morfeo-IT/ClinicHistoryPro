using System;
using System.Collections.Generic;

namespace ClinicHistoryPro.Domain.Models
{
    public partial class MenuItem
    {
        public MenuItem()
        {
            InverseParentMenuItem = new HashSet<MenuItem>();
        }

        public int MenuItemId { get; set; }
        public int? ParentMenuItemId { get; set; }
        public string Name { get; set; } = null!;
        public string? Url { get; set; }
        public int DisplayOrder { get; set; }
        public Guid GuidId { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual MenuItem? ParentMenuItem { get; set; }
        public virtual ICollection<MenuItem> InverseParentMenuItem { get; set; }
    }
}
