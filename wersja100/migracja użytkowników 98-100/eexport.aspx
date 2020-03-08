<%@ Page Language="C#" AutoEventWireup="true" CodeFile="eexport.aspx.cs" Inherits="Admin_eexport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
        {
            width: 1023px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <table class="style1">
        <tr>
            <td class="style3">
                Ekspor użytkowników z RWA do pliku XML wersja 07.02.2020</td>
        </tr>
        <tr>
            <td class="style3">
                Wpisz domenę poczty elektronicznej np. bialystok.gov jeżeli ma być tworzony 
                automatycznie adres email: login@domena
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:TextBox ID="tbDomena" runat="server" Width="417px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Eksport" />
            </td>
        </tr>
        </table>
    </form>
</body>
</html>
