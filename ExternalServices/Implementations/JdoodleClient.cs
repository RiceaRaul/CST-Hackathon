using Common.Settings;
using ExternalServices.Interfaces;
using Microsoft.Extensions.Options;
using Models.ErrorHandling;
using Models.Jdoodle;
using Newtonsoft.Json;
using System.Text;

namespace ExternalServices.Implementations
{
    public class JdoodleClient : IJdoodleClient
    {
        private readonly HttpClient _httpClient;

        private readonly AppSettings _appSettings;
        private const string BASE_URL = "https://stage.jdoodle.com/";
        private const string EXECUTE = "execute";

        public JdoodleClient(IOptions<AppSettings> appSettings)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BASE_URL);
            _appSettings = appSettings.Value;
        }
        
        public async Task<JdoodleResponse?> Execute(JdoodleRequestSend request)
        {
            request.clientId = _appSettings.Jdoodle.clientId;
            request.clientSecret = _appSettings.Jdoodle.clientSecret;
            try
            {
                var data = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                using (var httpRequest = await _httpClient.PostAsync(EXECUTE, data))
                {
      
                    var result = await httpRequest.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<JdoodleResponse>(result);
                    return response;
                }
            }
            catch (Exception ex) {
                throw new ApiErrorException(ex.Message);
            }
        }
    }
}
