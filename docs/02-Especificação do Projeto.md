# Especificações do Projeto

A definição exata do problema e os pontos mais relevantes a serem tratados neste projeto foi consolidada com a participação dos usuários em um trabalho de imersão feita pelos membros da equipe a partir da observação dos usuários em seu local natural e por meio de entrevistas. Os detalhes levantados nesse processo foram consolidados na forma de personas e histórias de usuários.

## Personas

As personas levantadas durante o processo de entendimento do problema são apresentadas na Figuras que se seguem.


![image](https://user-images.githubusercontent.com/114623537/226212811-5f22c1be-80af-46a9-b7fa-c88820f5fb71.png)

![image](https://user-images.githubusercontent.com/114623537/226212840-e58d1f41-6092-4fd1-891a-a9d12e74934f.png)

![image](https://user-images.githubusercontent.com/114623537/226213754-fadd80ec-7ac3-49bb-8ef0-26f38f77f1ff.png)

![image](https://user-images.githubusercontent.com/114623537/226213771-b059937c-295a-41ba-a6ad-6f17899c766e.png)

![image](https://user-images.githubusercontent.com/114623537/226213784-fb978906-5a6a-49f3-a290-9ddfa6a80f04.png)


## Histórias de Usuários

A partir da compreensão do dia a dia das personas identificadas para o projeto, foram registradas as seguintes histórias de usuários.

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|Amanda Alves  | consultar os dados dos pacientes através de um sistema          | diminuir o tempo médio de atendimento              |
|Amanda Alves      | inserir os dados dos pacientes através de um sistema                 | aumentar a qualidade do atendimento |
|Carlos Gomes|consultar o histórico do paciente |comparar as últimas aferições semióticas e verificar a história pregressa e familiar |
|Carlos Gomes |atualizar o estado de saúde atual do paciente |definir ou atualizar a história pregressa familiar do paciente |
|Paula Santos |consultar, por meio de um único sistema, os custos de atendimento dos pacientes |gastar menos tempo em extração de dados e focar na análise no faturamento mensal |
|Rodolfo Lima |gostaria de ser atendido rapidamente nos setores do hospital |que meu problema de saúde seja solucionado o mais rápido possível |
|Rodolfo Lima |gostaria de ter a garantia de que o valor cobrado pelo hospital reflita o real custo do atendimento |para que eu possa confiar na instituição e no tratamento recebido |
|Debora Cristina |consultar os cadastros e prontuários |para ter ciência dos procedimentos e valores gastos |

## Requisitos

O escopo funcional do projeto é definido por meio dos requisitos funcionais que descrevem as possibilidades interação dos usuários, bem como os requisitos não funcionais que descrevem os aspectos que o sistema deverá apresentar de maneira geral. Estes requisitos são apresentados a seguir.

### Requisitos Funcionais

A tabela a seguir apresenta os requisitos do projeto, identificando a prioridade em que os mesmos devem ser entregues.

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| A aplicação deve possuir login do usuário conforme perfil: atendente, administrativo (analista financeiro e analista de SAC), clínico (médicos, enfermeiros, auxiliar de enfermagem). | ALTA | 
|RF-002| A aplicação deve apresentar em tela única todos os campos de entradas de registro do paciente com algumas opções de cadastro pré-definidas.   | ALTA |
|RF-003 |A aplicação deve exibir os dados cadastrais do paciente no prontuário. |ALTA |
|RF-004 |A aplicação deve permitir extração de dados dos custos de atendimento dos pacientes. |ALTA |
|RF-005 |A aplicação deve possibilitar o levantamento dos atendimentos clínicos por especialidades médicas. |ALTA |
|RF-006 |A aplicação deve permitir a realização da alta hospitalar de forma integrada com a recepção e o sistema financeiro. |ALTA |
|RF-007 |A aplicação deve fornecer ao médico a possibilidade de criar e consultar prontuários |ALTA |
|RF-008 |A aplicação deve fornecer ao recepcionista do hospital a possibilidade de inserir, atualizar e deletar usuários e também a opção de consulta-los |ALTA |

### Requisitos não Funcionais

A tabela a seguir apresenta os requisitos não funcionais que o projeto deverá atender.

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| A aplicação deve ser acessível somente na rede interna do hospital.  | ALTA | 
|RNF-002| A aplicação deve ter bom nível de contraste entre os elementos da tela em conformidade. |  MÉDIA | 
|RNF-003 |A aplicação deve ser capaz de disponibilizar dados rapidamente para todos os usuários do sistema. |ALTA |
|RNF-004 |A aplicação deve ser compatível com os principais navegadores do mercado (Google Chrome, Firefox, Microsoft Edge) |ALTA |
|RNF-005 |A aplicação deve ser fluida e intuitiva. | MÉDIA |
|RNF-006 |A aplicação deve garantir o sigilo dos dados dos pacientes. |ALTA |

## Restrições

As questões que limitam a execução desse projeto e que se configuram como obrigações claras para o desenvolvimento do projeto em questão são apresentadas na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue no final do semestre letivo, não podendo extrapolar a data de 07/07/2023. |
|02| O aplicativo deve se restringir às tecnologias básicas da Web no Front End e Back End.        |
|03| A equipe não pode subcontratar o desenvolvimento do trabalho. | 

## Diagrama de Casos de Uso

![image](https://user-images.githubusercontent.com/114623537/226217424-e71f1403-bab9-4848-8186-fd59a35c1c0f.png)
