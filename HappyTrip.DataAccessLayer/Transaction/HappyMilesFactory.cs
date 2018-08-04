using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.DataAccessLayer.Transaction
{
    public static class HappyMilesFactory
    {
        public static IHappyMilesDAO CreateHappyMilesDAO()
        {
            return new HappyMilesDAO();
        }
    }
}
