using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.BusinessLayer.UserAccount
{
    public class AccountManagerFactory
    {
        #region Fields of the class - Instance of the factory

        private static AccountManagerFactory Instance = new AccountManagerFactory();

        #endregion


        /// <summary>
        /// Making the constructor private so that object is not created
        /// </summary>
        private AccountManagerFactory()
        {

        }

        public static AccountManagerFactory GetInstance()
        {
            return Instance;
        }

        public IAccountManager Create()
        {
            return new AccountManager();
        }
    }
}
