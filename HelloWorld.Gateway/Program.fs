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

    let result =
        try
            app.UseOcelot().Wait()
            printfn "Middleware do Ocelot iniciado com sucesso."
            true
        with
        | ex ->
            printfn "Erro ao iniciar o Middleware do Ocelot: %s" ex.Message
            false

    if result then
        printfn "Executando o servidor..."
        app.Run()
    else
    printfn "O servidor não pôde ser iniciado devido a erros no middleware."

