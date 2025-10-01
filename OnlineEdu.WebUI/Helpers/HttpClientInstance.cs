using static System.Net.WebRequestMethods;

namespace OnlineEdu.WebUI.Helpers
{
    public static class HttpClientInstance
    {
        public static HttpClient Instance()
        {
            HttpClient instance = new HttpClient();
            instance.BaseAddress = new Uri("https://localhost:7111");
            return instance;
        }
    }
}
