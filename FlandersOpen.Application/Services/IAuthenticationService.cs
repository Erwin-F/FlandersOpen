namespace FlandersOpen.Application.Services
{
    public interface IAuthenticationService
    {
        AuthenticatedUserDto GetToken(UserCredentials credentials);
    }
}
