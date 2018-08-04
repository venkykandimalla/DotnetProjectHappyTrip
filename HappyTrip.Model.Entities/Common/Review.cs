using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.Common
{
    public class Review
    {
        public long ID { get; set; }
        public string ReviewText { get; set; }
        public bool IsReportAbuse { get; set; }
        public bool IsActive { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
