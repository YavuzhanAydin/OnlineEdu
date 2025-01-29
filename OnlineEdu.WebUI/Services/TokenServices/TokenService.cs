using System.Security.Claims;

namespace OnlineEdu.WebUI.Services.TokenServices
{
    public class TokenService :ITokenService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public TokenService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        //public string GetUserToken { get
        //    {
        //        var claims = _contextAccessor.HttpContext.User.Claims.ToList();
        //        foreach (var claim in claims)
        //        {
        //            Console.WriteLine($"Claim Type: {claim.Type}, Claim Value: {claim.Value}");
        //        }
        //        // HttpContext kontrolü
        //        if (_contextAccessor?.HttpContext == null)
        //            throw new Exception("HttpContext is null.");

        //        // Kullanıcı kontrolü
        //        var user = _contextAccessor.HttpContext.User;
        //        if (user == null || !user.Identity.IsAuthenticated)
        //            throw new Exception("User is not authenticated.");

        //        // Token claim kontrolü
        //        var tokenClaim = user.Claims.FirstOrDefault(x => x.Type == "Token");
        //        if (tokenClaim == null)
        //            throw new Exception("Token claim not found.");

        //        return tokenClaim.Value;
        //    } }
        public string GetUserToken => _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Token")?.Value;
        public int GetUserId => int.Parse(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        public string GetUserRole => _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
        public string GetUserNameSurname => _contextAccessor.HttpContext.User.FindFirst("fullName")?.Value;
    }
}
