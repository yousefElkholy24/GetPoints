using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway
{
    public class TAPGateway
    {
        public string GoPayLive(string Amount,string OrderID,string CustomerName,string CustomerEmail, string CustomerID)
        {

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            var client = new RestClient("https://api.tap.company/v2/charges");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("authorization", "Bearer sk_test_XKokBfNWv6FIYuTMg5sLPjhJ");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\r\n    \"amount\": " + Amount + ",\r\n    \"currency\": \"KWD\",\r\n    \"threeDSecure\": true,\r\n    \"save_card\": false,\r\n    \"description\": \"Get Points\",\r\n    \"statement_descriptor\": \"Get Points\",\r\n    \"metadata\": {\r\n        \"udf1\": \"test 1\",\r\n        \"udf2\": \"test 2\"\r\n    },\r\n    \"reference\": {\r\n        \"transaction\": \"" + OrderID + "\",\r\n        \"order\": \"" + OrderID + "\"\r\n    },\r\n    \"receipt\": {\r\n        \"email\": false,\r\n        \"sms\": false\r\n    },\r\n    \"customer\": {\r\n        \"first_name\": \"" + CustomerName + "\",\r\n        \"middle_name\": \"\",\r\n        \"last_name\": \"\",\r\n        \"email\": \"" + CustomerEmail + "\",\r\n        \"phone\": {\r\n            \"country_code\": \"965\",\r\n            \"number\": \"11111111\"\r\n        }\r\n    },\r\n    \"merchant\": {\r\n        \"id\": \"\"\r\n    },\r\n    \"source\": {\r\n        \"id\": \"src_all\"\r\n    },\r\n    \"post\": {\r\n        \"url\": \"http://www.get-points.com/PaymentResult.aspx\"\r\n    },\r\n    \"redirect\": {\r\n        \"url\": \"http://www.get-points.com/PaymentResult.aspx?CID=" + CustomerID + "&SID=" + OrderID + "\"\r\n    }\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }


         public IRestResponse GoPayLive2(string Amount, string OrderID, string CustomerName, string CustomerEmail, string CustomerID)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            var client = new RestClient("https://api.tap.company/v2/charges");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("authorization", "Bearer sk_test_XKokBfNWv6FIYuTMg5sLPjhJ");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\r\n    \"amount\": " + Amount + ",\r\n    \"currency\": \"KWD\",\r\n    \"threeDSecure\": true,\r\n    \"save_card\": false,\r\n    \"description\": \"Get Points\",\r\n    \"statement_descriptor\": \"Get Points\",\r\n    \"metadata\": {\r\n        \"udf1\": \"test 1\",\r\n        \"udf2\": \"test 2\"\r\n    },\r\n    \"reference\": {\r\n        \"transaction\": \"" + OrderID + "\",\r\n        \"order\": \"" + OrderID + "\"\r\n    },\r\n    \"receipt\": {\r\n        \"email\": false,\r\n        \"sms\": false\r\n    },\r\n    \"customer\": {\r\n        \"first_name\": \"" + CustomerName + "\",\r\n        \"middle_name\": \"\",\r\n        \"last_name\": \"\",\r\n        \"email\": \"" + CustomerEmail + "\",\r\n        \"phone\": {\r\n            \"country_code\": \"965\",\r\n            \"number\": \"11111111\"\r\n        }\r\n    },\r\n    \"merchant\": {\r\n        \"id\": \"\"\r\n    },\r\n    \"source\": {\r\n        \"id\": \"src_all\"\r\n    },\r\n    \"post\": {\r\n        \"url\": \"http://www.get-points.com/PaymentResult.aspx\"\r\n    },\r\n    \"redirect\": {\r\n        \"url\": \"http://www.get-points.com/PaymentResult.aspx?CID=" + CustomerID + "&SID=" + OrderID + "\"\r\n    }\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response;
        }

        public string GoPayProduction(string Amount, string OrderID, string CustomerName, string CustomerEmail)
        {

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            var client = new RestClient("https://api.tap.company/v2/charges");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("authorization", "Bearer sk_live_IRYdmzbZVw27e5sq4T6BAnUa");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\r\n    \"amount\": " + Amount + ",\r\n    \"currency\": \"KWD\",\r\n    \"threeDSecure\": true,\r\n    \"save_card\": false,\r\n    \"description\": \"MaxForex\",\r\n    \"statement_descriptor\": \"MaxForex\",\r\n    \"metadata\": {\r\n        \"udf1\": \"test 1\",\r\n        \"udf2\": \"test 2\"\r\n    },\r\n    \"reference\": {\r\n        \"transaction\": \"" + OrderID + "\",\r\n        \"order\": \"" + OrderID + "\"\r\n    },\r\n    \"receipt\": {\r\n        \"email\": false,\r\n        \"sms\": false\r\n    },\r\n    \"customer\": {\r\n        \"first_name\": \"" + CustomerName + "\",\r\n        \"middle_name\": \"\",\r\n        \"last_name\": \"\",\r\n        \"email\": \"" + CustomerEmail + "\",\r\n        \"phone\": {\r\n            \"country_code\": \"965\",\r\n            \"number\": \"11111111\"\r\n        }\r\n    },\r\n    \"merchant\": {\r\n        \"id\": \"\"\r\n    },\r\n    \"source\": {\r\n        \"id\": \"src_all\"\r\n    },\r\n    \"post\": {\r\n        \"url\": \"https://maxforex.net/FailedPayment.aspx\"\r\n    },\r\n    \"redirect\": {\r\n        \"url\": \"https://maxforex.net/TAPSuccess.aspx?SID=" + OrderID + "\"\r\n    }\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public string GoPayTest(string Amount, string OrderID, string CustomerName, string CustomerEmail,string CustomerID)
        {

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            var client = new RestClient("https://api.tap.company/v2/charges");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("authorization", "Bearer sk_test_XKokBfNWv6FIYuTMg5sLPjhJ");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\r\n    \"amount\": " + Amount + ",\r\n    \"currency\": \"KWD\",\r\n    \"threeDSecure\": true,\r\n    \"save_card\": false,\r\n    \"description\": \"Get Points\",\r\n    \"statement_descriptor\": \"Get Points\",\r\n    \"metadata\": {\r\n        \"udf1\": \"test 1\",\r\n        \"udf2\": \"test 2\"\r\n    },\r\n    \"reference\": {\r\n        \"transaction\": \"" + OrderID + "\",\r\n        \"order\": \"" + OrderID + "\"\r\n    },\r\n    \"receipt\": {\r\n        \"email\": false,\r\n        \"sms\": false\r\n    },\r\n    \"customer\": {\r\n        \"first_name\": \"" + CustomerName + "\",\r\n        \"middle_name\": \"\",\r\n        \"last_name\": \"\",\r\n        \"email\": \"" + CustomerEmail + "\",\r\n        \"phone\": {\r\n            \"country_code\": \"965\",\r\n            \"number\": \"11111111\"\r\n        }\r\n    },\r\n    \"merchant\": {\r\n        \"id\": \"\"\r\n    },\r\n    \"source\": {\r\n        \"id\": \"src_all\"\r\n    },\r\n    \"post\": {\r\n        \"url\": \"http://localhost:63564/PaymentResult.aspx\"\r\n    },\r\n    \"redirect\": {\r\n        \"url\": \"http://localhost:63564/PaymentResult.aspx?CID=" + CustomerID +"&SID=" + OrderID + "\"\r\n    }\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
        public string GetChargeInfo(string Tap_ID)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
          
            var client = new RestClient("https://api.tap.company/v2/charges/" + Tap_ID);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "Bearer sk_test_XKokBfNWv6FIYuTMg5sLPjhJ");
            request.AddParameter("text/plain", "", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public string GetChargeInfoProduction(string Tap_ID)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var client = new RestClient("https://api.tap.company/v2/charges/" + Tap_ID);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "Bearer sk_live_IRYdmzbZVw27e5sq4T6BAnUa");
            request.AddParameter("text/plain", "", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }


        public string GetJArrayValue(JObject yourJArray, string key)
        {
            foreach (KeyValuePair<string, JToken> keyValuePair in yourJArray)
            {
                if (key == keyValuePair.Key)
                    return keyValuePair.Value.ToString();
            }
            return "";
        }

    }
}
