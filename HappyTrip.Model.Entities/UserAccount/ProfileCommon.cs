using System;
using System.Web;
using System.Web.Profile;

namespace HappyTrip.Model.Entities.UserAccount
{
    /// <summary>
    /// Class to represent the profile information of a user
    /// </summary>
    public class ProfileCommon : ProfileBase
    {
        /// <summary>
        /// Get the personal information of a user
        /// </summary>
        public Personal Personal
        {
            get { return (Personal) GetPropertyValue("Personal"); }
        }

        /// <summary>
        /// Get the contact information of a user
        /// </summary>
        public Contact Contact
        {
            get { return (Contact) GetPropertyValue("Contact"); }
        }

        /// <summary>
        /// Get the profile of the currently logged-on user.
        /// </summary>     

        public static ProfileCommon GetProfile()
        {
            return (ProfileCommon) HttpContext.Current.Profile;
        }
    
        /// <summary>
        /// Gets the profile of a specific user.
        /// </summary>
        /// <param name="UserName">The user name of the user whose profile you want to retrieve.</param>
        public static ProfileCommon GetProfile(string UserName)
        {
            return (ProfileCommon) Create(UserName);
        }
    }
}
