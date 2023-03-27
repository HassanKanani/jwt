using BaseApi.Model;

namespace BaseApi
{
    public interface IJWTService
    {
        string Generrate(User user);
    }
}