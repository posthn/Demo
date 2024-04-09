namespace Demo.Core.Api.RequestsPool.Users.Read;

public class ReadUserList : RequestBase<ResponseList<UserResponse>?>
{
    public IList<long>? IdList { get; set; }

    public string? FilterSubstring { get; set; }

    public bool IsValidRequest => (IdList is not null && IdList.Any()) ^ (string.IsNullOrEmpty(FilterSubstring) is false);
}