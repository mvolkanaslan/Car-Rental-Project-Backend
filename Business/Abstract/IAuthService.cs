using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult Update(UserForUpdateDto userForUpdateDto);
        IResult ChangePassword(UserForUpdateDto userForUpdateDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
