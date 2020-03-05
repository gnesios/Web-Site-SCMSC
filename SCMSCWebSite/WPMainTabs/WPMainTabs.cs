using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace SCMSCWebSite.WPMainTabs
{
  [ToolboxItemAttribute(false)]
  public class WPMainTabs : WebPart
  {
    // Visual Studio might automatically update this path when you change the Visual Web Part project item.
    private const string _ascxPath = @"~/_CONTROLTEMPLATES/15/SCMSCWebSite/WPMainTabs/WPMainTabsUserControl.ascx";

    #region Web part parameters
    public static short spTabsLimit;
    [Personalizable(PersonalizationScope.Shared),
    WebBrowsable(true),
    WebDisplayName("Límite de elementos"),
    WebDescription("Define el límite de elementos a mostrar."),
    Category("Configuración")]
    public short SpTabsLimit
    {
      get { return spTabsLimit; }
      set { spTabsLimit = value; }
    }
    #endregion

    protected override void CreateChildControls()
    {
      Control control = Page.LoadControl(_ascxPath);
      Controls.Add(control);
    }
  }
}
