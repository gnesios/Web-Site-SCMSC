using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace SCMSCWebSite.WPContactForm
{
  public partial class WPContactFormUserControl : UserControl
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Request.QueryString["msg"] != null && !string.IsNullOrWhiteSpace(Request.QueryString["msg"].ToString()))
      {
        ltrMessage.Text = WPContactForm.spThanksMessage;

        pnlForm.Visible = false;
        pnlThanks.Visible = true;
      }
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.IsPostBack)
        {
          SharePointConnector.SetContactInfo(txbName.Text.Trim(), txbEmail.Text.Trim(), txbPhone.Text, txbMessage.Text.Trim());

          this.Response.Redirect(System.Web.HttpContext.Current.Request.Url.AbsolutePath + "?msg=tks");
        }
      }
      catch (Exception ex)
      {
        this.ShowErrorMessage(ex.Message);
      }
    }

    private void ShowErrorMessage(string message)
    {
      LiteralControl errorMessage = new LiteralControl
      {
        Text = string.Format("<div class='error_message'>{0}</div>", message)
      };

      this.Controls.Clear();
      this.Controls.Add(errorMessage);
    }
  }
}
