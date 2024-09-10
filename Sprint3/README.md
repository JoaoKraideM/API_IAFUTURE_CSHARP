# IaFuture

API do projeto IaFuture - Software que controla resultados de an�lises feitas por IA

# Representantes 

- Gabriel Ortiz Oliva Gil - RM: 98642 � 2TDSPK
- Rafael Noboru Watanabe Nasaha - RM:99948 � 2TDSPK
- Jo�o Pedro Kraide M�ximo - RM:550974 � 2TDSPK
- Matheus de Andrade Ferreira - RM:99375 � 2TDSPK
- Larissa Pereira Biusse - RM:551062�-�2TDSPK

# Objetivos da aplica��o

- Cadastrar a empresa que vai precisar do nosso software, podendo ser qualquer tipo de empresa que busque atrav�s da IA, o crescimento de sua empresa;
- A empresa ir� se cadastrar e fornecer alguns dados;
- Depois vamos recolher dados dos clientes que fazem uso do produto ou servi�o fornecidos pela empresa que est� fazendo uso do software;
- Esses dados servir�o como dataset para utilizarmos as ferramentas da IA e de an�lise de dados para obtermos resultados que ajudem a empresa ter maior conhecimentos sobre seus consumidores.

# Explica��o do modelo da aplica��o

Foi adotado a abordagem monol�tica para a aplica��o pelos seguintes motivos:

- Por se tratar de um projeto menor e sem muitas complexidades, uma abordagem monol�tica permite um desenvolvimento mais r�pido
- Simplicidade na arquitetura, manter tudo em um �nico projeto facilita a compreens�o e manuten��o inicial por estar tudo em um �nico c�digo base
- A integra��o entre componentes � mais direta e isso facilita a implementa��o de testes
- A lat�ncia � reduzida como tamb�m a sobrecarga associada � comunica��o entre servi�os distribu�dos 
- Mais f�cil de gerenciar transi��es que envolvem m�ltiplos componentes 

# Objetivos da aplica��o

- Cadastrar a empresa que vai precisar do nosso software, podendo ser qualquer tipo de empresa que busque atrav�s da IA, o crescimento de sua empresa;
- A empresa ir� se cadastrar e fornecer alguns dados;
- Depois vamos recolher dados dos clientes que fazem uso do produto ou servi�o fornecidos pela empresa que est� fazendo uso do software;
- Esses dados servir�o como dataset para utilizarmos as ferramentas da IA e de an�lise de dados para obtermos resultados que ajudem a empresa ter maior conhecimentos sobre seus consumidores.

# Como rodar a aplica��o

- Clonar o projeto do reposit�rio no GitHub
- Executar o projeto no VS Code ou outra IDE para linguagem C# e projeto API Web Core
- Ao executar, uma p�gina web do Swagger ir� abrir
- No Swagger, teremos o CRUD de todas as classes 
- Para testar os endpoints, basta clicar em "try it out" e preencher de acordo com cada um
- Utilizar os seguintes JSON de exemplo nos m�todos POST:
	
-> Para Conta
 
{
  "Nome": "Empresa Exemplo",
  "Telefone": "123456789",
  "Cnpj": "12345678000195",
  "Cep": "12345-678",
  "Logradouro": "Rua Exemplo",
  "Complemento": "Sala 101",
  "Bairro": "Centro",
  "Cidade": "S�o Paulo",
  "Estado": "SP",
  "Numero": "100",
  "Username": "usuario_exemplo",
  "Senha": "senha_secreta"
}

-> Para Cliente

{
  "nome": "Jo�o da Silva",
  "email": "joao.silva@email.com",
  "data Nascimento": "1990-01-15",
  "cpf": "123.456.789-10",
  "telefone": "(11) 98765-4321"
}

-> Para Feedback

{
  "dataFeedback": "2024-09-08,
  "comentario": "Excelente servi�o!",
  "avaliacao": 5
}

-> Para Intera��o

{
  "dataInteracao": "2024-09-08",
  "tipo": "Chat",
  "canal": "WhatsApp"
}

-> Para Resultado

{
  "TipoAnalise": "An�lise de Comportamento",
  "Detalhes": "An�lise detalhada do comportamento dos clientes com base nas intera��es registradas."
}
