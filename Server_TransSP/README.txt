*Observação: É necessário a utilização das seguintes configurações e Dependências: 
- EntityFramework 
- Sql Server 
- Asp.Net Core Versão 2.2.8 para compilar e para rodar a aplicação.

Para compilar e rodar a aplicação:
1_ Utilizar o comando dotnet run na pasta da aplicação;
2_ Rodar a aplicação no localhost. 
3_ O Nugget irá instalar todas as dependências necessárias recursivamente.

Teste API Olho Vivo:

Concluídos:
- Cadastro de novo usuário
- Cadastro da aplicação para resgate da chave de acesso às chamadas de serviço.
- Chave para o aplicativo "Server_TransSP" foi gerada com sucesso.
- Chamadas do Serviço pelo Postman.


PM> Add-Migration initial --> o código C# que é gerado pelo EF para gerar os scripts SQL.
 

Abordagem Utilizada: CodeFirst Escrever primeiro o código para depois ir para a criação das tabelas.