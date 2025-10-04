using Newtonsoft.Json;
using SataService.ApplicationContract.DTO.Base;
using SataService.ApplicationContract.DTO.Prescription.DoctorsList;
using SataService.ApplicationContract.DTO.Prescription.Insurance;
using SataService.ApplicationContract.Interfaces.Prescription;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace SataService.Application.Services.Prescription
{
    public class PrescriptionAppService : IPrescriptionAppService
    {
        private readonly HttpClient _httpClient;
        public PrescriptionAppService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://esakhad.esata.ir:9081/gateway/webApi-test");
        }

        #region DoctorsList
        public async Task<BaseResponseDto<DoctorsListResponseDto>> CenterDoctorList(string token, string sessionId, string requestId)
        {
            var output = new BaseResponseDto<DoctorsListResponseDto>
            {
                Message = "خطا در بازیابی لیست پزشکان",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            try
            {
                var request = new HttpRequestMessage(
                   HttpMethod.Post, "/v1/centerDoctorList");
                request.Content = new StringContent("", Encoding.UTF8, "application/json");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                request.Headers.Add("sessionId", sessionId);
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
                var deserialize = JsonConvert.DeserializeObject<DoctorsListResponseDto>(result);
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


        #region Eligible
        public async Task<BaseResponseDto<EligibleResponseDto>> Eligible(EligibleRequestDto eligibleRequestDto, string token, string sessionId, string requestId)
        {
            var output = new BaseResponseDto<EligibleResponseDto>
            {
                Message = "خطا در بازیابی رمز یکبار مصرف",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            try
            {
                var request = new HttpRequestMessage(
                   HttpMethod.Post, "/v1/eligible");
                var content = JsonConvert.SerializeObject(eligibleRequestDto);
                request.Content = new StringContent(content, Encoding.UTF8, "application/json");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                request.Headers.Add("sessionId", sessionId);
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
                var deserialize = JsonConvert.DeserializeObject<EligibleResponseDto>(result);
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
