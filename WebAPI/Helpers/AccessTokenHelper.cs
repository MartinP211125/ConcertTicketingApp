using System.IdentityModel.Tokens.Jwt;

namespace WebAPI.Helpers
{
    public static class AccessTokenHelper
    {
        public static string GetAccessToken(string? authorizationJWTHeader)
        {
            if (string.IsNullOrEmpty(authorizationJWTHeader) || !authorizationJWTHeader.StartsWith("Bearer "))
            {
                throw new BadHttpRequestException("Missing bearer authorization header.");
            }
            var token = authorizationJWTHeader.Substring("Bearer ".Length);
            return token;
        }
        public static Guid GetUserId(string token)
        {
           var handler = new JwtSecurityTokenHandler();
           var securityToken = handler.ReadToken(token) as JwtSecurityToken;
           var success = securityToken.Payload.TryGetValue("userId", out var userId);
           if (!success)
            {
                throw new BadHttpRequestException("Missing userId claim from Payload");
            }
            var successfullParse = Guid.TryParse(userId.ToString(), out var userGuid);
            if (!successfullParse)
            {
                throw new BadHttpRequestException("UserId claim not as expected.");
            }
            return userGuid;
        }
    }
}
