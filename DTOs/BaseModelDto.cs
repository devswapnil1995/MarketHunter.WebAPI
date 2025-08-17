namespace MarketHunter.WebAPI.DTOs
{
    public class BaseModelDto
    {
        public DateTime DateCreated {  get; set; }
        public DateTime? DateModified { get; set; } = null;
    }
}
