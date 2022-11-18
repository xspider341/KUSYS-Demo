using Web.API.HttpClient.Base;

namespace Web.API.HttpClient
{
    public class StudentClient : BaseClient
    {
        public StudentClient(IConfiguration configuration, string Token = "") : base(configuration, Token)
        {
        }
    }
}
