using System.Net;

namespace booksAPI.Services
{
    public class TextService
    {
        //private readonly HttpClient httpClient;

        //public TextService(HttpClient httpClient)
        //{
        //    this.httpClient = httpClient;
        //}

        public static string GetTextFromTxt(string txtUrl)
        {
            ArgumentNullException.ThrowIfNull(txtUrl);

            var webRequest = (HttpWebRequest)HttpWebRequest.Create("https://whitworthpirates.com/services/schedule_txt.ashx?schedule=139");
            webRequest.UserAgent = "Hej";

            var response = webRequest.GetResponse();
            var content = response.GetResponseStream();

            using var reader = new StreamReader(content);
            string strContent = reader.ReadToEnd();
            return strContent;
        }
    }
}
