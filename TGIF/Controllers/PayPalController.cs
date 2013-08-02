using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TGIF.Models;

namespace TGIF.Controllers
{
    public class PayPalController : Controller
    {
        /// <summary>
        /// Required internal variable that lets us know if
        /// we are returning from PayPal. This flag can be used
        /// to bypass other processing that might be happening
        /// for Credit Cards or whatever.
        /// 
        /// This gets set by HandlePayPalReturn. Not used in this
        /// demo. Refer to article to see how it's used in a more
        /// complex environment.
        /// </summary>
        //private bool PayPalReturnRequest = false;

        /// <summary>
        /// Our ever so complicated ORDER DATA. Hey this is supposed to be 
        /// a quick demo and skeleton, so I kept it as simple as possible.
        /// The article shows a more complex environment!
        /// </summary>
        protected decimal OrderAmount = 0.00M;

        //
        // Paypal Payment
        //public ActionResult PostToPayPal(string item, string amount)
        //{
        //    TGIF.Models.PayPal paypal = new Models.PayPal();
        //    paypal.cmd = "_xclick";
        //    paypal.business = ConfigurationManager.AppSettings["BusinessAccountKey"];

        //    bool useSandbox = Convert.ToBoolean(ConfigurationManager.AppSettings["UseSandbox"]);
        //    if (useSandbox)
        //        ViewBag.actionURL = "https://www.sandbox.paypal.com/cgi-bin/webscr";
        //    else
        //        ViewBag.actionURL = "https://www.paypal.com/cgi-bin/webscr";

        //    paypal.cancel_return = ConfigurationManager.AppSettings["CancelURL"];
        //    paypal.@return = ConfigurationManager.AppSettings["ReturnURL"]; //+"&PaymentId=1"; you can append your order Id here
        //    paypal.notify_url = ConfigurationManager.AppSettings["NotifyURL"];// +"?PaymentId=1"; to maintain database logic 

        //    paypal.currency_code = ConfigurationManager.AppSettings["CurrencyCode"];

        //    paypal.item_name = item;
        //    paypal.amount = amount;
        //    return View(paypal);

        //    //            curl -s --insecure https://api-3t.sandbox.paypal.com/nvp -d
        //    //"USER=subgeet-facilitator_api1.hotmail.com
        //    //&PWD=1363113260
        //    //&SIGNATURE=AIez27zXPZ6ch2lUwgJJbWqw3znpAZUVIlr0qhN2tC2ndvdWO-uw7NzG
        //    //  &METHOD=SetExpressCheckout
        //    //  &VERSION=98
        //    //  &PAYMENTREQUEST_0_AMT=10
        //    //  &PAYMENTREQUEST_0_CURRENCYCODE=USD
        //    //  &PAYMENTREQUEST_0_PAYMENTACTION=SALE
        //    //  &cancelUrl=http://www.example.com/cancel.html
        //    //  &returnUrl=http://www.example.com/success.html"
        //}
        [HttpGet]
        public ActionResult PaypalTest()
        {
            ViewBag.Message = "TGIF Pay pal testing.";

            return View();
        }

        public ActionResult PaypalTest(bool paypalReturn = false)
        {
            return View();
        }

        [HttpPost] 
        public ActionResult PostToPayPal(string item, string amount)
        {
            // *** Set a flag so we know we redirected to minimize spoofing
            Session["PayPal_Redirected"] = "True";

            // *** Save the Notes and Types so we can restore them later
            Session["PayPal_Notes"] = "";
            Session["PayPal_HeardFrom"] = "";
            Session["PayPal_ToolUsed"] = "";

            PayPal PayPal = new PayPal();

            bool useSandbox = Convert.ToBoolean(ConfigurationManager.AppSettings["UseSandbox"]);
            if (useSandbox)
                PayPal.PayPalBaseUrl = ConfigurationManager.AppSettings["PayPalDevelopURL"];
            else
                PayPal.PayPalBaseUrl = ConfigurationManager.AppSettings["PayPalURL"];

            PayPal.BusinessEmail = ConfigurationManager.AppSettings["BusinessEmail"];
            PayPal.BusinessPwd = ConfigurationManager.AppSettings["BusinessPwd"];
            PayPal.BusinessSignature = ConfigurationManager.AppSettings["BusinessSignature"];
            PayPal.BuyerEmail = ConfigurationManager.AppSettings["User"];
            PayPal.LogoUrl = ConfigurationManager.AppSettings["LogoURL"];
            PayPal.Amount = Convert.ToDecimal(amount);
            PayPal.ItemName = item;

            PayPal.SuccessUrl = Request.Url + "?PayPal=Success";
            PayPal.CancelUrl = Request.Url + "?PayPal=Cancel";       
                     
            //PayPal.InvoiceNo = rowInv.Invno;
            //PayPal.BuyerEmail = this.Invoice.Customer.GetTypedDataRow().Email;

            @ViewBag.actionURL = PayPal.GetSubmitUrl();
            return Redirect(@ViewBag.actionURL);
            //Response.Redirect(PayPal.GetSubmitUrl());

            //return View(PayPal); 
        }

        
    }
}
