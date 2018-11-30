using System;
using System.Collections.Generic;

namespace Arena.Models.DB
{
    public partial class GroupDtls
    {
        public decimal GdId { get; set; }
        public decimal GdGmId { get; set; }
        public string GdMemberName { get; set; }
        public DateTime GdCreatedBy { get; set; }

        public GroupMaster GdGm { get; set; }
    }
}
