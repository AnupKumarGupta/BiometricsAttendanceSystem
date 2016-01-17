using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BAS;
using DALHelper;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Web.UI;

/// <summary>
/// Summary description for Day
/// </summary>
static public class Utility
{
    public static void GenerateExcel(GridView gridViewExcel, string header, string filename, System.Web.UI.Page page)
    {
        HtmlForm form = new HtmlForm();
        form.Attributes["runat"] = "server";

        HtmlGenericControl ctrl = new HtmlGenericControl("h1");
        ctrl.InnerHtml = "<center>"+header+"</center>";

        page.Response.ClearContent();
        page.Response.AddHeader("content-disposition",
            "attachment;filename="+filename+".xls");
        page.Response.ContentType = "applicatio/excel";
        StringWriter sw = new StringWriter(); ;
        HtmlTextWriter htm = new HtmlTextWriter(sw);

        form.Controls.Add(ctrl);
        form.Controls.Add(gridViewExcel);
        page.Controls.Add(form);

        page.Form.RenderControl(htm);
        page.Response.Write(sw.ToString());
        page.Response.End();
    }
}

