using Newtonsoft.Json;

namespace Module5task1.Dto.Response;

public class ListResponse<T>
    where T : class
{
    public int Page { get; set; }
    [JsonProperty(PropertyName = "per_page")]
    public int PerPage { get; set; }
    public int Total { get; set; }
    [JsonProperty(PropertyName = "total_pages")]
    public int TotalPages { get; set; }
    public BaseResponse<T> BaseResponse { get; set; } = new BaseResponse<T>();
}