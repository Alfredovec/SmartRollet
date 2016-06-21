using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Services;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Auth0;
using Auth0.AspNet;
using SmartRollet.Web.Models;

namespace SmartRollet.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly Client _client = new Client(
                                ConfigurationManager.AppSettings["auth0:ClientId"],
                                ConfigurationManager.AppSettings["auth0:ClientSecret"],
                                ConfigurationManager.AppSettings["auth0:Domain"]);

        public ActionResult LoginCallback(string code, string redirectUri)
        {
            var token = _client.ExchangeAuthorizationCodePerAccessToken(
                code,
                $"{HttpContext.Request.Url.Scheme}://{HttpContext.Request.Url.Host}");

            var profile = _client.GetUserInfo(token);

            var user = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("name", profile.Name),
                new KeyValuePair<string, object>("email", profile.Email),
                new KeyValuePair<string, object>("family_name", profile.FamilyName),
                new KeyValuePair<string, object>("gender", profile.Gender),
                new KeyValuePair<string, object>("given_name", profile.GivenName),
                new KeyValuePair<string, object>("nickname", profile.Nickname),
                new KeyValuePair<string, object>("picture", profile.Picture),
                new KeyValuePair<string, object>("user_id", profile.UserId),
                new KeyValuePair<string, object>("id_token", token.IdToken),
                new KeyValuePair<string, object>("access_token", token.AccessToken),
                new KeyValuePair<string, object>("connection", profile.Identities.First().Connection),
                new KeyValuePair<string, object>("provider", profile.Identities.First().Provider)
            };

            FederatedAuthentication.SessionAuthenticationModule.CreateSessionCookie(user);

            if (HttpContext.Request.QueryString["state"] != null && HttpContext.Request.QueryString["state"].StartsWith("ru="))
            {
                var state = HttpUtility.ParseQueryString(HttpContext.Request.QueryString["state"]);
                HttpContext.Response.Redirect(state["ru"], true);
            }

            var httpClient = new HttpClient();
            var response = httpClient.GetAsync(@"http://api.smart-rollet.com/account?email=" + profile.Email).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;

            if (responseString == null)
            {
                var values = new Dictionary<string, string>
                {
                    { "Email", profile.Email }
                };

                var postContent = new FormUrlEncodedContent(values);
                response = httpClient.PostAsync(@"http://api.smart-rollet.com/account", postContent).Result;
            }

            return RedirectToAction("Manage", "Rollet");
        }

        public ActionResult Logout()
        {
            FederatedAuthentication.SessionAuthenticationModule.SignOut();

            return RedirectToAction("Manage", "Rollet");
        }
    }
}
