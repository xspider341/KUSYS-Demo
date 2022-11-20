

namespace Web.API.HttpClient
{
    public class CourseClient : BaseClient
    {
        public CourseClient(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<CourseResponse?> CourseAdd(CourseRequest request)
        {
            var response = await this.PostJsonAsync(ApiConstants.CourseAdd, request);
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CourseResponse>(apiResponse);
        }
        public async Task<CourseResponse?> CourseUpdate(CourseRequest request)
        {
            var response = await this.PostJsonAsync(ApiConstants.CourseUpdate, request);
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CourseResponse>(apiResponse);
        }
        public async Task<CourseResponse?> CourseDelete(long ID)
        {
            var response = await this.PostJsonAsync(ApiConstants.CourseDelete + ID, ID);
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CourseResponse>(apiResponse);
        }
        public async Task<CourseResponse?> CourseGetById(long ID)
        {
            var response = await this.GetJsonAsync<CourseResponse>(ApiConstants.CourseGetById + ID);
            return response;
        }
        public async Task<List<CourseResponse>?> CourseGetAll()
        {
            var response = await this.GetJsonAsync<List<CourseResponse>>(ApiConstants.CoursesGetAll);
            return response;
        }

    }
}
