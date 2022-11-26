using Newtonsoft.Json;

namespace TicketAPI.Models
{
    public class ErrorDetails: BaseActionDetails
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
