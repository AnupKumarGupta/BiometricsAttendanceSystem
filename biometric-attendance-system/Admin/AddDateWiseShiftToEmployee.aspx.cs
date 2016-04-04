using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddDateWiseShiftToEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindDropDown();
    }

    public void BindDropDown()
    {
        MasterEntries objMasterEntries = new MasterEntries();
        ddlShift.DataSource = objMasterEntries.GetAllShifts();
        ddlShift.DataTextField = "Name";
        ddlShift.DataValueField = "Id";
        ddlShift.DataBind();
    }
}