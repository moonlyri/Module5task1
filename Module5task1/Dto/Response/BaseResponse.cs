namespace Module5task1.Dto.Response;

public class BaseResponse<T>
    where T : class
{
    public T Data { get; set; }
    public SupportDto Support { get; set; }
}