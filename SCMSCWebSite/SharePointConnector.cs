using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCMSCWebSite
{
  class SharePointConnector
  {
    #region Global and constant variables
    const string LIST_MAIN_TABS = "Pestañas Principales";
    const string LIST_MAIN_CONTENT_A = "Contenido Principal A";
    const string LIST_MAIN_CONTENT_B = "Contenido Principal B";
    const string LIST_MAIN_CONTACTS = "Contactos";
    #endregion

    #region Get methods
    /// <summary>
    /// Get "Pestañas Principales" approved items.
    /// </summary>
    /// <returns></returns>
    internal static SPListItemCollection GetMainTabs()
    {
      SPListItemCollection queriedItems = null;

      using (SPSite sps = new SPSite(SPContext.Current.Web.Url))
      using (SPWeb spw = sps.OpenWeb())
      {
        SPQuery query = new SPQuery();
        query.Query = string.Format(
          "<OrderBy><FieldRef Name='Posici_x00f3_n' Ascending='TRUE' /></OrderBy>" +
          "<Where><Eq><FieldRef Name='_ModerationStatus' /><Value Type='ModStat'>0</Value></Eq>" +
          "</Where>");

        queriedItems = spw.Lists[LIST_MAIN_TABS].GetItems(query);
      }

      if (queriedItems.Count == 0)
        queriedItems = null;

      return queriedItems;
    }

    /// <summary>
    /// Get "Contenido Principal A" approved items.
    /// </summary>
    /// <returns></returns>
    internal static SPListItemCollection GetMainContentA()
    {
      SPListItemCollection queriedItems = null;

      using (SPSite sps = new SPSite(SPContext.Current.Web.Url))
      using (SPWeb spw = sps.OpenWeb())
      {
        SPQuery query = new SPQuery();
        query.Query = string.Format(
          "<OrderBy><FieldRef Name='ID' Ascending='FALSE' /></OrderBy>" +
          "<Where><Eq><FieldRef Name='_ModerationStatus' /><Value Type='ModStat'>0</Value></Eq>" +
          "</Where>");

        queriedItems = spw.Lists[LIST_MAIN_CONTENT_A].GetItems(query);
      }

      if (queriedItems.Count == 0)
        queriedItems = null;

      return queriedItems;
    }

    /// <summary>
    /// Get "Contenido Principal B" approved items.
    /// </summary>
    /// <returns></returns>
    internal static SPListItemCollection GetMainContentB()
    {
      SPListItemCollection queriedItems = null;

      using (SPSite sps = new SPSite(SPContext.Current.Web.Url))
      using (SPWeb spw = sps.OpenWeb())
      {
        SPQuery query = new SPQuery();
        query.Query = string.Format(
          "<OrderBy><FieldRef Name='ID' Ascending='FALSE' /></OrderBy>" +
          "<Where><Eq><FieldRef Name='_ModerationStatus' /><Value Type='ModStat'>0</Value></Eq>" +
          "</Where>");

        queriedItems = spw.Lists[LIST_MAIN_CONTENT_B].GetItems(query);
      }

      if (queriedItems.Count == 0)
        queriedItems = null;

      return queriedItems;
    }
    #endregion

    #region Set methods
    internal static void SetContactInfo(string name, string email, string phone, string message)
    {
      SPSecurity.RunWithElevatedPrivileges(delegate ()
      {
        using (SPSite sps = new SPSite(SPContext.Current.Web.Url))
        using (SPWeb spw = sps.OpenWeb())
        {
          SPListItemCollection contactList = spw.Lists[LIST_MAIN_CONTACTS].Items;
          SPListItem newItem = contactList.Add();

          newItem["Title"] = name;
          newItem["Correo_x0020_contacto"] = email;
          newItem["Tel_x00e9_fono_x0020_contacto"] = phone;
          newItem["Mensaje_x0020_contacto"] = message;

          try
          {
            newItem.Web.AllowUnsafeUpdates = true;
            newItem.Update();
          }
          finally
          {
            newItem.Web.AllowUnsafeUpdates = false;
          }
        }
      });
    }
    #endregion
  }
}
