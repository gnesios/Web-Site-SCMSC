using Microsoft.SharePoint;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace SCMSCWebSite.WPMainContentB
{
  public partial class WPMainContentBUserControl : UserControl
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        this.GetAndShowContentB();
      }
      catch (Exception ex)
      {
        this.ShowErrorMessage(ex.Message);
      }
    }

    private void GetAndShowContentB()
    {
      SPListItemCollection contentBItems = SharePointConnector.GetMainContentB();

      if (contentBItems == null)
      {
        this.ShowErrorMessage("No existen elementos que mostrar.<br/>Verifique que exista al menos UN elemento aprobado en la lista.");
      }
      else
      {
        string formatedTitle = "";
        string formatedContent = "";

        short limit = WPMainContentB.spContentBLimit;
        foreach (SPListItem contentB in contentBItems)
        {
          if (limit == 0)
            break;

          if (contentB["Tipo_x0020_contenido"].ToString() == "ENCABEZADO")
          {//"ENCABEZADO"
            formatedTitle = contentB.Title.Trim();
          }
          else
          {//"CUERPO"
            string imagePath = "";
            string description = "";
            string attachFile = contentB.Attachments.Count == 0 ?
              "#" : contentB.Attachments.UrlPrefix + contentB.Attachments[0];

            if (contentB["Imagen_x0020_asociada"] != null)
            {
              imagePath = contentB["Imagen_x0020_asociada"].ToString().Contains(",") ?
                contentB["Imagen_x0020_asociada"].ToString().Remove(contentB["Imagen_x0020_asociada"].ToString().IndexOf(',')) :
                contentB["Imagen_x0020_asociada"].ToString();
            }

            if (contentB["Descripci_x00f3_n_x0020_asociada"] != null)
              description = contentB["Descripci_x00f3_n_x0020_asociada"].ToString();

            formatedContent += string.Format(
              "<tr><td><img src=\"{0}\" alt=\"\" /></td>" +
              "<td><p class=\"subtitle\">{1}</p><p>{2}</p></td>" +
              "<td><a href=\"{3}\" class=\"download-icon\"></a></td></tr>",
              imagePath, contentB.Title.Trim(), description, attachFile);
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
