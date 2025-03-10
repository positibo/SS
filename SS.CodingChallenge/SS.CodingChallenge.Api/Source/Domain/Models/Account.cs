namespace SS.CodingChallenge.Api.Source.Domain.Models
{
    public class Account
    {
        public string AccessToken { get; set; }
        public DateTime ExpiresIn { get; set; }
        public string TokenType { get; set; }
    }
}
