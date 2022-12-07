# PocDatalustSeq
POC usando Serilog + Seq para armazenamento e visualização de logs.

# Preparação de Ambiente

## Pacotes necessários
`Serilog.AspNetCore`
`Serilog.Sinks.Seq`

## Configurando Serilog
```csharp
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
builder.Logging.AddSerilog();
```

## Configurando AppSettings
```jsonc
"Serilog": {
    "Using":  [ "Serilog.SInks.Seq" ],
    "WriteTo": [
      {
        "Name": "Seq",
        "Args": {
          "serverUrl": "http://localhost:5341"
        }
      }
    ]
  }
```

## Iniciando o Datalust Seq com Docker

A porta 80 é para acesso à interface de consulta dos logs. 
A porta 5341 é para ingestão dos logs (vide configuração anterior).
`docker run -d -p 80:80 -p 5341:5341 -e ACCEPT_EULA=Y --name seq datalust/seq`

# Utilização

Feita a configuração, basta gravar os logs na aplicação que os mesmos poderão ser visualizados em: 
`http://localhost:80`