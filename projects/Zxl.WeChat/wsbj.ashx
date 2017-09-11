<%@ WebHandler Language="C#" Class="wsbj" %>

using System;
using System.Web;

public class wsbj : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string action = "";
        if (null != context.Request.QueryString["action"])
            action = context.Request.QueryString["action"].ToString();

        if (action == "Businesses")
        {
            context.Response.Write("{\"11\": \"Unrecognized action!\"}");
        }
        else if (action == "Assessments")
        {
            context.Response.Write("{\"22\": \"Unrecognized action!\"}");
        }
        else if (action == "Account")
        {
            //string accountId = context.Request["accountId"].ToString();
            //WWBJUser user  = wwbjService.getu
        }
        else
        {
            context.Response.Write("{\"error\": \"Unrecognized action!\"}");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}