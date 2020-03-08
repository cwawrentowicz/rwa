using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Profile;
using System.Data;
using System.Text;


public partial class Admin_eexport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Roles.IsUserInRole(Context.User.Identity.Name, "ADMINISTRATORZY"))
        {
            foreach (Control c in Page.Controls)
            {
                c.Visible = false;
            }
        }


    }
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        string nn;
        DataTable Table1;

        ProfileCommon pp;
        Table1 = new DataTable();
        DataRow dr;

        Table1.Columns.Add("Uzytkownik");
        //myDataColumn.DataType = Type.GetType("System.String");
        Table1.Columns.Add("Nazwisko");
        Table1.Columns.Add("Imie");
        Table1.Columns.Add("Jednostka");
        Table1.Columns.Add("Symbol");
        Table1.Columns.Add("Haslo");
        Table1.Columns.Add("Audyt");
        Table1.Columns.Add("Stan");
        Table1.Columns.Add("IsLocked");
        Table1.Columns.Add("LastLogin");
        Table1.Columns.Add("Funkcja");
        Table1.Columns.Add("Uwagi");
        Table1.Columns.Add("DataWaznosci");

        MembershipUserCollection users = Membership.GetAllUsers();
        DataClassesJednostkiProkuraturyDataContext db = new DataClassesJednostkiProkuraturyDataContext();

        string ss = "";
        string em = "";
        string hh = "";
        string[] rolesArray;
        

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + "RWA_Users.xml");
        Response.ContentEncoding = Encoding.GetEncoding("utf-8");
        Response.Charset = "windows-1250";
        Response.ContentType = "application/text";
        StringBuilder sb = new StringBuilder();
        sb.Append("<users>");
        sb.Append("\r\n");
        var random = new Random();
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!#$";
        var stringChars = new char[9];
        foreach (MembershipUser user in users)
        {

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            ProfileCommon muprofile = (ProfileCommon)ProfileBase.Create(user.UserName, true);
            ProfileCommon targetProfile = muprofile.GetProfile(user.UserName);

            if (this.tbDomena.Text.Length > 3)
            {
                em = user.UserName + '@' + this.tbDomena.Text;
            }
            else
            {
                em = "";
            }

            sb.Append("<user>");
            sb.Append("\r\n");
            sb.Append("<imie>" +  targetProfile.Imie + "</imie>");
            sb.Append("\r\n");
            sb.Append("<nazwisko>" +  targetProfile.Nazwisko + "</nazwisko>");
            sb.Append("\r\n");
            sb.Append("<login>" +  targetProfile.UserName+ "</login>");
            sb.Append("\r\n");
            sb.Append("<jednostka>" + targetProfile.Jednostka  + "</jednostka>");
            sb.Append("\r\n");
            sb.Append("<datawaznosci>" +  targetProfile.DataWaznosci + "</datawaznosci>");
            sb.Append("\r\n");
            sb.Append("<llock>" +  user.IsApproved + "</llock>");
            sb.Append("\r\n");
            sb.Append("<audyt>" +  targetProfile.Audyt + "</audyt>");
            sb.Append("\r\n");
            sb.Append("<uwagi>" + targetProfile.Uwagi + "</uwagi>");
            sb.Append("\r\n");
            if (this.tbDomena.Text.Length > 3)
            {
                sb.Append("<email>" + targetProfile.UserName + "@" + this.tbDomena.Text + "</email>");
            }
            else
            {
                sb.Append("<email>-</email>");
            }
            sb.Append("\r\n");
            hh  = new String(stringChars)  + random.Next(System.DateTime.Now.Millisecond);
            sb.Append("<pass>" + hh + "</pass>");
            sb.Append("\r\n");
            sb.Append("<ostanielogowanie>" + targetProfile.LastActivityDate + "</ostanielogowanie>");
            sb.Append("\r\n");
            sb.Append("<haslo>" + targetProfile.Haslo  + "</haslo>");
            sb.Append("\r\n");

            rolesArray = Roles.GetRolesForUser(user.UserName );

            foreach (var g in rolesArray)
            {
                sb.Append("<rola><nazwa>" + g + "</nazwa></rola>");
                sb.Append("\r\n");
            }

            sb.Append("</user>");
            sb.Append("\r\n");
            sb.Append("\r\n");

        }
        sb.Append("</users>");
        Response.Output.WriteLine(sb.ToString());
        Response.Flush();
        Response.End();

        //   Response.Write("<br>" + ss);

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {

    }
}
