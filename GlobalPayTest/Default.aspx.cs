﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.Label1.Text = this.TextBox1.Text;
    }

    protected void WebServiceBtn_Click(object sender, EventArgs e)
    {
        ServiceReference1.WebServiceSoapClient client = new ServiceReference1.WebServiceSoapClient();
        this.WebServiceLbl.Text = client.HelloWorld();
    }
}