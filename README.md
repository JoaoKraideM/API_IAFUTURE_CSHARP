# IaFuture

API do projeto IaFuture - Software que controla resultados de análises feitas por IA

# Representantes 

- Gabriel Ortiz Oliva Gil - RM: 98642 – 2TDSPK
- Rafael Noboru Watanabe Nasaha - RM:99948 – 2TDSPK
- João Pedro Kraide Máximo - RM:550974 – 2TDSPK
- Matheus de Andrade Ferreira - RM:99375 – 2TDSPK
- Larissa Pereira Biusse - RM:551062 - 2TDSPK

# Objetivos da aplicação

- Cadastrar a empresa que vai precisar do nosso software, podendo ser qualquer tipo de empresa que busque através da IA, o crescimento de sua empresa;
- A empresa irá se cadastrar e fornecer alguns dados;
- Depois vamos recolher dados dos clientes que fazem uso do produto ou serviço fornecidos pela empresa que está fazendo uso do software;
- Esses dados servirão como dataset para utilizarmos as ferramentas da IA e de análise de dados para obtermos resultados que ajudem a empresa ter maior conhecimentos sobre seus consumidores.

# Explicação do modelo da aplicação

Foi adotado a abordagem monolítica para a aplicação pelos seguintes motivos:

- Por se tratar de um projeto menor e sem muitas complexidades, uma abordagem monolítica permite um desenvolvimento mais rápido
- Simplicidade na arquitetura, manter tudo em um único projeto facilita a compreensão e manutenção inicial por estar tudo em um único código base
- A integração entre componentes é mais direta e isso facilita a implementação de testes
- A latência é reduzida como também a sobrecarga associada à comunicação entre serviços distribuídos 
- Mais fácil de gerenciar transições que envolvem múltiplos componentes 

# Como rodar a aplicação

- Clonar o projeto do repositório no GitHub
- Executar o projeto no VS Code ou outra IDE para linguagem C# e projeto API Web Core
- Ao executar, uma página web do Swagger irá abrir
- No Swagger, teremos o CRUD de todas as classes 
- Para testar os endpoints, basta clicar em "try it out" e preencher de acordo com cada um
- Utilizar os seguintes JSON de exemplo nos métodos POST:
	
-> Para Conta
 
{
  "Nome": "Empresa Exemplo",
  "Telefone": "123456789",
  "Cnpj": "12345678000195",
  "Cep": "12345-678",
  "Logradouro": "Rua Exemplo",
  "Complemento": "Sala 101",
  "Bairro": "Centro",
  "Cidade": "São Paulo",
  "Estado": "SP",
  "Numero": "100",
  "Username": "usuario_exemplo",
  "Senha": "senha_secreta"
}

-> Para Cliente

{
  "nome": "João da Silva",
  "email": "joao.silva@email.com",
  "data Nascimento": "1990-01-15",
  "cpf": "123.456.789-10",
  "telefone": "(11) 98765-4321"
}

-> Para Feedback

{
  "dataFeedback": "2024-09-08,
  "comentario": "Excelente serviço!",
  "avaliacao": 5
}

-> Para Interação

{
  "dataInteracao": "2024-09-08",
  "tipo": "Chat",
  "canal": "WhatsApp"
}

-> Para Resultado

{
  "TipoAnalise": "Análise de Comportamento",
  "Detalhes": "Análise detalhada do comportamento dos clientes com base nas interações registradas."
}
