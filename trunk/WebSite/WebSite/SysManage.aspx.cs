using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Model;
using BLL;

public partial class SysManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Add_Click(object sender, EventArgs e)
    {
        Model.Sys sys = new Sys();
        sys.Language = 0;
        sys.Name = this.tbName.Text.Trim();
        sys.Value = this.tbValue.Text.Trim();
        SysManager.Add(sys);
        this.GridView1.DataBind();
    }
}
