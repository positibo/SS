namespace SS.CodingChallenge.Api.Source.Domain.UseCases
{
    public class GetCandidatesByZipCodeResponse
    {
        public int UserNum { get; set; }
        public int CandidateNum { get; set; }
        public int ResumeNum { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
    }
}
