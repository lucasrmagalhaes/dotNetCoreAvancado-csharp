<h1 align="left">Apresentação do cenário e documentação da API com Swagger</h1>

<ul>
  <li><a href="https://github.com/lucasrmagalhaes/.NETCoreAvancado-DIO/tree/main/1.%20Apresenta%C3%A7%C3%A3o%20do%20cen%C3%A1rio%20e%20documenta%C3%A7%C3%A3o%20da%20API%20com%20Swagger#parte-1-apresenta%C3%A7%C3%A3o-do-cen%C3%A1rio">Introdução e setup da API</a></li>
  <li><a href="#">Conheça o Postman</a></li>
  <li><a href="#">Introdução a biblioteca Swashbucle.AspNetCore.Annotations</a></li>
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
            return Created("", loginViewModelInput);
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