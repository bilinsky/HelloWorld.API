open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Logging
open Ocelot.DependencyInjection
open Ocelot.Middleware

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)

    // Configurar logs
    builder.Logging.ClearProviders() |> ignore
    builder.Logging.AddConsole() |> ignore

    // Configurar o Ocelot
    builder.Services.AddOcelot() |> ignore

    let app = builder.Build()

    // Configurar URLs
    app.Urls.Add("http://0.0.0.0:80")

    // Middleware do Ocelot
    app.UseOcelot().Wait()

    // Log de inicialização
    let logger: ILogger<obj> = app.Services.GetRequiredService<ILogger<obj>>()
    logger.LogInformation("Ocelot Gateway iniciado e aguardando conexões...")

    // Executar o servidor
    app.Run()

    0 // Código de saída
