using System;
using System.Collections.Generic;

namespace Arena.Models.DB
{
    public partial class GroupMaster
    {
        public GroupMaster()
        {
            GroupDtls = new HashSet<GroupDtls>();
        }

        public decimal GmId { get; set; }
        public decimal GmCreatedBy { get; set; }
        public string GmName { get; set; }
        public int? GmCount { get; set; }
        public DateTime? GmCreatedOn { get; set; }

        public PlayersDtls GmCreatedByNavigation { get; set; }
        public ICollection<GroupDtls> GroupDtls { get; set; }
    }
}
