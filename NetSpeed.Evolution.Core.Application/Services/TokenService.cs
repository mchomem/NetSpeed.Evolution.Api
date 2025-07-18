namespace NetSpeed.Evolution.Core.Application.Services;

public class TokenService : ITokenService
{
    private readonly byte[] key = Encoding.ASCII.GetBytes("+WsLhdwMcCnW&cJW4a5hm^jFemE&?V?Y?z9eMdcN_X3DktLE7W9nS#Z2&vpakM6v");

    public async Task<TokenDto> GetTokenAsync(UserDto user)
    {
        DateTime expires = DateTime.UtcNow;

        expires = DateTime.UtcNow.AddHours(1);

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(nameof(user.Id).ToLower(), user.Id.ToString()),
                new Claim(nameof(user.Login).ToLower(), user.Login),
                new Claim("startedIn", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff"))
            }),
            Expires = expires,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        string generatedToken = string.Empty;
        await Task.Run(() => generatedToken = tokenHandler.WriteToken(token));
        var jwtToken = tokenHandler.ReadJwtToken(generatedToken);

        return new TokenDto()
        {
            Value = generatedToken,
            ExpiresIn = jwtToken.ValidTo
        };
    }
}
