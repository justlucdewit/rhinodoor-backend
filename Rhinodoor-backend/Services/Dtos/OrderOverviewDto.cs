namespace Rhinodoor_backend.Services.Dtos
{
    public class OrderOverviewDto
    {
        public int Id { get; set; }

        public string PlacedOn { get; set; }

        public string PlacedBy { get; set; }

        public string Status { get; set; }
    }
}