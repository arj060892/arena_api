using System;
using System.Collections.Generic;

namespace Arena.Models.DB
{
    public partial class PlayersDtls
    {
        public PlayersDtls()
        {
            BookingMaster = new HashSet<BookingMaster>();
            GroupMaster = new HashSet<GroupMaster>();
        }

        public decimal PdId { get; set; }
        public string PdName { get; set; }
        public string PdEmailId { get; set; }
        public string PdMobileNo { get; set; }
        public string PdUserName { get; set; }
        public string PdPassword { get; set; }
        public DateTime? PdCreatedOn { get; set; }

        public ICollection<BookingMaster> BookingMaster { get; set; }
        public ICollection<GroupMaster> GroupMaster { get; set; }
    }
}
