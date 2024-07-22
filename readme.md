# Desafio UBC Net React

Este repositório contém o desafio proposto no [link](https://github.com/Uniao-brasileira-dos-Compositores/desafio-net-react), que tem o objetivo de criar uma WebAPI utilizando .NET 6 e um front-end em React com autenticação.

## Sumário

- [Desafio UBC Net React](#desafio-ubc-net-react)
- [Como Rodar o Projeto](#como-rodar-o-projeto)
  - [Rodando a API](#rodando-a-api)
  - [Rodando os testes](#rodando-os-testes)
  - [Rodando a WebUI](#rodando-a-webui)
- [Explicações sobre a Arquitetura do Projeto](#explicações-sobre-a-arquitetura-do-projeto)
  - [Camada de Negócios](#camada-de-negócios)
  - [Camada de Infraestrutura](#camada-de-infraestrutura)
  - [Camada de Aplicação](#camada-de-aplicação)
  - [Camada de API](#camada-de-api)
  - [Camada Web](#camada-web)
  - [Camada de Testes](#camada-de-testes)

## Como Rodar o Projeto

Certifique-se de ter a última versão estável do [Node.js](https://nodejs.org/en) e do [.NET 6](https://dotnet.microsoft.com/pt-br/download/dotnet/6.0) instalados em sua máquina.

### Rodando a API

Navegue até o diretório da API e execute-a com o comando `dotnet run`:
```shell
    cd src/DesafioUbc.Api/
    dotnet run
```
Para acessar a documentação da API via Swagger, acesse:
````shell
  http://localhost:5087
````

### Rodando os testes

Navegue até o diretório teste da API e execute-a com o comando `dotnet test`:
```shell
    cd tests/DesafioUbc.Api.Test/
    dotnet test
```
Navegue até o diretório teste da Aplicação e execute-a com o comando `dotnet test`:
```shell
    cd tests/DesafioUbc.Application.Test/
    dotnet test
```
Navegue até o diretório teste da Infraestrutura e execute-a com o comando `dotnet test`:
```shell
    cd tests/DesafioUbc.Infrastructure.Test/
    dotnet test
```

### Rodando a WebUI
Navegue até o diretório da aplicação React e siga os passos abaixo:
```shell
    cd src/DesafioUbc.Web/
    npm i
    npm run dev
```
A aplicação React estará disponível no localhost na porta 5145:
````shell
  http://localhost:5145
````

## Explicações sobre a arquitetura do projeto
O projeto segue a arquitetura em camadas para garantir a segregação de responsabilidades e facilitar a manutenção e escalabilidade. 
As camadas são:
- [Business](#business)
- [Infrastructure](#infrastructure)
- [Application](#application)
- [Api](#api)
- [Web](#web)
- [Tests](#tests)

#### Business
A camada de Business(Negócios) é a mais interna e contém as regras de negócio essenciais do projeto. Esta camada deve ser independente de outras camadas e expõe uma API que pode ser consumida pelas camadas externas.

#### Infrastructure
A camada de Infrastructure(Infraestrutura) lida com detalhes específicos da tecnologia, como o acesso ao banco de dados e outras interações com sistemas externos. Esta camada fornece as implementações necessárias para que a camada de Aplicação possa funcionar corretamente.

#### Application
A camada de Application(Aplicação) orquestra a interação entre a camada de Negócios e a camada de Infraestrutura. Ela é responsável por implementar a lógica de aplicação e coordena as operações necessárias para satisfazer os casos de uso da aplicação.

#### Api
A camada de API é responsável pela exposição dos serviços da aplicação através de endpoints HTTP/HTTPS. Ela atua como uma interface para o mundo externo e facilita a comunicação entre o front-end e a lógica de negócios.

#### Web
A camada Web é a interface do usuário, desenvolvida com React neste projeto. Ela fornece uma UI interativa e amigável para o usuário final interagir com a aplicação.

#### Tests
A camada de Testes é dedicada à escrita e execução de testes automatizados para verificar a funcionalidade das outras camadas. Os testes garantem que cada parte do sistema funcione corretamente e ajudem a identificar e corrigir problemas de forma precoce.