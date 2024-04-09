namespace Demo.Core.Domain.Exceptions;

public class InvalidAuthDataException(IList<string> problemList) : Exception(string.Join(';', problemList))
{
    public IList<string> ProblemList => problemList;
}