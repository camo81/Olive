
using System.Net;
using Xamarin.Forms;
using System;
using Olive.Droid.DS;

[assembly: Dependency(typeof(WebRequest_android))]

namespace Olive.Droid.DS
{
    class WebRequest_android : Olive.Model.IWebRequest
    {
        public string apriCancello(string Username,string Password,string IpAddress,string IpAddressExt)
        {
            ///control/rcontrol?action=customfunction&action=sigout&profile=~LightToggle
            ///
            string IPA = "";
            
            try
            {
                var external = Dns.Resolve(IpAddressExt);

                if (external != null)
                {
                    IPA = IpAddressExt;
                }

            }
            catch (Exception e)
            {
                IPA = IpAddress;
            }

            string urlServizio = $"{IPA}/control/rcontrol?action=customfunction&action=sigout&profile=~Door";
            CredentialCache cache = new CredentialCache();
            // Create a request for the URL. 	

            WebRequest request = WebRequest.Create(urlServizio);
            // If required by the server, set the credentials.
            NetworkCredential credenziali = new NetworkCredential(Username, Password);
            cache.Add(new Uri(urlServizio), "Basic", credenziali);
            request.Credentials = cache;

            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            response.Close();

            

            return IPA;

        }
    }

}
