using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QA.Models
{
    public class UserAccount
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("birth_date")]
        public string BirthDate { get; set; }

        [JsonPropertyName("birth_month")]
        public string BirthMonth { get; set; }

        [JsonPropertyName("birth_year")]
        public string BirthYear { get; set; }

        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }

        [JsonPropertyName("lastname")]
        public string Lastname { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("address1")]
        public string Address1 { get; set; }

        [JsonPropertyName("address2")]
        public string Address2 { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("zipcode")]
        public string Zipcode { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("mobile_number")]
        public string MobileNumber { get; set; }
    }
    public class ProductList
    {
        public double responseCode { get; set; }
        public List<products> products { get; set; }
    }
    public class products
    {
        public double id {  get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public string brand { get; set; }
        public category category { get; set; }
    }
    public class category
    {
        public usertype usertype { get; set; }
        [JsonPropertyName("category")]
        public string category_category {  get; set; }
    }
    public class usertype
    {
        [JsonPropertyName("usertype")]
        public string category_usertype_usertype { get; set; }
    }
}
