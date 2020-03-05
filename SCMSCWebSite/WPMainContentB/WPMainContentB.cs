using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace SCMSCWebSite.WPMainContentB
{
  [ToolboxItemAttribute(false)]
  public class WPMainContentB : WebPart
  {
    // Visual Studio might automatically update this path when you change the Visual Web Part project item.
    private const string _ascxPath = @"~/_CONTROLTEMPLATES/15/SCMSCWebSite/WPMainContentB/WPMainContentBUserControl.ascx";

    #region Web part parameters
    public static short spContentBLimit;
    [Personalizable(PersonalizationScope.Shared),
    WebBrowsable(true),
    WebDisplayName("Límite de elementos"),
    WebDescription("Define el límite de elementos a mostrar."),
    Category("Configuración")]
    public short SpContentBLimit
    {
      get { return spContentBLimit; }
      set { spContentBLimit = value; }
    }
    #endregion

    protected override void CreateChildControls()
    {
      Control control = Page.LoadControl(_ascxPath);
      Controls.Add(control);
    }
  }
}
