using Microsoft.SharePoint;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace SCMSCWebSite.WPMainContentA
{
  public partial class WPMainContentAUserControl : UserControl
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        this.GetAndShowContentA();
      }
      catch (Exception ex)
      {
        this.ShowErrorMessage(ex.Message);
      }
    }

    private void GetAndShowContentA()
    {
      SPListItemCollection contentAItems = SharePointConnector.GetMainContentA();

      if (contentAItems == null)
      {
        this.ShowErrorMessage("No existen elementos que mostrar.<br/>Verifique que exista al menos UN elemento aprobado en la lista.");
      }
      else
      {
        string formatedTitle = "";
        string formatedContent = "";

        short limit = WPMainContentA.spContentALimit;
        foreach (SPListItem contentA in contentAItems)
        {
          if (limit == 0)
            break;

          if (contentA["Tipo_x0020_contenido"].ToString() == "ENCABEZADO")
          {//"ENCABEZADO"
            if (contentA["Descripci_x00f3_n_x0020_asociada"] != null &&
              !string.IsNullOrWhiteSpace(contentA["Descripci_x00f3_n_x0020_asociada"].ToString()) &&
              contentA["Descripci_x00f3_n_x0020_asociada"].ToString().Trim().StartsWith("/"))
            {
              formatedTitle = string.Format(
                "{0}<a href=\"{1}\" title=\"ver más...\"></a>",
                contentA.Title.Trim(), contentA["Descripci_x00f3_n_x0020_asociada"].ToString().Trim());
            }
            else
            {
              formatedTitle = contentA.Title.Trim();
            }
          }
          else
          {//"CUERPO"
            if (contentA["Descripci_x00f3_n_x0020_asociada"] != null)
            {
              formatedContent += string.Format(
                "<p class=\"subtitle\">{0}</p><p>{1}</p>",
                contentA.Title.Trim(), contentA["Descripci_x00f3_n_x0020_asociada"].ToString().Trim());
            }
          }

          limit--;
        }

        ltrTitle.Text = formatedTitle;
        ltrContent.Text = formatedContent;
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
