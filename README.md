# Account - API

- [Desenvolvimento, por onde começar](#desenvolvimento-por-onde-começar)
- [Execução do projeto](#execução-do-projeto)
- [Estrutura](#estrutura)

## Desenvolvimento, por onde começar

Passos para execução do projeto:

1. Abrir *Prompt de Comando* de sua preferência (**CMD** ou **PowerShell**);

2. clonar o projeto;

## Execução do projeto

### **Docker**

1. Executar comando na **raiz** do projeto:

> *docker-compose up -d*

2. logs de execução:

> *docker-compose logs*

3. Parar e remover container:

> *docker-compose down*

## Estrutura

Padrão das camadas do projeto:

1. **Bank.Account.Domain**: domínio da aplicação, responsável por manter as *regras de negócio*;
2. **Bank.Account.Data**: camada mais baixa, para acesso a dados;
3. **Bank.Account.API**: responsável pela *disponibilização* dos endpoints da API;
5. **Bank.Account.Application**: responsável pelo tramento de dados(request, response);
6. **Bank.Account.Unit.Tests**: responsável pela camada de *testes unitários* dos projetos.
7. **WorkerServiceAccount**: responsável pela execução em background, aplicação da conta remunerada;
