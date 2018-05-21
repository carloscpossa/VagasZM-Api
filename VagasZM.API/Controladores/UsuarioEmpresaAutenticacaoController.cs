using FluentValidator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using VagasZM.API.Seguranca;
using VagasZM.Compartilhado.Utilitarios;
using VagasZM.Dominio.Comandos.UsuarioEmpresaComandos.Entradas;
using VagasZM.Dominio.Entidades;
using VagasZM.Dominio.Repositorios;
using VagasZM.Infra.Dados.Transacoes;

namespace VagasZM.API.Controladores
{
    public class UsuarioEmpresaAutenticacaoController : ControladorBase
    {
        private UsuarioEmpresa _usuarioEmpresa;

        private readonly IUsuarioEmpresaRepositorio _usuarioRepositorio;
        private readonly TokenOptions _tokenOptions;
        private readonly JsonSerializerSettings _serializerSettings;

        public UsuarioEmpresaAutenticacaoController(IOptions<TokenOptions> jwtOptions, IUnitOfWork UnitOfWork, IUsuarioEmpresaRepositorio usuarioRepositorio) : base(UnitOfWork)
        {
            _usuarioRepositorio = usuarioRepositorio;

            _tokenOptions = jwtOptions.Value;
            if (_tokenOptions == null)
                throw new ArgumentNullException(nameof(_tokenOptions));

            _tokenOptions.Validate();

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("v1/autenticacaoempresa")]
        public async Task<IActionResult> Autenticar([FromForm] AutenticarUsuarioEmpresaComando comando)
        {
            if (comando == null)
                return await Resposta(null, new List<Notification> { new Notification("Usuario", "Usuário ou senha inválidos") });

            var claimsIdentity = await BuscarClaims(comando);
            if (claimsIdentity == null)
                return await Resposta(null, new List<Notification> { new Notification("Usuario", "Usuário não encontrado.") });

            if (!_usuarioEmpresa.Autenticado(comando.Senha))
                return await Resposta(null, new List<Notification> { new Notification("Usuario", "Senha inválida.") });

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, _usuarioEmpresa.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, _usuarioEmpresa.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, _usuarioEmpresa.Email.EnderecoEmail),
                new Claim(JwtRegisteredClaimNames.Sub, _usuarioEmpresa.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, await _tokenOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ConversorData.ConverterParaUnixEpochDate(_tokenOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),                
            };

            foreach (Claim claim in claimsIdentity.Claims)
                claims.Add(claim);

            var jwt = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                claims: claims,
                notBefore: _tokenOptions.NotBefore,
                expires: _tokenOptions.Expiration,
                signingCredentials: _tokenOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                token = encodedJwt,
                expires = (int)_tokenOptions.ValidFor.TotalSeconds,
                user = new
                {
                    usuarioId = _usuarioEmpresa.Id,
                    nome = _usuarioEmpresa.Nome.nome,
                    email = _usuarioEmpresa.Email.EnderecoEmail,
                    empresaId = _usuarioEmpresa.Empresa.Id,
                    nomeEmpresa = _usuarioEmpresa.Empresa.NomeEmpresa.nome
                }
            };

            var json = JsonConvert.SerializeObject(response, _serializerSettings);
            return new OkObjectResult(json);
        }


        private Task<ClaimsIdentity> BuscarClaims(AutenticarUsuarioEmpresaComando comando)
        {
            var usuarioEmpresa = _usuarioRepositorio.BuscarUsuarioPorEmail(comando.Email);

            if (usuarioEmpresa == null)
                return Task.FromResult<ClaimsIdentity>(null);            

            _usuarioEmpresa = usuarioEmpresa;
            //Lista de Claims
            return Task.FromResult(new ClaimsIdentity(
                new GenericIdentity(usuarioEmpresa.Id.ToString(), "Token"),
                new[] {
                    new Claim("VagasZM", "UsuarioEmpresa"),
                    new Claim("EmpresaId", _usuarioEmpresa.Empresa.Id.ToString())
                }));
        }


    }
}
