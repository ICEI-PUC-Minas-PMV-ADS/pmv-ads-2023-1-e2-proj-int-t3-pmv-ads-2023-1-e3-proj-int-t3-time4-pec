# Plano de Testes de Software

Os requisitos para realização dos testes de software são:

⦁	Site publicado na Internet

⦁	Navegador da Internet - Chrome, Firefox ou Edge

⦁	Conectividade de Internet para acesso às plataformas (APISs)

Os testes funcionais a serem realizados no aplicativo são descritos a seguir:
 
 <br>
 
| **Caso de Teste** 	| **CT-01 – Logar na aplicação** 	|
|:---:	|:---:	|
|	Requisitos Associados 	| RF-01 - A aplicação deve possuir login do usuário conforme perfil: atendente, clínico (médicos, enfermeiros, auxiliar de enfermagem), administrativo (analista financeiro e analista de SAC). |
| Objetivo do Teste 	| Verificar se a aplicação faz distinção dos perfis de usuário |
| Passos 	| 1) Acessar o Navegador <br> 2) Inserir a URL da aplicação <br> 3) Selecionar o perfil de usuário <br> 4) Submeter matrícula e senha no formulário de login |
|Critério de Êxito | ⦁	O sistema deve verificar se a matrícula e senha inseridos está associado ao perfil selecionado. <br> ⦁	Em caso de incompatibilidade dos dados de login, deve ser exibida uma mensagem informando a origem do problema. |
|  	|  	|
| Caso de Teste 	| **CT-02 – Inserir, atualizar e deletar usuários**	|
|Requisitos Associados | RF-02	- A aplicação deve apresentar em tela única todos os campos de entradas de registro do paciente com algumas opções de cadastro pré-definidas. <br> RF-08 - A aplicação deve fornecer ao recepcionista do hospital a possibilidade de inserir, atualizar e deletar usuários e também a opção de consulta-los. |
| Objetivo do Teste 	| Verificar se a aplicação apresenta um sistema que permite cadastrar, atualizar e deletar usuários |
| Passos 	| 1) Acessar o Navegador <br> 2) Informar o endereço do Site <br> 3) Logar utilizando um perfil recepcionista <br> 4) Clicar em uma das três opções: Novo usuário, Atualizar dados de usuário e deletar usuários|
|Critério de Êxito | ⦁	A página deve apresentar a opção Novo Cadastro apenas se o perfil utilizado for recepcionista. <br> ⦁	Ao clicar em Novo Cadastro, o sistema deve apresentar campos para preenchimento referentes ao nome, endereço, idade, sexo, telefone, e-mail e documentos. <br> ⦁	A opção de estado e sexo devem ser apresentadas em campos select.|
|  	|  	|
| Caso de Teste 	| **CT-03 – Extrair custos de consultas**	|
|Requisito Associado | RF-04	-A aplicação deve permitir extração de dados dos custos de atendimento dos pacientes. |
| Objetivo do Teste 	| Verificar se a aplicação permite extração de dados de custos de atendimento |
| Passos 	| 1) Acessar o Navegador <br> 2) Inserir a URL da aplicação <br> 3) Logar utilizando um perfil financeiro <br> 4) Filtrar consultas por data de entrada <br> 5) Clicar em exportar para excel |
|Critério de Êxito | ⦁	O sistema deve apresentar uma tabela com as seguintes colunas: id do paciente, data de entrada, valor total e valor pago. <br> ⦁	A aplicação deve exportar com êxito os dados expostos na interface gráfica para um arquivo excel. |
 |   |  	|
| Caso de Teste 	| **CT-04 – Criar prontuário**	|
|Requisito Associado | RF-07	- A aplicação deve fornecer ao médico a possibilidade de criar e consultar prontuários. |
| Objetivo do Teste 	| Verificar se a aplicação permite inserir um novo prontuário |
| Passos 	|  1) Acessar o Navegador <br> 2) Inserir a URL da aplicação <br> 3) Logar utilizando um perfil clínico <br> 4) Buscar paciente por meio do documento ou id <br> 5) Clicar em prontuários <br> 6) Clicar em novo prontuário <br> 7) Inserir data de entrada, data da alta e laudo descritivo <br> 8) Clicar em criar prontuário|
|Critério de Êxito | ⦁	O sistema deve apresentar campos para inserção dos dados do novo prontuário. <br> ⦁	A aplicação deve exportar com êxito os dados expostos na interface gráfica para um arquivo excel. |
 |  	|  	|
| Caso de Teste 	| **CT-05 – Consultar prontuário**	|
|Requisito Associado | RF-07	- A aplicação deve fornecer ao médico a possibilidade de criar e consultar prontuários. |
| Objetivo do Teste 	| Verificar se a aplicação permite consultar um prontuário |
| Passos 	| 1) Acessar o Navegador <br> 2) Inserir a URL da aplicação <br> 3) Logar utilizando um perfil clínico <br> 4) Buscar paciente por meio do documento ou id <br> 5) Clicar em prontuários <br> 6) Clicar em consultar prontuários <br> 7) Pesquisar pelo número da consulta <br> 8) Vizualizar prontuário. |
|Critério de Êxito | ⦁	A aplicação deve exportar com êxito os dados expostos na interface gráfica para um arquivo excel. |
 |  	|  	|
| Caso de Teste 	| **CT-06 – Realizar alta**	|
|Requisito Associado | RF-06	- A aplicação deve permitir a realização da alta hospitalar de forma integrada com a recepção e o sistema financeiro. |
| Objetivo do Teste 	| Verificar se a aplicação permite realizar a alta hospitalar |
| Passos 	| 1) Acessar o Navegador <br> 2) Inserir a URL da aplicação <br> 3) Logar utilizando um perfil financeiro ou recepcionista. <br> 4) Buscar exame por meio do documento ou id <br> 5) Clicar em altas <br> 6) Consultar se está tudo correto com o financeiro <br> 7) Emitir alta hospitalar |
|Critério de Êxito | ⦁	O sistema deve apresentar campos para colsulta de valores no sistema. <br> ⦁	A aplicação deve gerar uma alta para ser impressa e dada ao paciente.|
 
