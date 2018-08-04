using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.Hotel
{
    /// <summary>
    /// Class to represent the type of rooms a hotel would have
    /// </summary>
    public class RoomType
    {
        #region Properties of the class

        public int TypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }

        #endregion
    }
}
