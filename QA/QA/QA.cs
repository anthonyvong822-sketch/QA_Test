using NUnit.Framework;
using QA.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace QA
{
    public class LoginTest
    {
        private readonly HttpClient _client = new HttpClient();
        private const string LoginUrl = "https://automationexercise.com/api/verifyLogin";
        private string responseString = null;
        public async Task<string> VerifyLoginAsync(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email)) responseString = "User Name is empty";
            if (string.IsNullOrWhiteSpace(password)) responseString = "Password is empty";
            if (string.IsNullOrWhiteSpace(responseString))
            {
                var POST_URL = $"{LoginUrl}?email={Uri.EscapeDataString(email)}&password={Uri.EscapeDataString(password)}";
                using (var request = new HttpRequestMessage(HttpMethod.Post, POST_URL))
                {
                    request.Content = new StringContent("", null, "text/plain");
                    using (var response = await _client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode();
                        responseString = await response.Content.ReadAsStringAsync();                  
                    }
                }
            }
            return responseString;
        }
    }
    public class RegisterTest
    {
        private const string RegisterUrl = "https://automationexercise.com/api/createAccount";
        private string responseString = null;
        public async Task<string> VerifyRegisterAsync(string name,string email, string password,string title,string birth_date,string birth_month,string birth_year,string firstname,string lastname,string company,string address1,string address2,string country,string zipcode,string state,string city,string mobile_number)
        {
            UserAccount _UserAccount = new UserAccount();
            _UserAccount.Name = name;
            _UserAccount.Email = email;
            _UserAccount.Password = password;
            _UserAccount.Title = title;
            _UserAccount.BirthDate = birth_date;
            _UserAccount.BirthMonth = birth_month;
            _UserAccount.BirthYear = birth_year;
            _UserAccount.Firstname = firstname;
            _UserAccount.Lastname = lastname;
            _UserAccount.Company = company;
            _UserAccount.Address1 = address1;
            _UserAccount.Address2 = address2;
            _UserAccount.Country = country;
            _UserAccount.Zipcode = zipcode;
            _UserAccount.State = state;
            _UserAccount.City = city;
            _UserAccount.MobileNumber = mobile_number;
            var jsonSetting = new System.Text.Json.JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true
            };
            var _POSTRequest = System.Text.Json.JsonSerializer.Serialize(_UserAccount, jsonSetting);
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | (SecurityProtocolType)12288;
            string postURL = "https://automationexercise.com/api/createAccount";
            HttpWebRequest postReq = (HttpWebRequest)WebRequest.Create(postURL);
            postReq.Method = "POST";
            postReq.ContentType = "application/json";
            postReq.Accept = "*/*";
            postReq.AutomaticDecompression = DecompressionMethods.GZip;
            postReq.Proxy = null;

            string payload = _POSTRequest;
            byte[] payloadBytes = Encoding.UTF8.GetBytes(payload);
            postReq.ContentLength = payloadBytes.Length;

            using (Stream postStream = await postReq.GetRequestStreamAsync().ConfigureAwait(false))
            {
                await postStream.WriteAsync(payloadBytes, 0, payloadBytes.Length).ConfigureAwait(false);
            }
            try
            {
                HttpWebResponse postRespon = (HttpWebResponse)await postReq.GetResponseAsync().ConfigureAwait(false);
                Stream responseStream = postRespon.GetResponseStream();
                using (StreamReader postReader = new StreamReader(responseStream))
                {
                    responseString = await postReader.ReadToEndAsync().ConfigureAwait(false);
                }
            }
            catch (WebException WebEx)
            {
                using (WebResponse ErrorResponse = WebEx.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)ErrorResponse;
                    using (Stream ErrorStream = ErrorResponse.GetResponseStream())
                    {
                        using (StreamReader ErrorReader = new StreamReader(ErrorStream))
                        {
                            responseString  = await ErrorReader.ReadToEndAsync().ConfigureAwait(false);
                        }
                    }
                }
            }
            
            return responseString;
        }
    }
    public class GetProductsTest
    {
        private readonly HttpClient _client = new HttpClient();
        private const string ProductsListUrl = "https://automationexercise.com/api/productsList";
        private ProductList ProductListObj = null;
        public async Task<ProductList> VerifyProductsListAsync()
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, ProductsListUrl))
            {
                //request.Content = new StringContent("", null, "text/plain");
                using (var response = await _client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    string responseString = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    ProductListObj = System.Text.Json.JsonSerializer.Deserialize<ProductList>(responseString, options);
                }
            }
            return ProductListObj;
        }
    }
}
