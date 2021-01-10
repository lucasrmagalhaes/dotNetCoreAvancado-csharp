<h1 align="left">Apresentação do cenário e documentação da API com Swagger</h1>

<ul>
  <li><a href="https://github.com/lucasrmagalhaes/.NETCoreAvancado-DIO/tree/main/1.%20Apresenta%C3%A7%C3%A3o%20do%20cen%C3%A1rio%20e%20documenta%C3%A7%C3%A3o%20da%20API%20com%20Swagger#introdu%C3%A7%C3%A3o-e-setup-da-api">Introdução e setup da API</a></li>
  <li><a href="https://github.com/lucasrmagalhaes/.NETCoreAvancado-DIO/tree/main/1.%20Apresenta%C3%A7%C3%A3o%20do%20cen%C3%A1rio%20e%20documenta%C3%A7%C3%A3o%20da%20API%20com%20Swagger#conhe%C3%A7a-o-postman">Conheça o Postman</a></li>
  <li><a href="https://github.com/lucasrmagalhaes/.NETCoreAvancado-DIO/tree/main/1.%20Apresenta%C3%A7%C3%A3o%20do%20cen%C3%A1rio%20e%20documenta%C3%A7%C3%A3o%20da%20API%20com%20Swagger#introdu%C3%A7%C3%A3o-a-biblioteca-swashbucleaspnetcoreannotations">Introdução a biblioteca Swashbucle.AspNetCore.Annotations</a></li>
  <li><a href="#">Usando ConfigureApiBehaviorOptions</a></li>
</ul>

<hr />

<h4 align="left">Objetivos</h4>

<ol>
  <li>Organizar os componentes de uma aplicação.</li>
  <li>Documentar uma API.</li>
  <li>Aplicar o Design Pattern.</li>
</ol>

<hr />

<h1 align="center">Introdução e setup da API</h1>

<h4 align="left">Parte 1: Apresentação do cenário</h4>

<p align="left">
  <img src="https://github.com/lucasrmagalhaes/.NETCoreAvancado-DIO/blob/main/1.%20Apresenta%C3%A7%C3%A3o%20do%20cen%C3%A1rio%20e%20documenta%C3%A7%C3%A3o%20da%20API%20com%20Swagger/img/Apresenta%C3%A7%C3%A3o%20do%20Cen%C3%A1rio.jpg" alt="Apresentação do cenário">
</p>

<hr />

<h4 align="left">Histórias de usuário</h4>

<ul>
  <li>Cadastro de usuário</li>
  <li>Login de usuário</li>
  <li>Cadastro de curso de usuário autenticado</li>
  <li>Lista de cursos do usuário autenticado</li>
</ul>

<hr />

<h4 align="left">Parte 2: O setup da API</h4>

<p align="left">
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ferramenta utilizada: <a href="https://visualstudio.microsoft.com/pt-br/">Visual Studio</a><br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Create a new project<br />

  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ASP.NET Core Web Application<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Next<br />

  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Project name: curso.api<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Solution name: curso<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Next<br />

  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;API<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Advanced - [X] Configure for HTTPS<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Create<br />

  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Remover:<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WeatherForecast.cs<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Controllers -> WeatherDorecastController.css<br />
  
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Properties -> launchSettings.json<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Linha 15 e 23: "launchUrl": "" - Deixar em branco.<br />

  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Salvar e Executar.<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Não foi possível encontrar a página deste localhost
</p>

<hr />

<h4 align="left">Criação do Serviço REST</h4>

<h5 align="center">Configuração das rotas (endpoints)</h5>

<p align="left">
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dentro de Controllers, criar um controller:<br />

  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Add<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Controller...<br />

  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;API Controller - Empty<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Add<br />

  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name: UsuarioController.cs<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Add
</p>

```c#
using curso.api.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            return Ok(loginViewModelInput);
        }
    }
}
```

<hr />

<p align="left">
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dentro de curso.api, criar o diretório: Models<br />

  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Add<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;New Folder<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name: Models<br />

  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dentro de Models, criar o diretório: Usuarios<br />

  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dentro de Usuarios, criar a primeira Classe<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name: LoginViewModelInput
