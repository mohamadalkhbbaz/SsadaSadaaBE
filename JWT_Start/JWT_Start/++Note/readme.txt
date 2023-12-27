Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore -Version 6.0.12

Install-Package Microsoft.EntityFrameworkCore -Version 6.0.12
Install-Package Microsoft.EntityFrameworkCore.Design -Version 6.0.12
Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 6.0.12
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 6.0.12

Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design -Version 6.0.12

Install-Package System.IdentityModel.Tokens.Jwt -Version 6.13.1
Install-Package Microsoft.AspNetCore.Authentication.JwtBearer -Version 6.0.12

>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> .... <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
HEADER:ALGORITHM & TOKEN TYPE
{
  "alg": "HS384",
  "typ": "JWT"
}

PAYLOAD:DATA
{
  "sub": "1234567890",
  "name": "John Doe",
  "iat": 1516239022,
  "userID":"1231"
}

VERIFY SIGNATURE 
HMACSHA384(
  base64UrlEncode(header) + "." +
  base64UrlEncode(payload),
your-256-bit-secret

)

>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> .... <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
add in file settings : 
"JWT": {
    "Key": "",
    "Issuer": "GoJWT",
    "Audience": "GoJWT",
    "DurationDays": 30
  }

get key from : https://www.javainuse.com/jwtgenerator
