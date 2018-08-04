using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.Transaction
{
    /// <summary>
    /// Class to represent booking information for a transaction done
    /// </summary>
    public abstract class Booking
    {
        #region Properties of the class

        public long BookingId { get; set; }
        public string UserName { get; set; }
        public BookingTypes BookingType { get; set; }
        public BookingContact Contact { get; set; }
        public DateTime BookingDate { get; set; }
        public string ReferenceNo { get; set; }
        public string Remarks { get; set; }
        public decimal TotalCost { get; set; }
        public bool IsCanceled { get; set; }
        public Payment PaymentInfo { get; set; }
        public Cancelation CancelationInfo { get; set; }

        #endregion

    }
}
