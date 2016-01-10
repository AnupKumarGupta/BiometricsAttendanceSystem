using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_MonthlyAttendanceEmployeeWise : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txt_start_date.Text = Calendar1.SelectedDate.Date.ToString("d");
    }
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        txt_end_date.Text = Calendar2.SelectedDate.Date.ToString("d");
    }
    protected void btn_report_Click(object sender, EventArgs e)
    {
        btnExport.Visible = true;
        ManageReports objManageReports = new ManageReports();
        TimeSpan relaxationTime = new TimeSpan();
        relaxationTime = TimeSpan.Parse(ddlRelaxation.SelectedValue.ToString());
        int EmployeeId = 0;
        Int32.TryParse(txtEmployeeId.Text, out EmployeeId);
        MonthlyReportOfEmployee objMonthlyReportOfEmployee = new MonthlyReportOfEmployee();
        var data = objManageReports.GetDataForMonthlyAttendanceReportByEmployeeId(EmployeeId, Calendar1.SelectedDate.Date, Calendar2.SelectedDate.Date, relaxationTime, out objMonthlyReportOfEmployee);
        grid_monthly_attendanceDetailed.DataSource = data;
        grid_monthly_attendanceDetailed.DataBind();
        if (data.Count != 0)
        {
            lblName.Text = "Name : " + data[0].Name;
        }
        else
        {
            lblName.Text = "No Data";
        }
        lblTotalDuration.Text = "TotalDuration : " + objMonthlyReportOfEmployee.TotalDuration.ToString();
        lblPresentDays.Text = "PresentDays : " + objMonthlyReportOfEmployee.PresentDays.ToString();
        lblLeaves.Text = "Leaves : " + objMonthlyReportOfEmployee.Leaves.ToString();
        lblHolidays.Text = "Holidays : " + objMonthlyReportOfEmployee.Holidays.ToString();
        lblAbsentDays.Text = objMonthlyReportOfEmployee.AbsentDays.ToString();
        lblAbsentDays.Text = "AbsentDays : " + objMonthlyReportOfEmployee.AbsentDays.ToString();
        lblWeeklyOff.Text = "WeeklyOff : " + objMonthlyReportOfEmployee.WeeklyOff.ToString();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                //To Export all pages
                grid_monthly_attendanceDetailed.AllowPaging = false;
                //this.BindGrid();

                grid_monthly_attendanceDetailed.RenderBeginTag(hw);
                grid_monthly_attendanceDetailed.HeaderRow.RenderControl(hw);
                foreach (GridViewRow row in grid_monthly_attendanceDetailed.Rows)
                {
                    row.RenderControl(hw);
                }
                grid_monthly_attendanceDetailed.FooterRow.RenderControl(hw);
                grid_monthly_attendanceDetailed.RenderEndTag(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Report.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
        }
    }
}