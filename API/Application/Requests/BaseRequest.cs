namespace API.Application.Requests
{
    public abstract class BaseRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
