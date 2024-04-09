namespace Demo.Core.Domain.Models;

public abstract class LogicalDeletation
{
    public bool IsDeleted { get; private set; }

    public void SwithDeleteFlag() => IsDeleted = !IsDeleted;
}