using Microsoft.SharePoint;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace SCMSCWebSite.WPMainTabs
{
  public partial class WPMainTabsUserControl : UserControl
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        this.GetAndShowMainTabs();
      }
      catch (Exception ex)
      {
        this.ShowErrorMessage(ex.Message);
      }
    }

    private void GetAndShowMainTabs()
    {
      SPListItemCollection mainTabsItems = SharePointConnector.GetMainTabs();

      if (mainTabsItems == null)
      {
        this.ShowErrorMessage("No existen elementos que mostrar.<br/>Verifique que exista al menos UN elemento aprobado en la lista.");
      }
      else
      {
        string formatedTitle = "";
        string formatedContent = "";

        short limit = WPMainTabs.spTabsLimit;
        foreach (SPListItem tab in mainTabsItems)
        {
          if (limit == 0)
            break;

          string selectedOpt = "";
          switch (tab["Icono_x0020_asociado"].ToString())
          {
            case "ICONO 1": selectedOpt = "icon-opt1"; break;
            case "ICONO 2": selectedOpt = "icon-opt2"; break;
            case "ICONO 3": selectedOpt = "icon-opt3"; break;
            case "ICONO 4": selectedOpt = "icon-opt4"; break;
            case "ICONO 5": selectedOpt = "icon-opt5"; break;
            case "ICONO 6": selectedOpt = "icon-opt6"; break;
            case "ICONO 7": selectedOpt = "icon-opt7"; break;
          }
          string title = tab.Title.Trim();
          string imagePath = tab["Imagen_x0020_asociada"].ToString().Contains(",") ?
            tab["Imagen_x0020_asociada"].ToString().Remove(tab["Imagen_x0020_asociada"].ToString().IndexOf(',')) :
            tab["Imagen_x0020_asociada"].ToString();
          string description = "";

          if (tab["Descripci_x00f3_n_x0020_asociada"] != null)
          {
            string fullDescription = tab["Descripci_x00f3_n_x0020_asociada"].ToString();
            if (fullDescription.StartsWith("\"") && fullDescription.EndsWith("\""))
            {
              description = string.Format(
                "<p class=\"left\">&#8220;</p><p>{0}</p><p class=\"right\">&#8221;</p>",
                fullDescription.Replace("\"", ""));
            }
            else
            {
              description = string.Format("<p>{0}</p>", fullDescription);
            }
          }

          formatedTitle += string.Format(
            "<li><a href=\"javascript:;\" title=\"\" class=\"{0}\"><span>{1}</span></a></li>",
            selectedOpt, title);
          formatedContent += string.Format(
            "<section style=\"background: url({0}) no-repeat center 0;\">" +
            "<div>{1}</div></section>",
            imagePath, description);

          limit--;
        }

        ltrTabsTitle.Text = formatedTitle;
        ltrTabsContent.Text = formatedContent;
      }
    }

    private void ShowErrorMessage(string message)
    {
      LiteralControl errorMessage = new LiteralControl {
        Text = string.Format("<div class='error_message'>{0}</div>", message)
      };

      this.Controls.Clear();
      this.Controls.Add(errorMessage);
    }
  }
}
