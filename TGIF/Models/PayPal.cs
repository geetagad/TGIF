using InternetTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace TGIF.Models
{
    public class PayPal
    {
        public PayPal()
        {
        }

        //public string cmd { get; set; }
        //public string business { get; set; }   
        //public string no_shipping { get; set; }
        //public string @return { get; set; }
        //public string cancel_return { get; set; }
        //public string notify_url { get; set; }
        //public string currency_code { get; set; }
        //public string item_name { get; set; }
        //public string amount { get; set; }

        public string LogoUrl = "";
        public string BusinessEmail = "";
        public string BusinessPwd = "";
        public string BusinessSignature = "";
        public string BuyerEmail = "";
        public string SuccessUrl = "";
        public string CancelUrl = "";
        public string ItemName = "";
        public decimal Amount = 0.00M;
        public string InvoiceNo = "";
        public string PayPalBaseUrl = "";

       public string LastResponse = "";

        public string GetSubmitUrl()
        {
            StringBuilder url = new StringBuilder();

            //
            url.Append(this.PayPalBaseUrl + "cmd=_express-checkout&USER=" +
                HttpUtility.UrlEncode(BusinessEmail));
            //url.Append(this.PayPalBaseUrl + "cmd=_xclick&business=" +     HttpUtility.UrlEncode(BusinessEmail));

            if (BusinessPwd != null && BusinessPwd != "")
                url.AppendFormat("&PWD={0}", HttpUtility.UrlEncode(BusinessPwd));

            if (BusinessSignature != null && BusinessSignature != "")
                url.AppendFormat("&SIGNATURE={0}", HttpUtility.UrlEncode(BusinessSignature));

            //url.AppendFormat("&METHOD={0}", "SetExpressCheckout");
            //VERSION=72.0

            //if (Amount != 0.00M)
            //    url.AppendFormat("&amount={0:f2}", Amount);

            if (Amount != 0.00M)
            {
                url.AppendFormat("&PAYMENTREQUEST_0_AMT={0:f2}", Amount);
                url.AppendFormat("&PAYMENTREQUEST_0_CURRENCYCODE={0}","USD");
                url.AppendFormat("&PAYMENTREQUEST_0_PAYMENTACTIOND={0}", "Sale");
            }
          
           
            //if (LogoUrl != null && LogoUrl != "")
            //    url.AppendFormat("&image_url={0}", HttpUtility.UrlEncode(LogoUrl));

            //if (ItemName != null && ItemName != "")
            //    url.AppendFormat("&item_name={0}", HttpUtility.UrlEncode(ItemName));

            //if (InvoiceNo != null && InvoiceNo != "")
            //    url.AppendFormat("&invoice={0}", HttpUtility.UrlEncode(InvoiceNo));

            if (SuccessUrl != null && SuccessUrl != "")
            {
                //url.AppendFormat("&return={0}", HttpUtility.UrlEncode(SuccessUrl));
                url.AppendFormat("&RETURNURL={0}", HttpUtility.UrlEncode(SuccessUrl));
                
            }

            if (CancelUrl != null && CancelUrl != "")
            {
                //url.AppendFormat("&cancel_return={0}", HttpUtility.UrlEncode(CancelUrl));
                url.AppendFormat("&CANCELURL={0}", HttpUtility.UrlEncode(CancelUrl));
            }

            return url.ToString();
        }

        /// <summary>
        /// Posts all form variables received back to PayPal. This method is used on 
        /// is used for Payment verification from the 
        /// </summary>
        /// <returns>Empty string on success otherwise the full message from the server</returns>
        public bool IPNPostDataToPayPal(string PayPalUrl, string PayPalEmail)
        {
            HttpRequest Request = HttpContext.Current.Request;
            this.LastResponse = "";

            // *** Make sure our payment goes back to our own account
            string Email = Request.Form["receiver_email"];
            if (Email == null || Email.Trim().ToLower() != PayPalEmail.ToLower())
            {
                this.LastResponse = "Invalid receiver email";
                return false;
            }

            wwHttp Http = new wwHttp();
            Http.AddPostKey("cmd", "_notify-validate");

            foreach (string postKey in Request.Form)
                Http.AddPostKey(postKey, Request.Form[postKey]);

            // *** Retrieve the HTTP result to a string
            this.LastResponse = Http.GetUrl(PayPalUrl);

            if (this.LastResponse == "VERIFIED")
                return true;

            return false;
        }
    }
    
}