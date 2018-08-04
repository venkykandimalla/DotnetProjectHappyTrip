using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using HappyTrip.Model.Entities.UserAccount;

namespace HappyTripWebApp
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Membership.GetUser() != null)
                    {
                        ProfileCommon com = ProfileCommon.GetProfile(Membership.GetUser().UserName.ToString());

                        UpdateLabel.Text = "";
                        UpdateLabel_container.Visible = false;
                        DateTime dateOnly = com.Personal.DateOfBirth;

                        Name.Text = com.Personal.FullName;
                        date.Text = dateOnly.ToShortDateString();
                        Address1.Text = com.Contact.Address;
                        City.Text = com.Contact.City;
                        State.Text = com.Contact.State;
                        Pincode.Text = com.Contact.PinCode;
                        MobileNo.Text = com.Contact.MobileNo;

                        if (com.Personal.Gender == 'M' || com.Personal.Gender == 'm')
                        {
                            lbgender.Text = "Male";
                            Gender.SelectedIndex = 1;
                        }
                        else
                        {
                            lbgender.Text = "Female";
                            Gender.SelectedIndex = 2;
                        }
                        lbname.Text = com.Personal.FullName;
                        //lbDOB.Text = dateOnly.ToShortDateString();
                        lbDOB.Text = dateOnly.ToString("M/d/yyyy");
                        lbAddress.Text = com.Contact.Address;
                        lbCity.Text = com.Contact.City;
                        lbState.Text = com.Contact.State;
                        lbPib.Text = com.Contact.PinCode;
                        lbMobile.Text = com.Contact.MobileNo;
                    }
                }
                catch (Exception ex)
                {
                    UpdateLabel.Text = "Sorry !!! Unable to fetch your account details. Please try again";
                    UpdateLabel_container.Visible = true;
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    DateTime dtDOB;
                    date.Text = date.Text.Trim();
                    bool blnIsValidDate = DateTime.TryParseExact(date.Text, "M/d/yyyy", null, System.Globalization.DateTimeStyles.None, out dtDOB);

                    if (Name.Text.Length == 0)
                    {
                        UpdateLabel.Text = "Name can't be empty";
                        UpdateLabel_container.Visible = true;
                        Name.Focus();
                    }
                    else if (date.Text.Length == 0)
                    {
                        UpdateLabel.Text = "Date of Birth can't be empty";
                        UpdateLabel_container.Visible = true;
                        date.Focus();
                    }
                    else if (!blnIsValidDate)
                    {
                        UpdateLabel.Text = "Please enter a valid Date of Birth";
                        UpdateLabel_container.Visible = true;
                        date.Focus();
                    }
                    else if (dtDOB > DateTime.Now)
                    {
                        UpdateLabel.Text = "Date of Birth should be lesser than Current Date";
                        UpdateLabel_container.Visible = true;
                        date.Focus();
                    }
                    else
                    {
                        ProfileCommon com = ProfileCommon.GetProfile(Membership.GetUser().UserName.ToString());
                        com.Personal.FullName = Name.Text;
                        com.Personal.Gender = Convert.ToChar(Gender.SelectedValue.ToString());
                        com.Personal.DateOfBirth = Convert.ToDateTime(date.Text);
                        com.Contact.Address = Address1.Text;
                        com.Contact.City = City.Text;
                        com.Contact.MobileNo = MobileNo.Text;
                        com.Contact.PinCode = Pincode.Text;
                        com.Contact.State = State.Text;
                        com.Save();
                        Response.Redirect("~/Account/UpdateProfile.aspx", false);
                    }
                }

                hdnShowEditControls.Value = "1";
            }
            catch (Exception ex)
            {
                UpdateLabel.Text = "Sorry !!! Unable to Update your account. Please try again";
                UpdateLabel_container.Visible = true;
                hdnShowEditControls.Value = "1";
            }
        }

    }
}