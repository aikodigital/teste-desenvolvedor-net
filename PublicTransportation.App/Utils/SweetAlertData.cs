namespace PublicTransportation.App.Utils
{
    public class SweetAlertData
    {


        public string Message { get; set; }
        public string Icon { get; set; } = "success";
        public string Title { get; set; }
        public string Btn_confirm_text { get; set; } = "Confirm";
        public string Btn_cancel_text { get; set; } = "Cancel";

        public SweetAlertData() { }

        public SweetAlertData(System.Net.HttpStatusCode statusCode, string message)
        {
            switch ((int) statusCode)
            {
                case 400:
                    Icon = "error";
                    Message = message;
                    Title = "Ops!";
                    break;
                case 409:
                    Icon = "warning";
                    Message = message;
                    Title = "Ops!";
                    break;
                case 420:
                    Icon = "warning";
                    Message = message;
                    Title = "Ops!";
                    break;
                default:
                    Icon = "success";
                    Message = message;
                    Title = "Success!";
                    break;
            }
        }
    }
}
