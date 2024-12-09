using System.Security.Claims;

namespace Movies.Api.Auth;

public static class IdentityExtansions
{
    public static Guid? GetUserId(this HttpContext context)
    {
        var userId = context.User.Claims.SingleOrDefault(x => x.Type == "userId");

        if (Guid.TryParse(userId?.Value, out var parsedId))
        {
            return parsedId;
        }
        
        return null;
    }
}