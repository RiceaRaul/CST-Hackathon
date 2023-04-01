using Models.Jdoodle;

namespace ExternalServices.Interfaces
{
    public interface IJdoodleClient
    {
        Task<JdoodleResponse?> Execute(JdoodleRequestSend request);
    }
}
