<%@ WebHandler Language="C#" Class="TestService" %>

using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Text;
using System.Web.Security;
using System.Xml;


using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Net;

public class TestService : IHttpHandler
{

    //static string appID = "wxda6a26dffe3db1ca";
    //static string appsecret = "f0d9056d9a536350a81b564c7e8a14e0";
    //static string URL = "http://125.70.229.20/Test/TestService.ashx ";
    //static string Token = "za59418";

    public void ProcessRequest(HttpContext param_context)
    {
        string postString = string.Empty;
        if (HttpContext.Current.Request.HttpMethod.ToUpper() == "POST")
        {
            /**
             * 接收消息
             *  <xml>
             *    <ToUserName><![CDATA[toUser]]></ToUserName>
             *    <FromUserName><![CDATA[fromUser]]></FromUserName>
             *    <CreateTime>20170728</CreateTime>
             *    <MsgType><![CDATA[text]]></MsgType>
             *    <Content><![CDATA[this is a test]]></Content>
             *    <MsgId>1234567890123456</MsgId>
             *  </xml>
             **/            
            using (Stream stream = HttpContext.Current.Request.InputStream)
            {
                Byte[] postBytes = new Byte[stream.Length];
                stream.Read(postBytes, 0, (Int32)stream.Length);
                postString = Encoding.UTF8.GetString(postBytes);
                Handle(postString);
            }
        }
        else
        {
            Auth();
        }
    }

    /// <summary>
    /// 处理信息并应答
    /// </summary>
    private void Handle(string postStr)
    {
        messageHelp help = new messageHelp();
        string responseContent = help.ReturnMessage(postStr);

        HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
        HttpContext.Current.Response.Write(responseContent);
    }

    //成为开发者url测试，返回echoStr
    public void Auth()
    {
        string token = "za59418";
        if (string.IsNullOrEmpty(token))
        {
            return;
        }

        string echoString = HttpContext.Current.Request.QueryString["echoStr"];
        string signature = HttpContext.Current.Request.QueryString["signature"];
        string timestamp = HttpContext.Current.Request.QueryString["timestamp"];
        string nonce = HttpContext.Current.Request.QueryString["nonce"];

        if (!string.IsNullOrEmpty(echoString))
        {
            HttpContext.Current.Response.Write(echoString);
            HttpContext.Current.Response.End();
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}