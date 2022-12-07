# PocDatalustSeq
POC usando Serilog + Seq para armazenamento e visualização de logs.

# Preparação de Ambiente

## Pacotes necessários
`Serilog.AspNetCore`
<br>
`Serilog.Sinks.Seq`

## Configurando Serilog
```csharp
// Serilog configuration.
Log.Logger = new LoggerConfiguration()
                .ReadFrom
                .Configuration(builder.Configuration)
                .CreateLogger();
builder.Logging.AddSerilog();
builder.Host.UseSerilog();
```

## Configurando AppSettings
```jsonc
{
  "Serilog": {
    "MinimumLevel": {
      "Default": "Verbose",
      "Override": {
        "Microsoft": "Warning",
      }
    },
    "WriteTo": [
      {
        "Name": "Seq",
        "Args": {
          "serverUrl": "http://localhost:5341"
        }
      }
    ]
  }
}

```

## Iniciando o Datalust Seq com Docker

A porta 80 é para acesso à interface de consulta dos logs. <br>
A porta 5341 é para ingestão dos logs (vide configuração anterior). <br>
`docker run -d -p 80:80 -p 5341:5341 -e ACCEPT_EULA=Y --name seq datalust/seq`

# Utilização

Feita a configuração, basta gravar os logs na aplicação que os mesmos poderão ser visualizados em:<br> 
`http://localhost:80`