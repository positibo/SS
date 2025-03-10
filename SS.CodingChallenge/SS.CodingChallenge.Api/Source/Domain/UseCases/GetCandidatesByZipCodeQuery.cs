using AutoMapper;
using MediatR;
using SS.CodingChallenge.Api.Source.Infrastructure.Data;

namespace SS.CodingChallenge.Api.Source.Domain.UseCases
{
    public class GetCandidatesByZipCodeQuery : IRequest<List<GetCandidatesByZipCodeResponse>>
    {
        public string zipCode { get; set; }

        public GetCandidatesByZipCodeQuery(string zipCode) => this.zipCode = zipCode;

        public class GetCandidatesByZipCodeQueryHandler : IRequestHandler<GetCandidatesByZipCodeQuery, List<GetCandidatesByZipCodeResponse>>
        {
            private readonly SmartSearchApi smartSearchApi;
            private readonly IMapper mapper;

            public GetCandidatesByZipCodeQueryHandler(SmartSearchApi smartSearchApi, IMapper mapper)
            {
                this.smartSearchApi = smartSearchApi;
                this.mapper = mapper;
            }

            public async Task<List<GetCandidatesByZipCodeResponse>> Handle(GetCandidatesByZipCodeQuery request, CancellationToken cancellationToken)
            {
                var candidates = await smartSearchApi.GetCandidatesAsync(request.zipCode);
                return mapper.Map<List<GetCandidatesByZipCodeResponse>>(candidates);
            }
        }
    }
}
