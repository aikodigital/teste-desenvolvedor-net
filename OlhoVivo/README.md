
<h2>:point_right: Introdução</h2>

Este repositório foi feito com intuito de demonstrar a minha solução, relacionado ao desafio para a vaga de desenvolvedor .NET Pleno da empresa Aiko.

<b>Neste projeto apliquei Princípios, Padrões e Praticas de:</b>

* SOLID
* Padrões de Injecão de Dependência e Inversão de controle para aplicar o DIP (Dependency Inversion Principle)
* Classes com Alta Coesão
* Baixo Acoplamento de camadas e classes
* Clean Architecture como padrão arquitetural
* Testes unitários 
* Praticas do BDD 

<h2>:technologist: Preparação do Ambiente</h2>

Para rodar este projeto basta configurar a sua <b>string de conexão</b> com o banco de dados SQL Server nos projetos <b>WebAPI</b> e <b>WebUI</b> nos arquivos <b>appsettings.json</b>

<div align="center">
  <img src="https://github.com/Willian-Brito/teste-desenvolvedor-net/blob/teste/willian-brito/OlhoVivo/Presentation/WebUI/wwwroot/img/config%201.png" alt="Arquivo de configuração da aplicação" />
</div>

Agora é só rodar as <b>Migrations</b> do <b>Entity Framework</b> para a criação das tabelas e população dos dados, para isso vá até a pasta  <b>OlhoVivo/Infrastucture/Data</b> e execute o comando abaixo, no terminal integrado do visual code:

    dotnet ef database update

Para acessar a aplicação web ou gerar o token de autenticação e autorização para acesso as APIs, basta iniciar os projetos correspondentes e utilizar as seguintes credenciais de login.: 

    Email: admin@localhost
    Senha: Numsey#2024

    Email: usuario@localhost
    Senha: Numsey#2024

Esses usuários serão criados quando iniciar a aplicação.


<h2>:movie_camera: Link do Vídeo do Youtube</h2>
<b>https://youtu.be/pZA-_Air-y0</b>
