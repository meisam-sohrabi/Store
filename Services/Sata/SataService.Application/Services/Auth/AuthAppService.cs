using Newtonsoft.Json;
using SataService.ApplicationContract.DTO.Auth.Captcha;
using SataService.ApplicationContract.DTO.Auth.OTP.Send;
using SataService.ApplicationContract.DTO.Auth.OTP.Verify;
using SataService.ApplicationContract.DTO.Base;
using SataService.ApplicationContract.Interfaces.Auth;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace SataService.Application.Services.Auth
{
    public class AuthAppService : IAuthAppService
    {
        private readonly HttpClient _httpClient;

        public AuthAppService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://esakhad.esata.ir:9081/gateway");
        }

        #region SendOtp
        public async Task<BaseResponseDto<SendOtpResponseDto>> SendOTP(SendOtpRequestDto otpRequestDto)
        {
            var output = new BaseResponseDto<SendOtpResponseDto>
            {
                Message = "خطا در بازیابی رمز یکبار مصرف",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            try
            {
                var request = new HttpRequestMessage(
                    HttpMethod.Post, "/webApi-test/auth/send-otp");
                var content = JsonConvert.SerializeObject(otpRequestDto);
                request.Content = new StringContent(content, Encoding.UTF8, "application/json");
                request.Headers.Add("clientId", "fromconfig"); // باید به فرد توسعه دهنده داده شود
                request.Headers.Add("clinetSecret", "fromconfig");
                request.Headers.Add("workstationid", "fromconfig");
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    output.Message = $"خطای سرور: {response.StatusCode}";
                    output.StatusCode = response.StatusCode;
                    output.Success = false;
                    return output;
                }
                var result = await response.Content.ReadAsStringAsync();
                var deserialize = JsonConvert.DeserializeObject<SendOtpResponseDto>(result);
                if (deserialize == null)
                {
                    output.Message = "اطلاعات یافت نشد";
                    output.StatusCode = HttpStatusCode.BadRequest;
                    output.Success = false;
                    return output;
                }
                switch (deserialize.status)
                {
                    case 0:
                        output.Message = "اطلاعات دریافت شد";
                        output.StatusCode = HttpStatusCode.OK;
                        output.Success = true;
                        output.Data = deserialize;
                        break;

                    case 1:
                        output.Message = "خطا در اطلاعات دریافتی";
                        output.StatusCode = HttpStatusCode.OK;
                        output.Success = false;
                        break;

                    case 2:
                        output.Message = "هشدار در اطلاعات دریافتی";
                        output.StatusCode = HttpStatusCode.OK;
                        output.Success = false;
                        break;

                    default:
                        output.Message = "کد وضعیت ناشناخته";
                        output.StatusCode = HttpStatusCode.InternalServerError;
                        output.Success = false;
                        break;
                }
                return output;

            }
            catch (HttpRequestException ex)
            {
                output.Message = $"خطای سرور: {ex.Message}";
                output.Success = false;
                output.StatusCode = HttpStatusCode.InternalServerError;
                return output;
            }
            catch (Exception ex)
            {
                output.Message = $"خطای سرور: {ex.Message}";
                output.Success = false;
                output.StatusCode = HttpStatusCode.InternalServerError;
                return output;
            }
        }
        #endregion

        #region VerifyOtp
        public async Task<BaseResponseDto<VerifyOtpResponseDto>> VerifyOTP(VerifyOtpRequestDto otpVerifyRequestDto, string requestId)
        {
            var output = new BaseResponseDto<VerifyOtpResponseDto>
            {
                Message = "خطا در تایید رمز یکبار مصرف",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };

            try
            {
                var request = new HttpRequestMessage(
                    HttpMethod.Post, "/webApi-test/auth/verify-otp");
                var content = JsonConvert.SerializeObject(otpVerifyRequestDto);
                request.Content = new StringContent(content, Encoding.UTF8, "application/json");
                request.Headers.Add("requestId", requestId);
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    output.Message = $"خطای سرور: {response.StatusCode}";
                    output.StatusCode = response.StatusCode;
                    output.Success = false;
                    return output;
                }
                var result = await response.Content.ReadAsStringAsync();
                var deserialize = JsonConvert.DeserializeObject<VerifyOtpResponseDto>(result);
                if (deserialize == null)
                {
                    output.Message = "اطلاعات یافت نشد";
                    output.StatusCode = HttpStatusCode.BadRequest;
                    output.Success = false;
                    return output;
                }
                switch (deserialize.status)
                {
                    case 0:
                        output.Message = "اطلاعات دریافت شد";
                        output.StatusCode = HttpStatusCode.OK;
                        output.Success = true;
                        output.Data = deserialize;
                        break;

                    case 1:
                        output.Message = "خطا در اطلاعات دریافتی";
                        output.StatusCode = HttpStatusCode.OK;
                        output.Success = false;
                        break;

                    case 2:
                        output.Message = "هشدار در اطلاعات دریافتی";
                        output.StatusCode = HttpStatusCode.OK;
                        output.Success = false;
                        break;

                    default:
                        output.Message = "کد وضعیت ناشناخته";
                        output.StatusCode = HttpStatusCode.InternalServerError;
                        output.Success = false;
                        break;
                }
                return output;

            }
            catch (HttpRequestException ex)
            {
                output.Message = $"خطای سرور: {ex.Message}";
                output.Success = false;
                output.StatusCode = HttpStatusCode.InternalServerError;
                return output;
            }
            catch (Exception ex)
            {
                output.Message = $"خطای سرور: {ex.Message}";
                output.Success = false;
                output.StatusCode = HttpStatusCode.InternalServerError;
                return output;
            }
        }
        #endregion

        #region VerifyCaptcah
        public async Task<BaseResponseDto<VerifyCaptchaResponseDto>> VerifyCaptcha(VerifyCaptchaRequestDto verifyCaptchaRequestDto, string token)
        {
            var output = new BaseResponseDto<VerifyCaptchaResponseDto>
            {
                Message = "خطا در بازیابی رمز یکبار مصرف",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            try
            {
                var request = new HttpRequestMessage(
                         HttpMethod.Post, "/verifyCaptcha");
                var content = JsonConvert.SerializeObject(verifyCaptchaRequestDto);
                request.Content = new StringContent(content, Encoding.UTF8, "application/json");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearerm", token);
                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    output.Message = $"خطای سرور: {response.StatusCode}";
                    output.StatusCode = response.StatusCode;
                    output.Success = false;
                    return output;
                }
                var result = await response.Content.ReadAsStringAsync();
                var deserialize = JsonConvert.DeserializeObject<VerifyCaptchaResponseDto>(result);
                if (deserialize == null)
                {
                    output.Message = "اطلاعات یافت نشد";
                    output.StatusCode = HttpStatusCode.BadRequest;
                    output.Success = false;
                    return output;
                }
                switch (deserialize.status)
                {
                    case 0:
                        output.Message = "اطلاعات دریافت شد";
                        output.StatusCode = HttpStatusCode.OK;
                        output.Success = true;
                        output.Data = deserialize;
                        break;

                    case 1:
                        output.Message = "خطا در اطلاعات دریافتی";
                        output.StatusCode = HttpStatusCode.OK;
                        output.Success = false;
                        break;

                    case 2:
                        output.Message = "هشدار در اطلاعات دریافتی";
                        output.StatusCode = HttpStatusCode.OK;
                        output.Success = false;
                        break;

                    default:
                        output.Message = "کد وضعیت ناشناخته";
                        output.StatusCode = HttpStatusCode.InternalServerError;
                        output.Success = false;
                        break;
                }
                return output;

            }
            catch (HttpRequestException ex)
            {
                output.Message = $"خطای سرور: {ex.Message}";
                output.Success = false;
                output.StatusCode = HttpStatusCode.InternalServerError;
                return output;
            }
            catch (Exception ex)
            {
                output.Message = $"خطای سرور: {ex.Message}";
                output.Success = false;
                output.StatusCode = HttpStatusCode.InternalServerError;
                return output;
            }
        }
        #endregion



    }
}
