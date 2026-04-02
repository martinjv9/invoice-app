namespace Invoice.Api.Configuration;

public class JwtSettings
{
    public string Secret { get; set; }
    public int AccessTokenExpirationMinutes { get; set; } = 15;
    public int RefreshTokenExpirationDays { get; set; } = 7;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;

}