using Newtonsoft.Json;
using SataService.ApplicationContract.DTO.Base;
using SataService.ApplicationContract.DTO.Captcha;
using SataService.ApplicationContract.Interfaces;
using System.Net;
using System.Text;
using System.Net.Http.Headers;
namespace SataService.Application.Services.Captcha
{
    public class CaptchaAppService : ICaptchaAppService
    {
        public HttpClient _httpClient { get; }

        public CaptchaAppService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://esakhad.esata.ir:9081/gateway");
        }

        #region VerifyCaptcha
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
