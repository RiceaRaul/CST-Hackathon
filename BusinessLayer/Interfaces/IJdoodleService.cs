using Models.Jdoodle;

namespace BusinessLayer.Interfaces
{
    public interface IJdoodleService
    {
        Task<JdoodleResponse?> Execute(JdoodleRequest request);
    }
}
