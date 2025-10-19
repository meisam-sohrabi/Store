using Newtonsoft.Json;
using RedisService;
using SataService.ApplicationContract.DTO.Base;
using SataService.ApplicationContract.DTO.Prescription.ClientListTajviz.Response;
using SataService.ApplicationContract.DTO.Prescription.ConfrimPrescription.Request;
using SataService.ApplicationContract.DTO.Prescription.ConfrimPrescription.Response;
using SataService.ApplicationContract.DTO.Prescription.DoctorsList.Response;
using SataService.ApplicationContract.DTO.Prescription.GetAppointment.Request;
using SataService.ApplicationContract.DTO.Prescription.GetAppointment.Response;
using SataService.ApplicationContract.DTO.Prescription.InquiryPrescription.Request;
using SataService.ApplicationContract.DTO.Prescription.InquiryPrescription.Response;
using SataService.ApplicationContract.DTO.Prescription.Insurance.Request;
using SataService.ApplicationContract.DTO.Prescription.Insurance.Response;
using SataService.ApplicationContract.DTO.Prescription.PrescribeItemsList.Request;
using SataService.ApplicationContract.DTO.Prescription.PrescribeItemsList.Response;
using SataService.ApplicationContract.DTO.Prescription.PrintPresentation.Request;
using SataService.ApplicationContract.DTO.Prescription.PrintPresentation.Response;
using SataService.ApplicationContract.DTO.Prescription.RegisterInitialPrescription.Request;
using SataService.ApplicationContract.DTO.Prescription.RegisterInitialPrescription.Response;
using SataService.ApplicationContract.DTO.Prescription.RegisterPrescription.Request;
using SataService.ApplicationContract.DTO.Prescription.RegisterPrescription.Response;
using SataService.ApplicationContract.Interfaces.Prescription;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace SataService.Application.Services.Prescription
{
    public class PrescriptionAppService : IPrescriptionAppService
    {
        private readonly HttpClient _httpClient;
        private readonly ICacheAdapter _cache;

        public PrescriptionAppService(HttpClient httpClient,ICacheAdapter cache)
        {
            _httpClient = httpClient;
            _cache = cache;
            _httpClient.BaseAddress = new Uri("https://esakhad.esata.ir:9081/gateway/webApi-test/v1");
        }

        #region DoctorsList
        public async Task<BaseResponseDto<DoctorsListResponseDto>> CenterDoctorList()
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
                   HttpMethod.Post, "/centerDoctorList");
                var accessToken = _cache.Get<string>("accessToken");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var sessionId = _cache.Get<string>("sessionId");
                request.Headers.Add("sessionId", sessionId);
                var requestId = _cache.Get<string>("requestId");
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
        public async Task<BaseResponseDto<EligibleResponseDto>> Eligible(EligibleRequestDto eligibleRequestDto)
        {
            var output = new BaseResponseDto<EligibleResponseDto>
            {
                Message = "خطا در استعلام بیمه ",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            try
            {
                var request = new HttpRequestMessage(
                   HttpMethod.Post, "/eligible");
                var content = JsonConvert.SerializeObject(eligibleRequestDto);
                request.Content = new StringContent(content, Encoding.UTF8, "application/json");
                var accessToken = _cache.Get<string>("accessToken");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var sessionId = _cache.Get<string>("sessionId");
                request.Headers.Add("sessionId", sessionId);
                var requestId = _cache.Get<string>("requestId");
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

        #region GetAppointment

        public async Task<BaseResponseDto<GetAppointmentResponseDto>> GetAppointment(GetAppointmentRequestDto getAppointmentRequestDto)
        {
            var output = new BaseResponseDto<GetAppointmentResponseDto>
            {
                Message = "خطا در دریافت نوبت دهی ",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            try
            {
                var request = new HttpRequestMessage(
                   HttpMethod.Post, "/getAppointment");
                var content = JsonConvert.SerializeObject(getAppointmentRequestDto);
                request.Content = new StringContent(content, Encoding.UTF8, "application/json");
                var accessToken = _cache.Get<string>("accessToken");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var sessionId = _cache.Get<string>("sessionId");
                request.Headers.Add("sessionId", sessionId);
                var requestId = _cache.Get<string>("requestId");
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
                var deserialize = JsonConvert.DeserializeObject<GetAppointmentResponseDto>(result);
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

        #region ClientListTajviz

        public async Task<BaseResponseDto<ClientListTajvizResponseDto>> ClientListTajviz()
        {
            var output = new BaseResponseDto<ClientListTajvizResponseDto>
            {
                Message = "خطا در دریافت لیست مراجعین ",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            try
            {
                var request = new HttpRequestMessage(
                   HttpMethod.Post, "/getClientListTajviz");
                var accessToken = _cache.Get<string>("accessToken");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var sessionId = _cache.Get<string>("sessionId");
                request.Headers.Add("sessionId", sessionId);
                var requestId = _cache.Get<string>("requestId");
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
                var deserialize = JsonConvert.DeserializeObject<ClientListTajvizResponseDto>(result);
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

        #region RegisterPrescription
        public async Task<BaseResponseDto<RegisterPrescriptionResponseDto>> RegisterPrescription(RegisterPrescriptionRequestDto registerPrescriptionRequestDto)
        {
            var output = new BaseResponseDto<RegisterPrescriptionResponseDto>
            {
                Message = "خطا در ثبت نسخه ",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            try
            {
                var request = new HttpRequestMessage(
                   HttpMethod.Post, "/registerPrescription");
                var accessToken = _cache.Get<string>("accessToken");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var sessionId = _cache.Get<string>("sessionId");
                request.Headers.Add("sessionId", sessionId);
                var requestId = _cache.Get<string>("requestId");
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
                var deserialize = JsonConvert.DeserializeObject<RegisterPrescriptionResponseDto>(result);
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

        #region PrescribeItemsList
        public async Task<BaseResponseDto<PrescribeItemsListResponseDto>> PrescribedItemsList(PrescribeItemsListRequestDto prescribeItemsListRequestDto)
        {
            var output = new BaseResponseDto<PrescribeItemsListResponseDto>
            {
                Message = "خطا در دریافت اقلام تجویز شده ",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            try
            {
                var request = new HttpRequestMessage(
                   HttpMethod.Post, "/getPrescribeItemsList");
                var content = JsonConvert.SerializeObject(prescribeItemsListRequestDto);
                request.Content = new StringContent(content, Encoding.UTF8, "application/json");
                var accessToken = _cache.Get<string>("accessToken");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var sessionId = _cache.Get<string>("sessionId");
                request.Headers.Add("sessionId", sessionId);
                var requestId = _cache.Get<string>("requestId");
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
                var deserialize = JsonConvert.DeserializeObject<PrescribeItemsListResponseDto>(result);
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

        #region RegisterInitialPrescription

        public async Task<BaseResponseDto<RegisterInitialPrescriptionResponseDto>> RegisterInitialPrescription(RegisterInitialPrescriptionRequestDto registerInitialPrescriptionRequestDto)
        {
            var output = new BaseResponseDto<RegisterInitialPrescriptionResponseDto>
            {
                Message = "خطا در ثبت اولیه نسخه ",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            try
            {
                var request = new HttpRequestMessage(
                   HttpMethod.Post, "/registerInitialPrescription");
                var content = JsonConvert.SerializeObject(registerInitialPrescriptionRequestDto);
                request.Content = new StringContent(content, Encoding.UTF8, "application/json");
                var accessToken = _cache.Get<string>("accessToken");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var sessionId = _cache.Get<string>("sessionId");
                request.Headers.Add("sessionId", sessionId);
                var requestId = _cache.Get<string>("requestId");
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
                var deserialize = JsonConvert.DeserializeObject<RegisterInitialPrescriptionResponseDto>(result);
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

        #region ConfirmPrescription

        public async Task<BaseResponseDto<ConfirmPrescriptionPresentationResponseDto>> ConfirmPrescriptionPresentation(ConfirmPrescriptionPresentationRequestDto confirmPrescriptionPresentationRequestDto)
        {
            var output = new BaseResponseDto<ConfirmPrescriptionPresentationResponseDto>
            {
                Message = "خطا در تایید نهایی نسخه ",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            try
            {
                var request = new HttpRequestMessage(
                   HttpMethod.Post, "/confirmPrescriptionPresentation");
                var content = JsonConvert.SerializeObject(confirmPrescriptionPresentationRequestDto);
                request.Content = new StringContent(content, Encoding.UTF8, "application/json");
                var accessToken = _cache.Get<string>("accessToken");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var sessionId = _cache.Get<string>("sessionId");
                request.Headers.Add("sessionId", sessionId);
                var requestId = _cache.Get<string>("requestId");
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
                var deserialize = JsonConvert.DeserializeObject<ConfirmPrescriptionPresentationResponseDto>(result);
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

        #region InquiryPrescription

        public async Task<BaseResponseDto<InquiryPrescriptionResponseDto>> InquiryPrescription(InquiryPrescriptionRequestDto inquiryPrescriptionRequestDto)
        {
            var output = new BaseResponseDto<InquiryPrescriptionResponseDto>
            {
                Message = "خطا دراستعلام تجویز نسخه ",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            try
            {
                var request = new HttpRequestMessage(
                   HttpMethod.Post, "/inquiryPrescription");
                var content = JsonConvert.SerializeObject(inquiryPrescriptionRequestDto);
                request.Content = new StringContent(content, Encoding.UTF8, "application/json");
                var accessToken = _cache.Get<string>("accessToken");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var sessionId = _cache.Get<string>("sessionId");
                request.Headers.Add("sessionId", sessionId);
                var requestId = _cache.Get<string>("requestId");
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
                var deserialize = JsonConvert.DeserializeObject<InquiryPrescriptionResponseDto>(result);
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

        #region PrintPresentation
        public async Task<BaseResponseDto<PrintPresentationResponseDto>> PrintPresentation(PrintPresentationRequestDto printPresentationRequestDto)
        {
            var output = new BaseResponseDto<PrintPresentationResponseDto>
            {
                Message = "خطا در چاپ نسخه پیچی ",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            try
            {
                var request = new HttpRequestMessage(
                   HttpMethod.Post, "/printPresentation");
                var content = JsonConvert.SerializeObject(printPresentationRequestDto);
                request.Content = new StringContent(content, Encoding.UTF8, "application/json");
                var accessToken = _cache.Get<string>("accessToken");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var sessionId = _cache.Get<string>("sessionId");
                request.Headers.Add("sessionId", sessionId);
                var requestId = _cache.Get<string>("requestId");
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
                var deserialize = JsonConvert.DeserializeObject<PrintPresentationResponseDto>(result);
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
