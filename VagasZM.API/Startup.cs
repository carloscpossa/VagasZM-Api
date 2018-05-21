using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Text;
using VagasZM.API.Seguranca;
using VagasZM.Compartilhado;
using VagasZM.Dominio.Comandos.EmpresaComandos;
using VagasZM.Dominio.Comandos.EmpresaComandos.Mapeamento;
using VagasZM.Dominio.Comandos.VagaEmpregoComandos;
using VagasZM.Dominio.Comandos.VagaEmpregoComandos.Mapeamento;
using VagasZM.Dominio.Repositorios;
using VagasZM.Dominio.Servicos;
using VagasZM.Infra.Dados.Contexto;
using VagasZM.Infra.Dados.Repositorios;
using VagasZM.Infra.Dados.Servicos;
using VagasZM.Infra.Dados.Transacoes;

namespace VagasZM.API
{
    public class Startup
    {
        public IConfiguration Configuracao { get; set; }

        private const string ISSUER = "c1f51f42kdfjb";
        private const string AUDIENCE = "c6bskdfjh645024";
        private const string SECRET_KEY = "d7e75f42-5756-4d15-b879-b6ccea645124";

        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY));

        public Startup(IHostingEnvironment env)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("configuracoes.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuracao = configurationBuilder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));

            });            

            services.AddCors();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Candidato", policy => policy.RequireClaim("VagasZM", "Candidato"));
                options.AddPolicy("UsuarioEmpresa", policy => policy.RequireClaim("VagasZM", "UsuarioEmpresa"));
            });

            services.Configure<TokenOptions>(options =>
            {
                options.Issuer = ISSUER;
                options.Audience = AUDIENCE;
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            //Banco de dados
            services.AddScoped<VagasZMDataContext, VagasZMDataContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //Manipuladores
            services.AddTransient<EmpresaComandoManipulador, EmpresaComandoManipulador>();
            services.AddTransient<VagaEmpregoComandoManipulador, VagaEmpregoComandoManipulador>();

            services.AddTransient<IEmpresaComandoMap, EmpresaComandoMap>();
            services.AddTransient<IVagaEmpregoComandoMap, VagaEmpregoComandoMap>();

            //Servicos
            services.AddTransient<IEmailServico, EmailServico>();

            //Repositorios
            services.AddTransient<IEmpresaRepositorio, EmpresaRepositorio>();
            services.AddTransient<IUsuarioEmpresaRepositorio, UsuarioEmpresaRepositorio>();
            services.AddTransient<IAreaProfissionalRepositorio, AreaProfissionalRepositorio>();
            services.AddTransient<ITipoContratacaoRepositorio, TipoContratacaoRepositorio>();
            services.AddTransient<IVagaEmpregoRepositorio, VagaEmpregoRepositorio>();
            services.AddTransient<ICidadeRepositorio, CidadeRepositorio>();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "Vagas Zona da Mata API", Version = "v1" });
            });

            services.AddElmahIo(o =>
            {                            
                o.ApiKey = "304b8fb7d96e4651b18edbd564ca5143";
                o.LogId = new Guid("c2a16405-04b0-4a25-98be-e0ba46d9b51f");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = ISSUER,

                ValidateAudience = true,
                ValidAudience = AUDIENCE,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = tokenValidationParameters
            });


            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vagas Zona da Mata API - V1");
            });

            app.UseElmahIo();

            Runtime.StringDeConexao = Configuracao.GetConnectionString("VagazZM");
        }
    }
}
