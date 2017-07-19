using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AopApi
{
    [ServiceContract]
    public interface IAopService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/PagePay/{content}", RequestFormat = WebMessageFormat.Json)]
        string PagePay(string content);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Auth", RequestFormat = WebMessageFormat.Json)]
        string Auth(string content);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Refund", RequestFormat = WebMessageFormat.Json)]
        string Refund(string content);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Close", RequestFormat = WebMessageFormat.Json)]
        string Close(string content);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Query", RequestFormat = WebMessageFormat.Json)]
        string Query(string content);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/RefundQuery", RequestFormat = WebMessageFormat.Json)]
        string RefundQuery(string content);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/DownloadURLQuery", RequestFormat = WebMessageFormat.Json)]
        string DownloadURLQuery(string content);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Check", RequestFormat = WebMessageFormat.Json)]
        string Check(string content);
    }
}
