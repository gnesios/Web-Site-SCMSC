using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace SCMSCWebSite.WPContactForm
{
  [ToolboxItemAttribute(false)]
  public class WPContactForm : WebPart
  {
    // Visual Studio might automatically update this path when you change the Visual Web Part project item.
    private const string _ascxPath = @"~/_CONTROLTEMPLATES/15/SCMSCWebSite/WPContactForm/WPContactFormUserControl.ascx";

    #region Web part parameters
    public static string spThanksMessage;
    [Personalizable(PersonalizationScope.Shared),
    WebBrowsable(true),
    WebDisplayName("Mensaje agradecimiento"),
    WebDescription("Mensaje de agradecimiento formulario de contacto."),
    Category("Configuración")]
    public string SpThanksMessage
    {
      get { return spThanksMessage; }
      set { spThanksMessage = value; }
    }
    #endregion

    protected override void CreateChildControls()
    {
      Control control = Page.LoadControl(_ascxPath);
      Controls.Add(control);
    }
  }
}
