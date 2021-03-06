﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Principal_view_sch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Sessioninfo();
        displaypic();
    }
    public void Sessioninfo()
    {
        HttpCookie myCookiepr = Request.Cookies["myCookiepr"];


        if (myCookiepr != null)
        {

            string userId = myCookiepr["prnm"];

            DataSet dss = new DataSet();
            Select sels = new Select();
            dss = sels.selectprinci(userId);
            if (dss.Tables[0].Rows.Count == 1)
            {
                // lbltchnm.Text = dss.Tables[0].Rows[0]["name"].ToString();
                lblsch.Text = dss.Tables[0].Rows[0]["school"].ToString();
            }
            else
            {
                string message1 = "Login Session Expired....Please Login again.";
                string script = "window.onload = function(){ alert('";
                script += message1;
                script += "');";
                script += "window.location = '";
                script += Request.Url.AbsoluteUri;
                script += "'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

                Response.Redirect("../Principallogin.aspx");
            }
        }
    }

    public void displaypic()
    {
         DataSet dss = new DataSet();
        Select sels = new Select();
        dss = sels.selectpic(lblsch.Text);
        if (dss.Tables[0].Rows.Count == 1)
        {
            lbladdr.Text = dss.Tables[0].Rows[0]["schooladdr"].ToString();
            imgsch.ImageUrl = "~/Principal/img/" + dss.Tables[0].Rows[0]["pic"].ToString();
        }
    }
}