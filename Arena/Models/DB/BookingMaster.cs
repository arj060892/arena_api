using System;
using System.Collections.Generic;

namespace Arena.Models.DB
{
    public partial class BookingMaster
    {
        public decimal BmId { get; set; }
        public decimal BmPdId { get; set; }
        public string BmBookingType { get; set; }
        public DateTime? BmBookingDate { get; set; }
        public string BmSlotMapper { get; set; }
        public decimal? BmBookedFor { get; set; }
        public decimal? BmBookedBy { get; set; }
        public DateTime? BmBookedOn { get; set; }

        public PlayersDtls BmPd { get; set; }
    }
}
