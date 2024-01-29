namespace PublicTransportation.App.Utils
{
    public class StatusResult
    {
        public int Status { get; set; }
        public string Message { get; set; }

        public bool Success()
        {
            return Status == 200;
        }
    }
}
