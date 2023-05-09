namespace API.Application.Responses
{
    public abstract class BaseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
