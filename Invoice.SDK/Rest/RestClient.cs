using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.SDK.Rest
{
    public class RestClient
    {
        public Uri Url { get; set; } = new Uri("https://api.invoice.su/api/v2/");

        public string Merchant { get; } 

        public string Key { get; }

        public delegate void PrintDelegate(string message);
        public PrintDelegate Print;

        public RestClient(string merchantid, string apikey) 
        {
            Merchant = merchantid;
            Key = apikey;
            JsonConvert.DefaultSettings = (() =>
            {
                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new StringEnumConverter { CamelCaseText = true });
                return settings;
            });
        }

        private async Task<string> SendAsync(string requestType, string json)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Url + requestType);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Timeout = 30000;
                httpWebRequest.Accept = "*/*";
                httpWebRequest.UserAgent = "curl/7.55.1";
                httpWebRequest.KeepAlive = false;
                httpWebRequest.ServicePoint.Expect100Continue = false;

                var base64authorization = Convert.ToBase64String(Encoding.Default.GetBytes($"{Merchant}:{Key}"));
                httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, string.Format("Basic {0}", base64authorization));

                print(requestType);
                print(json);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    streamWriter.Write(json);

                using (var streamReader = new StreamReader(httpWebRequest.GetResponse().GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Print(result);
                    return result;
                }
            }
            catch(Exception exc)
            {
                print(exc);
                return "{ \"error\" : \"404\", \"description\" : \"" + exc.Message + "\" }";
            }
        }

        public PaymentInfo CreateRecurrentPayment(CREATE_RECURRENT_PAYMENT request)
        {
            string response = SendAsync("RecurringPayment", JsonConvert.SerializeObject(request)).Result;
            return JsonConvert.DeserializeObject<PaymentInfo>(response);
        }
        public RefundInfo CreateRefund(CREATE_REFUND request)
        {
            string response = SendAsync("CreateRefund", JsonConvert.SerializeObject(request)).Result;
            return JsonConvert.DeserializeObject<RefundInfo>(response);
        }
        public RefundInfo GetRefund(GET_REFUND request)
        {
            string response = SendAsync("GetRefund", JsonConvert.SerializeObject(request)).Result;
            return JsonConvert.DeserializeObject<RefundInfo>(response);
        }
        public PaymentInfo CreatePayment(CREATE_PAYMENT request)
        {
            string response = SendAsync("CreatePayment", JsonConvert.SerializeObject(request)).Result;
            return JsonConvert.DeserializeObject<PaymentInfo>(response);
        }
        public PaymentInfo GetPaymentByOrder(GET_PAYMENT_FROM_ORDER request)
        {
            string response = SendAsync("GetPaymentByOrder", JsonConvert.SerializeObject(request)).Result;
            return JsonConvert.DeserializeObject<PaymentInfo>(response);
        }
        public PaymentInfo GetPayment(GET_STATUS_BY_PAYMENT_ID request)
        {
            string response = SendAsync("GetPayment", JsonConvert.SerializeObject(request)).Result;
            return JsonConvert.DeserializeObject<PaymentInfo>(response);
        }
        public PaymentInfo ClosePayment(CLOSE_PAYMENT request)
        {
            string response = SendAsync("ClosePayment", JsonConvert.SerializeObject(request)).Result;
            return JsonConvert.DeserializeObject<PaymentInfo>(response);
        }
        public TerminalInfo CreateTerminal(CREATE_TERMINAL request)
        {
            string response = SendAsync("CreateTerminal", JsonConvert.SerializeObject(request)).Result;
            return JsonConvert.DeserializeObject<TerminalInfo>(response);
        }
        public TerminalInfo GetTerminal(GET_TERMINAL request)
        {
            string response = SendAsync("GetTerminal", JsonConvert.SerializeObject(request)).Result;
            return JsonConvert.DeserializeObject<TerminalInfo>(response);
        }
        public PointOfSaleInfo CreatePointOfSale(CREATE_POINT_OF_SALES request)
        {
            string response = SendAsync("CreatePointOfSale", JsonConvert.SerializeObject(request)).Result;
            return JsonConvert.DeserializeObject<PointOfSaleInfo>(response);
        }
        public PointOfSaleInfo GetPointOfSale(GET_POINT_OF_SALES request)
        {
            string response = SendAsync("GetPointOfSale", JsonConvert.SerializeObject(request)).Result;
            return JsonConvert.DeserializeObject<PointOfSaleInfo>(response);
        }

        private void print(params object[] objs) =>
            Print(string.Join(", ", objs));
    }
}