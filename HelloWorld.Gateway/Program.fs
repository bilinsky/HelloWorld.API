open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Logging
open Ocelot.DependencyInjection
open Ocelot.Middleware

[<EntryPoint>]
let main args =
    printfn "Iniciando o Gateway..."

    let builder = WebApplication.CreateBuilder(args)

    printfn "Configurando logs..."
    builder.Logging.ClearProviders() |> ignore
    builder.Logging.AddConsole() |> ignore

    printfn "Configurando serviços..."
    builder.Services.AddOcelot() |> ignore

    printfn "Construindo o app..."
    let app = builder.Build()

    printfn "Configurando URLs..."
    app.Urls.Add("http://0.0.0.0:80")

    printfn "Iniciando o Middleware do Ocelot..."
    app.UseOcelot().Wait()

    printfn "Iniciando o servidor..."
    let logger: ILogger<obj> = app.Services.GetRequiredService<ILogger<obj>>()
    logger.LogInformation("Ocelot Gateway iniciado e aguardando conexões...")

    app.Run()
    0 // Código de saída

