using AutoMapper;
using BusinessLayer.Interfaces;
using ExternalServices.Interfaces;
using Models.Jdoodle;

namespace BusinessLayer.Implementation
{
    public class JdoodleService : IJdoodleService
    {
        public readonly IJdoodleClient _jdoodleClient;
        public readonly IMapper _mapper;
        public JdoodleService(IJdoodleClient jdoodleClient,IMapper mapper)
        {
            _jdoodleClient = jdoodleClient;
            _mapper = mapper;
        }

        public async Task<JdoodleResponse?> Execute(JdoodleRequest request)
        {
            var requestMapped = _mapper.Map<JdoodleRequestSend>(request);
            var response = await _jdoodleClient.Execute(requestMapped);

            return response;
        }
    }
}
