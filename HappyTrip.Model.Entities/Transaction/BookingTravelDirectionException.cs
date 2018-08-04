using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.Transaction
{
    public class BookingTravelDirectionException : Exception
    {
        public BookingTravelDirectionException(string Message) : base(Message)
        {

        }
    }
}
