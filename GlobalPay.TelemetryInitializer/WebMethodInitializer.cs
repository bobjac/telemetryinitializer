using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using System.Linq;

namespace GlobalPay.TelemetryInitializer
{
    public class WebMethodInitializer : ITelemetryInitializer
    {
        public WebMethodInitializer()
        {

        }
        public void Initialize(ITelemetry telemetry)
        {
            var requestTelemetry = telemetry as RequestTelemetry;
            string soapActionMethod = null;
            string requestMethodName = null;
            string webServiceMethod = null;

            // Is this a TrackRequest() ?
            if (requestTelemetry == null) return;
            requestMethodName = System.Web.HttpContext.Current.Request.Params["op"]; // Item("HTTP_SOAPACTION");

            if (requestMethodName == "" || requestMethodName == null)
            {
                if (System.Web.HttpContext.Current.Request.PathInfo != null)
                {
                    requestMethodName = System.Web.HttpContext.Current.Request.PathInfo;
                }

                if (requestMethodName != "" && requestMethodName != null)
                {
                    requestMethodName = requestMethodName.Replace("/", "");
                    // If we set the Success property, the SDK won't change it:
                    requestTelemetry.Success = true;
                    // Allow us to filter these requests in the portal:
                    requestTelemetry.Properties["WebMethodName"] = requestMethodName;
                    webServiceMethod = requestMethodName;
                }
            }


            string soapAction = System.Web.HttpContext.Current.Request.Headers["SOAPAction"];

            if (soapAction != null)
            {
                soapAction = soapAction.Replace("\"", "");
                soapActionMethod = soapAction.Split('/').Last();
                requestTelemetry.Properties["SOAPAction"] = soapAction;
                webServiceMethod = soapActionMethod;
            }

            if (webServiceMethod != null)
            {
                requestTelemetry.Context.Operation.Name = requestTelemetry.Context.Operation.Name.Replace("/" + webServiceMethod, "") + "/" + webServiceMethod;
            }
        }
    }
}
