namespace TicketAPI.Models
{
    public class ValidationResult<T> where T : class
    {
        public ErrorDetails ErrorDetails { get; set; }
        public T Result { get; set; }
        public bool IsSuccess { get; set; }
    }
}