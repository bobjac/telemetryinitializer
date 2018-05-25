using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using log4net;
using log4net.Appender;
using log4net.Config;
/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    private static readonly ILog logger = LogManager.GetLogger(typeof(WebService));

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        DOMConfigurator.Configure();

        logger.Debug("Here is a debug log");
        logger.Info("... and an Info log.");
        logger.Warn("... and a warning.");
        logger.Error("... and an error.");
        logger.Fatal("... and a fatal error.");
        return "Hello World";
    }

}
