namespace Demo.Users.Api.Handlers.Own.Read;

public class ReadUserListHandler(UsersDbContext context) : IRequestHandler<ReadUserList, ResponseList<UserResponse>?>
{
    public async Task<ResponseList<UserResponse>?> Handle(ReadUserList request, CancellationToken ct)
    {
        if (request.IsValidRequest is false)
            throw new ArgumentException($"{nameof(request.IdList)} XOR {nameof(request.FilterSubstring)}");

        var targetRange = await Task.Run(() => context.Set<User>().AsQueryable(), ct);
        if (request.IdList is not null && request.IdList.Any())
            targetRange = targetRange.Where(u => request.IdList.Contains(u.Id));

        if (string.IsNullOrEmpty(request.FilterSubstring) is false)
            targetRange = targetRange.Where(u => u.FullName.ToLower().Contains(request.FilterSubstring.ToLower()));

        var count = targetRange.Count();
        if (request.Context.Pager is not null)
            targetRange = targetRange.Skip((request.Context.Pager.Number - 1) * request.Context.Pager.Size).Take(request.Context.Pager.Size);

        return new ResponseList<UserResponse>
        {
            ResultList = [.. targetRange.Select(u => new UserResponse { Id = u.Id, Login = u.Login, FullName = u.FullName })],
            Count = count,
            PageNumber = request.Context.Pager?.Number ?? 1,
            PageSize = request.Context.Pager?.Size ?? (short)count
        };
    }
}
