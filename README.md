## Descrição do Projeto

Este projeto é uma aplicação de exemplo para gerenciar informações sobre transporte público, utilizando a tecnologia .NET 6, C#, e seguindo uma arquitetura CQRS (Command Query Responsibility Segregation). O projeto visa demonstrar boas práticas de desenvolvimento, utilização de tecnologias modernas e organização de código.

## Tecnologias Utilizadas

### Arquitetura CQRS

O projeto segue a arquitetura CQRS, que separa as operações de leitura e escrita, proporcionando uma melhor organização e escalabilidade. O MediatR é utilizado para facilitar a implementação e o gerenciamento de comandos e consultas.

### AutoMapper

A biblioteca AutoMapper é utilizada para facilitar a conversão de objetos entre diferentes modelos, tornando o código mais limpo e eficiente.

### Swagger

A documentação da API é gerada automaticamente pelo Swagger, facilitando o entendimento das operações disponíveis e permitindo testes diretos na interface.

### Banco de Dados PostgreSQL

O projeto utiliza o banco de dados PostgreSQL para armazenar as informações sobre linhas, paradas, veículos e posições de veículos. O acesso ao banco é realizado de forma eficiente utilizando o Entity Framework Core.

### Docker e Docker Compose

O Docker é utilizado para empacotar a aplicação e o banco de dados PostgreSQL, garantindo que o ambiente de desenvolvimento seja consistente em diferentes máquinas. O Docker Compose é utilizado para orquestrar a execução dos contêineres.

### BAT para Inicialização do Projeto

Um arquivo BAT (Batch) é fornecido para facilitar a inicialização do projeto. Este arquivo automatiza a execução de comandos necessários, como a construção e execução dos contêineres Docker, a aplicação de migrações do banco de dados, etc.

### RESTful API

A API segue os princípios RESTful, proporcionando uma interface simples e intuitiva para interação com o sistema.

### .NET 6 e C#

O projeto é desenvolvido utilizando .NET 6, aproveitando suas novas funcionalidades e melhorias de desempenho. O código é escrito em C#, uma linguagem poderosa e versátil.

## Configuração e Execução

1. **Pré-requisitos:**
   * Certifique-se de ter o .NET 6 SDK instalado em sua máquina.
   * Tenha o Docker e o Docker Compose instalados.
2. **Clonar o Repositório:** git clone https://github.com/holandalelis/net-aiko
3. **Executar o Projeto:**
   Execute o arquivo `run-dev.bat` para iniciar a aplicação e o banco de dados utilizando o Docker Compose.
4. **Acessar a Aplicação:**
   Acesse a documentação da API através do Swagger em [http://localhost:5000/swagger]().

## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues, propor melhorias ou enviar pull requests.
