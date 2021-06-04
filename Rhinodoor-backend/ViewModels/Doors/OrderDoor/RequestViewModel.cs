namespace Rhinodoor_backend.ViewModels.Doors.OrderDoor
{
    public class RequestViewModel
    {
        #region Client
        
        public string ClientName { get; set; }

        public string ClientAddress { get; set; }

        public string ClientCity { get; set; }

        public string ClientPostalCode { get; set; }

        public string ClientPhoneNumber { get; set; }

        public string ClientEmail { get; set; }
        
        #endregion

        #region Door

        public int DoorId { get; set; }

        public int DoorOptionId { get; set; }

        public int DoorColorId { get; set; }

        #endregion
    }
}