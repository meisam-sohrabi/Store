using AutoMapper;
using ShopService.ApplicationContract.Interfaces;
using ShopService.InfrastructureContract.Interfaces;
using ShopService.InfrastructureContract.Interfaces.Command.Account;
using ShopService.InfrastructureContract.Interfaces.Command.Security;
using ShopService.InfrastructureContract.Interfaces.Query.Account;
using ShopService.InfrastructureContract.Interfaces.Query.Security;
namespace ShopService.Application.Services.Account
{
    public class AccountAppService
    {
        private readonly IAccountCommandRepository _authenticationCommandRepository;
        private readonly IAccountQueryRepository _authenticatoinQueryRepository;
        private readonly IMapper _mapper;
        private readonly IRefreshTokenQueryRepository _refreshTokenQueryRepository;
        private readonly IRefreshTokenCommandRepository _refreshTokenCommandRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICookieService _cookieService;

        public AccountAppService(IAccountCommandRepository authenticationCommandRepository, IAccountQueryRepository authenticatoinQueryRepository,
            IMapper mapper , IRefreshTokenQueryRepository refreshTokenQueryRepository, IRefreshTokenCommandRepository refreshTokenCommandRepository
            , IUnitOfWork unitOfWork, ICookieService cookieService)
        {
            _authenticationCommandRepository = authenticationCommandRepository;
            _authenticatoinQueryRepository = authenticatoinQueryRepository;
            _mapper = mapper;
            _refreshTokenQueryRepository = refreshTokenQueryRepository;
            _refreshTokenCommandRepository = refreshTokenCommandRepository;
            _unitOfWork = unitOfWork;
            _cookieService = cookieService;
        }


    }
}
