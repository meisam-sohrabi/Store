using AutoMapper;
using Second.ApplicationContract.Interfaces;
using Second.InfrastructureContract.Interfaces;
using Second.InfrastructureContract.Interfaces.Command.Account;
using Second.InfrastructureContract.Interfaces.Command.Security;
using Second.InfrastructureContract.Interfaces.Query.Account;
using Second.InfrastructureContract.Interfaces.Query.Security;
namespace Second.Application.Services.Account
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
