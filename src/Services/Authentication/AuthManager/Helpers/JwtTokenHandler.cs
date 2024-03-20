using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthManager.Models;
using Microsoft.IdentityModel.Tokens;

namespace AuthManager;

public class JwtTokenHandler
{
    public const string JWT_SECURITY_KEY = "yPkCqn4kSWLtaJwXvN2jGzpQRyTZ3gdXkt7FeBJP";
    private const int JWT_TOKEN_VALIDITY_MINS = 20;
    private readonly List<User> _users;

    public JwtTokenHandler()
    {
        _users = new List<User>
            {
                new User{ UserName = "admin", Password = "admin123", Role = "Administrator" },
                new User{ UserName = "user01", Password = "user01", Role = "User" },
            };
    }

    public AuthResponse? GenerateJwtToken(AuthRequest authRequest)
    {
        if (string.IsNullOrWhiteSpace(authRequest.UserName) || string.IsNullOrWhiteSpace(authRequest.Password))
            return null;

        /* Validation */
        var userAccount = _users.Where(x => x.UserName == authRequest.UserName && x.Password == authRequest.Password).FirstOrDefault();
        if (userAccount == null) return null;

        var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
        var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
        var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, authRequest.UserName),
                new Claim("Role", userAccount.Role)
            });

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(tokenKey),
            SecurityAlgorithms.HmacSha256Signature);

        var securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            Expires = tokenExpiryTimeStamp,
            SigningCredentials = signingCredentials
        };

        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
        var token = jwtSecurityTokenHandler.WriteToken(securityToken);

        return new AuthResponse
        {
            UserName = userAccount.UserName,
            ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
            JwtToken = token
        };
    }
}


    

