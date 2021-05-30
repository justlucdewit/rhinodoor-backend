namespace Rhinodoor_backend.Models
{
    public class DoorColor
    {
        public int Id { get; set; }

        public int DoorId { get; set; }

        public int ColorRAL { get; set; }

        public int ColorHEX { get; set; }

        public virtual Door Door { get; set; }
    }
}