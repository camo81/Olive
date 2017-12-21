
using System.Net;
using Xamarin.Forms;
using System;
using Olive.Droid.DS;
using System.Net.NetworkInformation;

[assembly: Dependency(typeof(WebRequest_android))]

namespace Olive.Droid.DS
{
    class WebRequest_android : Olive.Model.IWebRequest
    {
        public string apriCancello(string Username,string Password, string IpAddress = "", string IpAddressExt="")
        {
            ///control/rcontrol?action=customfunction&action=sigout&profile=~LightToggle
            ///

            string IPA = "";
            try
            {
                var ping = new Ping();
                string[] IpAddressClean = IpAddress.Split('/');
                int i = 0;
                i = i + 1;
                PingReply reply = ping.Send(IpAddressClean[2]);
                IPA = IpAddress;
            }
            catch (Exception e)
            {

                
            }

           
            if (! string.IsNullOrWhiteSpace(IpAddressExt))
            {

                try
                {
                string[] substrings = IpAddressExt.Split(':');
                string[] domain = substrings[1].Split('/');
                var external = Dns.Resolve(domain[2]);
                IPA = IpAddressExt;
                }
                catch (Exception e)
                {

                }
            }
            
           

            if (! string.IsNullOrWhiteSpace(IPA) )

            {
                string urlServizio = $"{IPA}/control/rcontrol?action=customfunction&action=sigout&profile=~Door";
                CredentialCache cache = new CredentialCache();
                // Create a request for the URL. 	

                WebRequest request = WebRequest.Create(urlServizio);
                // If required by the server, set the credentials.
                NetworkCredential credenziali = new NetworkCredential(Username, Password);
                cache.Add(new Uri(urlServizio), "Basic", credenziali);
                request.Credentials = cache;

                // Get the response.
                try
                {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    response.Close();
                }
                catch (Exception e)
                {
                    return "";
                }
                
                
                
            }
            return IPA;


        }
    }

}
