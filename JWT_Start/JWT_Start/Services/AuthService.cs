using JWT_Start.Dtos;
using JWT_Start.Helpers;
using JWT_Start.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_Start.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JWT _jwtSetting;
        public AuthService(UserManager<ApplicationUser> userManager, IOptions<JWT> option)
        {
            _userManager = userManager;
            _jwtSetting = option.Value;
        }

        public async Task<RegistrResultDto> GetToken(LoginInputDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user is null || !await _userManager.CheckPasswordAsync(user, dto.Password))
                return new RegistrResultDto { Message = "Email Or Password Not Correct" };

            var jwtToken = await CreateJwtToken(user);
            var userRoles = await _userManager.GetRolesAsync(user);
            var result = new RegistrResultDto
            {
                Email = user.Email,
                UserName = user.UserName,
                IsAuthentecated = true,
                Roles = userRoles.ToList(),
                Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                ExpireOn = jwtToken.ValidTo
            };

            return result;
        }

        public async Task<RegistrResultDto> RegisrUser(RegistrInputDto dto)
        {
            if (await _userManager.FindByEmailAsync(dto.Email) is not null)
                return new RegistrResultDto { Message = "Email is already registred" };
            if (await _userManager.FindByNameAsync(dto.UserName) is not null)
                return new RegistrResultDto { Message = "UserName is already registred" };

            var user = new ApplicationUser();
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.UserName = dto.UserName;
            user.Email = dto.Email;

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                return new RegistrResultDto { Message = string.Join(" ,", result.Errors.Select(x => x.Description)) };
            }

            await _userManager.AddToRoleAsync(user, "User");
            var jwtSecToken = await CreateJwtToken(user);

            return new RegistrResultDto
            {
                Email = user.Email,
                UserName = user.UserName,
                ExpireOn = jwtSecToken.ValidTo,
                IsAuthentecated = true,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecToken)
            };
        }


        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleCliams = roles.Select(x => new Claim("roles", x)).ToList();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uId",user.Id)
            }.Union(userClaims)
            .Union(roleCliams);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Key));
            var singingCredential = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecToken = new JwtSecurityToken
            (issuer: _jwtSetting.Issuer,
            audience: _jwtSetting.Audience,
            claims: claims,
            expires: DateTime.Now.AddDays(_jwtSetting.DurationDays),
            signingCredentials: singingCredential);

            return jwtSecToken;
        }
    }
}
