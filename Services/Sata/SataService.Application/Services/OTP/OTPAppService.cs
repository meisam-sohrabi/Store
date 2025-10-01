using Newtonsoft.Json;
using SataService.ApplicationContract.DTO.Base;
using SataService.ApplicationContract.DTO.OTP;
using SataService.ApplicationContract.Interfaces;
using System.Net;

namespace SataService.Application.Services.OTP
{
    public class OTPAppService : IOTPAppService
    {
        private readonly HttpClient _httpClient;

        public OTPAppService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<BaseResponseDto<OTPResponseDto>> GetOTP(OTPRequestDto otpRequestDto)
        {
            var output = new BaseResponseDto<OTPResponseDto>
            {
                Message = "خطا در بازیابی رمز یکبار مصرف",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            try
            {
                var request = new HttpRequestMessage(
                    HttpMethod.Post, "https://esakhad.esata.ir:9081/gateway/webApi-test/auth/send-otp");
                var content = JsonConvert.SerializeObject(otpRequestDto);
                request.Headers.Add("clientId", "");
                request.Headers.Add("clientSecret", "");
                request.Headers.Add("workstationId", "");
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    output.Message = $"خطای سرور: {response.StatusCode}";
                    output.StatusCode = response.StatusCode;
                    output.Success = false;
                    return output;
                }
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var deserialize = JsonConvert.DeserializeObject<OTPResponseDto>(result);
                if (deserialize == null)
                {
                    output.Message = "اطلاعات یافت نشد";
                    output.StatusCode = HttpStatusCode.BadRequest;
                    output.Success = false;
                    return output;
                }
                if (deserialize.status == 0)
                {
                    output.Message = "اطلاعات دریافت شد";
                    output.StatusCode = HttpStatusCode.OK;
                    output.Success = true;
                    output.Data = deserialize;
                    return output;
                }
                if (deserialize.status == 1)
                {
                    output.Message = "خطا در اطلاعات دریافتی";
                    output.StatusCode = HttpStatusCode.BadRequest;
                    output.Success = false;
                    return output;
                }
                if (deserialize.status == 2)
                {
                    output.Message = "هشدار در اطلاعات دریافتی";
                    output.StatusCode = HttpStatusCode.BadRequest;
                    output.Success = false;
                    return output;
                }
                return output;

            }
            catch (HttpRequestException ex)
            {
                output.Message = $"خطای سرور: {ex.Message}";
                output.Success = false;
                return output;
            }

        }
    }
}
