# Teste Desenvolvedor .NET

![Aiko](imagens/aiko.png)

Olá, meu nome é Elias Lasmar!

## Primeira Etapa

No dia 20/05/2022, fiz uma videochamada com o **Tiago Pereira** onde iniciei as primeiras implementações.

Ao finalizarmos a videochamada, o Tiago disse que eu não precisaria gravar o vídeo, porém pediu para que eu descrevesse as mudanças que fiz relativas ao que se pedia no enunciado.

## Entidades

![Entidades](imagens/backend_diagrama.png)

* Nas entidades **Linha**, **Parada** e **Veiculo** achei que não faria sentido a exclusão física, pois mesmo que uma linha, parada ou veículo não estivesse mais operando, não faz sentido que estes dados sejam perdidos. Assim estas entidade receberam a propriedade **Ativo** do tipo booleano. Com isso, o serviço de exclusão destas entidades, na verdade é uma alteração da propriedade Ativo de **true** para **false**.

* A relação entre **Linha** e **Parada** pra mim deve ser N pra N, pois uma linha pode conter várias paradas e uma parada pode conter várias linhas (no mundo real, um ponto de ônibus normalmente é o local de (des)embarque de pessoas em veículos de mais de uma linha). Assim, foi criada a relação **RelLinhaParada**. ***OBS.:** Onde trabalho temos o costume de utilizar o prefixo Rel para relações.*

* No mundo real, ao longo do tempo, um veículo pode operar em linhas diferentes. Por exemplo, num dia de um grande evento, algumas determinadas linhas podem precisar de mais veículos, assim veículos de outras linhas podem ser deslocados. Por isso não coloquei uma FK de **Linha** em **Veiculo**. Resolvi criar a relação **RelVeiculoLinha** e acrescentar nesta relação as propriedades **DataInicio** e **DataFim** para indicar o período que o veículo operou na linha.

* Na **PosicaoVeiculo** acredito que faz sentido indicar em que momento o veículo passou por aquela posição. Para isso acrescentei a propriedade **DataPosicao**.

***OBS.:** Todas estas mudanças nas entidades foram discutidas com o **Tiago Pereira** durante a videochamada do dia 20/05/2022.*

## CRUD

Implementei todas operações CRUD (lembrando que nas entidades **Linha**, **Parada** e **Veiculo** a exclusão é lógica):
* **POST:** `api/[nome-entidade]/cadastrar` (o objeto vai pelo body)
* **GET:** `api/[nome-entidade]/consultar/[id-registro]`
* **GET:** `api/[nome-entidade]/listar`
* **PUT:** `api/[nome-entidade]/alterar` (o objeto vai pelo body)
* **DELETE:** `api/[nome-entidade]/excluir/[id-registro]`

O GetAll de **PosicaoVeiculo** retornaria uma grande quantidade de pontos de muitos anos atrás de vários veículos, por isso na listagem (`api/posicaoVeiculo/listarPorVeiculo`) acrescentei como parâmetros o identificador do veículo (**id**) e o período (**dataInicio** e **dataFim**).

Apesar de ter criado os serviços de alteração, exclusão e consulta da **PosicaoVeiculo** acredito que eles não seriam utilizados. Penso que à medida que o veículo vai se deslocando é chamado o serviço de cadastro para inserir as posições no banco e essas posições, uma vez inseridas, não devem ser alteradas.

## Métodos

* `Linhas por Parada`: Implementado como solicitado (`api/linha/listarPorParada/[id-parada]`).

* `Veiculos por Linha`: Como um veículo está vinculado a uma linha por um determinado período, no método (`api/veiculo/listarPorLinha/[id-linha]`) foi acrescentado como parâmetro o período (**dataInicio** e **dataFim**).

## Extras

* `Paradas por Posição`: Para evitar o retorno de todas as paradas do banco de dados, no serviço (`api/parada/listarPorPosicao/`), além da posição (**latitude** e **longitude**) também acrescentei o parâmetro **quantidade** que indica o número de paradas mais próximas a serem retornadas.

* **Documentação**: Utilizado o `swagger`.

* **Teste Unitário**: Foi criado o projeto AikoTest dentro da solution do projeto e implementado alguns testes unitários.

## Banco de Dados

Utilizei o PostgreSQL e criei a pasta [_DataBase](_DataBase/) com os scripts para criação do banco, usuário, esquema, entidades, relações e inserção de alguns dados.

## Considerações Finais

Agradeço a oportunidade de participar do processo seletivo da empresa.

Nos serviços que recebem um período como parâmetro, caso não seja informado o período, é utilizado a data corrente.

Eu acredito que a consulta por posição seria melhor utilizando dados do tipo espacial.

Nas entidade onde temos propriedades **Latitude** e **Longitude** eu recomendaria a substituição pelo tipo espacial `point`. Ou então, caso não seja possível, acrescentar uma propriedade do tipo point que é preenchida/alterada, por uma trigger no banco ou pelo próprio back-end, a partir dos valores informados de latitude e longitude.

Eu não realizei a implementação acima pois para isso precisaria utilizar a extensão PostGis do PostgreSQL e não sabia se isso seria permitido.