</p>

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Models.Usuarios
{
    public class LoginViewModelInput
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
```

<hr />

<h1 align="center">Conheça o <a href="https://www.postman.com/">Postman</a></h1>

<p align="left">
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Primeiro Teste:
</p>

<pre>
POST: https://localhost:44307/api/Usuario

Body 
(X) raw - | Text: JSON
</pre>

```json
{
  "Login": "teste",
  "Senha": "senha"
}
```

<pre>
Status: 200 OK
</pre>

<hr />

<p align="left">
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dentro de Usuarios, criar a Classe: RegistroViewModelInput
</p>

```C#
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Models.Usuarios
{
    public class RegistroViewModelInput
    {
        [Required(ErrorMessage = "O Login é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O E-mail é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }
    }
}
```

<hr />

<p align="left">
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UsuarioController<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Registrar adicionado.
</p>

```C#
using curso.api.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("logar")]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            return Ok(loginViewModelInput);
        }

        [HttpPost]
        [Route("registrar")]
        public IActionResult Registrar(RegistroViewModelInput loginViewModelInput)
        {
            return Created("", loginViewModelInput);
        }
    }
}
```

<hr />

<p align="left">
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Testando a classe - Logar com a nova URL:
</p>

<pre>
POST: https://localhost:44307/api/v1/usuario/logar

Body 
(X) raw - | Text: JSON
</pre>

```json
{
  "Login": "teste",
  "Senha": "senha"
}
```

<pre>
Status: 200 OK
</pre>

<hr />

<p align="left">
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Testando a classe - Registrar:
</p>

<pre>
POST: https://localhost:44307/api/v1/usuario/registrar

Body 
(X) raw - | Text: JSON
</pre>

```json
{
  "Login": "Lucas",
  "Senha": "123",
  "Email": "lucasdarosa.ti@gmail.com"
}
```

<pre>
Status: 201 Created
</pre>

<hr />

<h1 align="center">Introdução a biblioteca Swashbucle.AspNetCore.Annotations</h1>

<h4 align="left">Configuração do swagger para documentação da API</h4>

<ul>
  <li>Instalação do Pacote Nuget</li>
  <li>Configuração do XML</li>
  <li>Configuração do Service (IOC)</li>
  <li>Habilitar o Middleware</li>
</ul>

<hr />

<h5 align="center">Documentação do código em xml</h5>

<p align="left">
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Botão direito do mouse em curso.api<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Build<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[X] XML documentation file: curso.api.xml<br />
  
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Botão direito do mouse em curso.api<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Build
</p>

<hr />

<h5 align="center">Configuração do Swagger</h5>

<p align="left">
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Botão direito do mouse em Dependencies<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Manage NuGet Packages...<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Browse: Swashbucle.AspNetCore<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Install<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OK<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;I Accept<br />
</p>

<hr />

<h5 align="center">Configuração do Startup.cs</h5>

```C#
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;

namespace curso.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API curso");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
```

<p align="left">
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Executar<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;https://localhost:44307/<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Swagger rodando.
</p>

<hr />

<h5 align="center">Instalação de Ferramenta do Swagger</h5>

<p align="left">
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Botão direito do mouse em Dependencies<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Manage NuGet Packages...<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Browse: Swashbucle.AspNetCore.Annotations<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Install<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OK<br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;I Accept<br />
</p>

<hr />

<h5 align="center">
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Configurando a ferramenta:<br />
</h5>

```C#
using curso.api.Models;
using curso.api.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace curso.api.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("logar")]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            return Ok(loginViewModelInput);
        }

        [HttpPost]
        [Route("registrar")]
        public IActionResult Registrar(RegistroViewModelInput loginViewModelInput)
        {
            return Created("", loginViewModelInput);
        }
    }
}
```

<hr />

<h5 align="center">
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Criando as classes de tratamento de erro:<br />
</h5>

<p align="left">
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dentro de Models, criar a Classe: ErroGenericoViewModel
</p>

```C#
namespace curso.api
{
    public class ErroGenericoViewModel
    {
        public string Mensagem { get; set; }
    }
}
```

<p align="left">
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dentro de Models, criar a Classe: ValidaCampoViewModelOutput
</p>

```C#
using System.Collections.Generic;

namespace curso.api.Models
{
    public class ValidaCampoViewModelOutput
    {
        public IEnumerable<string> Erros { get; private set; }

        public ValidaCampoViewModelOutput(IEnumerable<string> erros)
        {
            Erros = erros;
        }
    }
}
```
<hr />

<h5 align="center">Setup validação de entrada de dados</h5>

<ul>
  <li>Criação das ViewModels</li>
  <li>Configuração das ViewModels</li>
  <li>Configuração do Action Filter</li>
  <li>Configuração do Startup</li>
</ul>


<hr />

<h1 align="center">Usando ConfigureApiBehaviorOptions</h1>

