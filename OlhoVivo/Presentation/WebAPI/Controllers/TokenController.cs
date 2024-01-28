using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OlhoVivo.Core.Domain.Account;
using WebAPI.DTOs;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    #region Properties
    private readonly IAuthenticate _authentication;
    private readonly IConfiguration _configuration;
    #endregion

    #region Constructor
    public TokenController(IAuthenticate authentication, IConfiguration configuration)
    {
        _authentication = authentication ?? throw new ArgumentNullException(nameof(authentication));
        _configuration = configuration;
    }
    #endregion

    #region Actions

    #region Login

    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<ActionResult<UserTokenDTO>> Login([FromBody] LoginDTO userDTO) 
    {
        try
        {
            var result = await _authentication.Authenticate(userDTO.Email, userDTO.Password);

            if(result)
                return GenerateToken(userDTO);
            
            ModelState.AddModelError(string.Empty, "Login Inválido!");
            return BadRequest(ModelState);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    #endregion

    #region CreateUser

    [HttpPost("CreateUser")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    public async Task<ActionResult> CreateUser([FromBody] LoginDTO userDTO) 
    {
        try
        {
            var result = await _authentication.RegisterUser(userDTO.Email, userDTO.Password);

            if(result)
                return Ok($"Usuário {userDTO.Email} criado com sucesso!");
            
            ModelState.AddModelError(string.Empty, "Login Inválido!");
            return BadRequest(ModelState);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
    }
    #endregion

    #region GenerateToken
    private UserTokenDTO GenerateToken(LoginDTO userDTO)
    {
        #region Informações do Usuário
        var claims = new[]
        {
            new Claim("email", userDTO.Email),
            new Claim("teste", "teste123"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
        #endregion

        #region Chave Privada
        
        // gerar chave privada para assinar o token
        var secretKey = _configuration["Jwt:SecretKey"];
        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        // gerar assinatura digital
        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
        
        // definir o tempo de expiração
        var expiration = DateTime.Now.AddMinutes(30);

        // gerar o token
        var emissor = _configuration["Jwt:Issuer"];
        var audiencia = _configuration["Jwt:Audience"];

        var token = new JwtSecurityToken(
            issuer: emissor,
            audience:  audiencia,
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
        );
        #endregion

        #region UserTokenDTO
        var userToken = new UserTokenDTO()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration
        };
        #endregion

        return userToken;
    }
    #endregion

    #endregion
}
