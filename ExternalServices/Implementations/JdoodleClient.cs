using Models.Jdoodle;

namespace ExternalServices.Implementations
{
    public class JdoodleClient
    {
        private readonly HttpClient _httpClient;

        private const string BASE_URL = "https://stage.jdoodle.com/";
        private const string EXECUTE = "execute";

        public JdoodleClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BASE_URL);
        }
        
    /*    public async Task<JdoodleResponse> Execute()
        {
            try
            {

                using (var response = _httpClient.PostAsync(EXECUTE,)
            }
            catch (Exception ex) {

            }
        }*/
    }
}
