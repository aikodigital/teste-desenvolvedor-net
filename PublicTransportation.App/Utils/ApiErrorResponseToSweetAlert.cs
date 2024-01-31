using System.Net.Http.Json;

namespace PublicTransportation.App.Utils
{
    public class ApiErrorResponseToSweetAlert
    {
        private HttpResponseMessage _response;

        public ApiErrorResponseToSweetAlert(HttpResponseMessage response)
        { _response = response; }

        public async Task<SweetAlertData> Alert()
        {
            string message = "";

            if ((int)_response.StatusCode >= 400)
            {
                var apiErrorResponse = await _response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                message = apiErrorResponse.Error;
            }
            return new SweetAlertData(_response.StatusCode, message);
        }

        public bool Success()
        => (int) _response.StatusCode >= 200 && (int) _response.StatusCode <= 299;

    }
}
