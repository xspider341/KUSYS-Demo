

namespace Web.API.HttpClient
{
    public class StudentClient : BaseClient
    {
        public StudentClient(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<StudentResponse?> StudentAdd(StudentRequest request)
        {
            var response = await this.PostJsonAsync(ApiConstants.StudentAdd, request);
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<StudentResponse>(apiResponse);
        }
        public async Task<StudentResponse?> StudentUpdate(StudentRequest request)
        {
            var response = await this.PostJsonAsync(ApiConstants.StudentUpdate, request);
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<StudentResponse>(apiResponse);
        }
        public async Task<StudentResponse?> StudentDelete(long ID)
        {
            var response = await this.PostJsonAsync(ApiConstants.StudentDelete + ID, ID);
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<StudentResponse>(apiResponse);
        }
        public async Task<StudentResponse?> StudentGetById(long ID)
        {
            var response = await this.GetJsonAsync<StudentResponse>(ApiConstants.StudentGetById + ID);
            return response;
        }
        public async Task<List<StudentResponse>?> StudentsGetAll()
        {
            var response = await this.GetJsonAsync<List<StudentResponse>>(ApiConstants.StudentsGetAll);
            return response;
        }
    }
}
