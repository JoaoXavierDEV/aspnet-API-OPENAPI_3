namespace HeavyApps.Blog.Domain.Exceptions
{
    public class DomainExceptionValidationEnitites : ArgumentNullException
    {
        public DomainExceptionValidationEnitites(string error) : base(error)
        { }
        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomainExceptionValidationEnitites(error);
        }
    }
}
