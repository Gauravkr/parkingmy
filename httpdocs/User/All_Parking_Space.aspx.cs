﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_All_Parking_Space : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["Expire"] != "0")
            {
               
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "alert('Your Subscription Pack Is Expired..Please Renew Your pack')", true);
            }
        }
        catch
        {
            Response.Redirect("../Default.aspx");
        }
    }
    private void Page_Error(object sender, EventArgs e)
    {
        // Get last error from the server
        Exception exc = Server.GetLastError();

        // Handle exceptions generated by Button 1
        if (exc is InvalidOperationException)
        {
            // Pass the error on to the Generic Error page
            Server.Transfer("GenericErrorPage.aspx", true);
        }

        // Handle exceptions generated by Button 2
        else if (exc is ArgumentOutOfRangeException)
        {
            // Give the user some information, but
            // stay on the default page
            Response.Write("<h2>Default Page Error</h2>\n");
            Response.Write("<p>Provide as much information here as is " +
              "appropriate to show to the client.</p>\n");
            Response.Write("Return to the <a href='Default.aspx'>" +
                "Default Page</a>\n");

            // Log the exception and notify system operators
            ParkingMy.Logic.ExceptionUtility.LogException(exc, "DefaultPage");
            ParkingMy.Logic.ExceptionUtility.NotifySystemOps(exc);

            // Clear the error from the server
            Server.ClearError();
        }
        else
        {
            // Pass the error on to the default global handler
        }
    }
}