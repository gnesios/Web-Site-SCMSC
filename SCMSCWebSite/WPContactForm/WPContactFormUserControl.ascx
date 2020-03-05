<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WPContactFormUserControl.ascx.cs" Inherits="SCMSCWebSite.WPContactForm.WPContactFormUserControl" %>

<div id="pnlForm" runat="server" class="validate-form">
  <div class="validate-input" data-validate="Ingrese su nombre">
    <asp:TextBox ID="txbName" runat="server" MaxLength="120" CssClass="field" AutoComplete="off"></asp:TextBox>
    <span class="focus" data-placeholder="Nombre"></span>
    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txbName" Text="* Requerido" Display="Dynamic"
      CssClass="error_message_contact" />
  </div>
  <div class="validate-input" data-validate="Ingrese su correo electrónico">
    <asp:TextBox ID="txbEmail" runat="server" MaxLength="60" CssClass="field" AutoComplete="off"></asp:TextBox>
    <span class="focus" data-placeholder="Correo electrónico"></span>
    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txbEmail" Text="* Requerido" Display="Dynamic" 
      CssClass="error_message_contact" />
    <asp:RegularExpressionValidator ID="regEmail" runat="server" ControlToValidate="txbEmail" Text="* Correo inválido" Display="Dynamic"
      ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="error_message_contact" />
  </div>
  <div class="validate-input" data-validate="Ingrese su teléfono">
    <asp:TextBox ID="txbPhone" runat="server" MaxLength="8" CssClass="field" AutoComplete="off"></asp:TextBox>
    <span class="focus" data-placeholder="Teléfono"></span>
    <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txbPhone" Text="* Requerido" Display="Dynamic"
      CssClass="error_message_contact" />
    <asp:CompareValidator ID="cmpPhone" runat="server" ControlToValidate="txbPhone" Text="* Teléfono inválido" Display="Dynamic" 
      Type="Integer" Operator="DataTypeCheck" CssClass="error_message_contact" />
  </div>
  <div class="validate-input" data-validate="Ingrese su mensaje">
    <asp:TextBox ID="txbMessage" runat="server" TextMode="MultiLine" Rows="6" CssClass="field" AutoComplete="off"></asp:TextBox>
    <span class="focus" data-placeholder="Mensaje"></span>
    <asp:RequiredFieldValidator ID="rfvMessage" runat="server" ControlToValidate="txbMessage" Text="* Requerido" Display="Dynamic"
      CssClass="error_message_contact" />
  </div>
  <asp:Button ID="btnSend" runat="server" Text="ENVIAR" OnClick="btnSend_Click" />
</div>

<div id="pnlThanks" runat="server" visible="false" class="thanks-form">
  <asp:Literal ID="ltrMessage" runat="server" Text="¡Gracias por contactarse con nosotros!"></asp:Literal>
</div>