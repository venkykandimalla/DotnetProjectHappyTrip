using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HappyTripWebApp.Controls
{
    public partial class AdminMaster : System.Web.UI.UserControl
    {
        public int EditIndex
        {
            get
            {
                if (ViewState["_EditIndex"] == null)
                { ViewState["_EditIndex"] = -1; }
                return (int)ViewState["_EditIndex"];
            }
            set { ViewState["_EditIndex"] = value; }
        }
        public Control Content { get; set; }
        public Control MessageContent { get; set; }
        public Control BottomContent { get; set; }

        public event EventHandler PreviousPageClick;
        public event EventHandler NextPageClick;

        public string Heading
        {
            set
            { hdHeading.InnerText = value; }
        }
        public string Width
        {
            set
            { ContentFrame.Style.Add("width", value); }
        }
        public bool ShowPager
        {
            set
            {
                ModifySearchWrapper.Visible = value;
            }
        }
        public string ErrorMessage
        {
            set
            {
                lblErrorMessage.InnerText = value;
                if (lblErrorMessage.InnerText.Trim().Length > 0)
                { lblErrorMessage.Visible = true; }
                else
                { lblErrorMessage.Visible = false; }
            }
        }

        public int CurrentPage
        {
            get
            {
                object currentPage = this.ViewState["_CurrentPage"];
                if (currentPage == null)
                { return 0; }
                else
                { return (int)currentPage; }
            }
            set
            { this.ViewState["_CurrentPage"] = value; }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            phContent.Controls.Add(Content);

            if (MessageContent != null)
            { phMessageContent.Controls.Add(MessageContent); }

            if (BottomContent != null)
            { phBottomContent.Controls.Add(BottomContent); }

            lblErrorMessage.InnerText = "";
            lblErrorMessage.Visible = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void lbtPreviousPage_Click(object sender, EventArgs e)
        {
            if (EditIndex < 0)
            {
                EventHandler previousPage = PreviousPageClick;
                if (previousPage != null)
                {
                    CurrentPage -= 1;
                    previousPage(sender, e);
                }
            }
            else
            {
                ErrorMessage = "You need to cancel the current edit before you can navigate";
            }
        }
        protected void lbtNextPage_Click(object sender, EventArgs e)
        {
            if (EditIndex < 0)
            {
                EventHandler nextPage = NextPageClick;
                if (nextPage != null)
                {
                    CurrentPage += 1;
                    nextPage(sender, e);
                }
            }
            else
            {
                ErrorMessage = "You need to cancel the current edit before you can navigate";
            }
        }

        public void BuildPager(PagedDataSource Pager)
        {
            Pager.CurrentPageIndex = CurrentPage;

            lblCurrentPage.Text = "Page " + (CurrentPage + 1).ToString() + " of " + Pager.PageCount.ToString();

            lbtPreviousPage.Enabled = !Pager.IsFirstPage;
            lbtNextPage.Enabled = !Pager.IsLastPage;
        }
        public void BuildPager(GridView GridView)
        {
            EditIndex = GridView.EditIndex;
            GridView.PageIndex = CurrentPage;
            GridView.DataBind();

            lblCurrentPage.Text = "Page " + (CurrentPage + 1).ToString() + " of " + GridView.PageCount.ToString();

            lbtPreviousPage.Enabled = CurrentPage > 0;
            lbtNextPage.Enabled = CurrentPage < (GridView.PageCount - 1);
        }
    }
}
