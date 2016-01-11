using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_LeaveBalanceTable : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindDropDowns();
    }

    protected List<LeavesBalanceRecord> lstLeavesBalanceRecord = new List<LeavesBalanceRecord>();
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txt_start_date.Text = Calendar1.SelectedDate.Date.ToString("d");
    }
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        txt_end_date.Text = Calendar2.SelectedDate.Date.ToString("d");
    }
    protected void BindDropDowns()
    {
        MasterEntries objMasterEntries = new MasterEntries();
        ddlDepartments.DataSource = objMasterEntries.GetAllDepartments();
        ddlDepartments.DataTextField = "Name";
        ddlDepartments.DataValueField = "Id";
        ddlDepartments.DataBind();
    }

    protected void btnGetData_Click(object sender, EventArgs e)
    {
        ManageReports objManageReports = new ManageReports();
        lstLeavesBalanceRecord = objManageReports.GetDataForMonthlyLeaveBalanceTable(Convert.ToInt32(ddlDepartments.SelectedValue.ToString()), Calendar1.SelectedDate.Date, Calendar2.SelectedDate.Date);
        grid1.DataSource = lstLeavesBalanceRecord;
        grid1.DataBind();
    }
    public void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int id = Convert.ToInt32(e.Row.Cells[0].Text);
            GridView grid2 = (GridView)e.Row.FindControl("grid2");
            GridView grid3 = (GridView)e.Row.FindControl("grid3");
            GridView grid4 = (GridView)e.Row.FindControl("grid4");
            GridView grid5 = (GridView)e.Row.FindControl("grid5");

            var y = lstLeavesBalanceRecord.Select(x => x).Where(d => d.EmployeeId == id).FirstOrDefault();
            grid2.DataSource = GetDataTable(y.lstLeavesOldStack);
           // var table = GetDataTable(y.lstLeavesOldStack);
            grid2.DataBind();
            grid3.DataSource = GetDataTable(y.lstLeavesDue);
            grid3.DataBind();
            grid4.DataSource = GetDataTable(y.lstLeavesAvailed);
            grid4.DataBind();
            grid5.DataSource = GetDataTable(y.lstLeavesBalance);
            grid5.DataBind();
        }
    }


    public DataTable GetDataTable(List<LeavesCount> lst)
    {
        DataTable table = new DataTable();

        foreach (var item in lst)
        {
            table.Columns.Add(item.LeaveName);
        }
        DataRow dr = table.NewRow();

        for (int j = 0; j < lst.Count; j++)
        {
           dr[j] = lst[j].LeaveCount;
        }
        table.Rows.Add(dr);
      
        return table;
    }

    //protected void btnExport_Click(object sender, EventArgs e)
    //{
    //    using (StringWriter sw = new StringWriter())
    //    {
    //        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
    //        {
    //            //To Export all pages
    //            grid1.AllowPaging = false;
    //            // this.BindGrid();

    //            grid1.RenderBeginTag(hw);
    //            grid1.HeaderRow.RenderControl(hw);
    //            foreach (GridViewRow row in grid1.Rows)
    //            {
    //                row.RenderControl(hw);
    //            }
    //            grid1.FooterRow.RenderControl(hw);
    //            grid1.RenderEndTag(hw);
    //            StringReader sr = new StringReader(sw.ToString());
    //            Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
    //            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    //            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    //            pdfDoc.Open();
    //            htmlparser.Parse(sr);
    //            pdfDoc.Close();

    //            Response.ContentType = "application/pdf";
    //            Response.AddHeader("content-disposition", "attachment;filename=Report.pdf");
    //            Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //            Response.Write(pdfDoc);
    //            Response.End();
    //        }
    //    }
    //}
}