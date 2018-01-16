using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SignalR.Helper
{
    public static class ExtentionMethod
    {
        public static void SendSMS(string strPhoneNumber, string strBody)
        {
            // Find your Account Sid and Auth Token at twilio.com/user/account
            string accountSid = GetSmsAccountSid();
            //"AC283d289fa6894f38ed141d070fb1e0de";
            string authToken = GetSmsAuthToken();
            //"9dee64c9014a129f17d9298915369fb2";

            // Initialize the Twilio client
            TwilioClient.Init(accountSid, authToken);

            // make an associative array of people we know, indexed by phone number

            // Send a new outgoing SMS by POSTing to the Messages resource
            MessageResource.Create(
                from: new PhoneNumber(GetFromPhoneNumber()), // From number, must be an SMS-enabled Twilio number
                to: new PhoneNumber(strPhoneNumber), // To number, if using Sandbox see note above                      
                body: strBody);// Message content
        }
        public static string GetSmsAccountSid()
        {

            return "AC283d289fa6894f38ed141d070fb1e0de";

        }
        public static string GetSmsAuthToken()
        {
            return "9dee64c9014a129f17d9298915369fb2";
        }
        public static string GetFromPhoneNumber()
        {
            return "+12017201084";
        }
    }
}