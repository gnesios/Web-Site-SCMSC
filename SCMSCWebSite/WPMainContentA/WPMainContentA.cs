using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace SCMSCWebSite.WPMainContentA
{
  [ToolboxItemAttribute(false)]
  public class WPMainContentA : WebPart
  {
    // Visual Studio might automatically update this path when you change the Visual Web Part project item.
    private const string _ascxPath = @"~/_CONTROLTEMPLATES/15/SCMSCWebSite/WPMainContentA/WPMainContentAUserControl.ascx";

    #region Web part parameters
    public static short spContentALimit;
    [Personalizable(PersonalizationScope.Shared),
    WebBrowsable(true),
    WebDisplayName("Límite de elementos"),
    WebDescription("Define el límite de elementos a mostrar."),
    Category("Configuración")]
    public short SpContentALimit
    {
      get { return spContentALimit; }
      set { spContentALimit = value; }
    }
    #endregion

    protected override void CreateChildControls()
    {
      Control control = Page.LoadControl(_ascxPath);
      Controls.Add(control);
    }
  }
}
