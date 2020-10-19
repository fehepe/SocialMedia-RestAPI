using SocialMedia.Core.CustomEntities;

namespace SocialMedia.Api.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }
        
        public Metadata Metadata { get; set; }
        public T Data { get; set; }

    }
}
