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
using BLL;
using Model;
public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Add_Click(object sender, EventArgs e)
    {
        Model.Type type = new Model.Type();
        type.Language = 0;
        type.Name = this.tbName.Text.Trim();
        type.Order = Int32.Parse(this.tbOrder.Text);
        TypeManager.Add(type);
        this.GridView1.DataBind();
    }
}
