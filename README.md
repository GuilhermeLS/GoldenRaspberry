# Golden Raspberry API

Esta aplicação expõe endpoint RESTful para consulta de vencedores e indicados à categoria de Pior Filme do Golden Raspberry Awards.

## Requisitos
- .NET 6 ou superior instalado.
- SDK do Visual Studio (preferencialmente com suporte a ASP.NET Core).

## Configuração do Projeto
1. Clone o repositório.
2. Copie o arquivo "movielist.csv" para um diretório local com permissão de leitura.   
3. Configure o caminho do arquivo "movielist.csv" na variável PATH dos arquivos de configuração do projeto (appSettings.json e appsettings.Development.json)   
EXEMPLO
  "CsvFile": {
    "Path": "C:\\Users\\Guilherme\\source\\GoldenRaspberry\\movielist.csv"
  }
4. Execute o projeto.
