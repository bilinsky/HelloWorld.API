open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Logging
open Microsoft.Extensions.Configuration
open Ocelot.DependencyInjection
open Ocelot.Middleware

[<EntryPoint>]
let main args =
    printfn "Iniciando o Gateway..."

    let builder = WebApplication.CreateBuilder(args)

    printfn "Configurando logs..."
    builder.Logging.ClearProviders() |> ignore
    builder.Logging.AddConsole() |> ignore

    printfn "Configurando configuração..."
    builder.Configuration.AddJsonFile("ocelot.json") |> ignore

    // Exibir as configurações carregadas do ocelot.json
    let routes = builder.Configuration.GetSection("Routes").GetChildren()
    printfn "Rotas configuradas:"
    for route in routes do
        printfn "UpstreamPathTemplate: %s, DownstreamPathTemplate: %s" 
            (route.GetValue<string>("UpstreamPathTemplate")) 
            (route.GetValue<string>("DownstreamPathTemplate"))

    printfn "Configurando serviços..."
    builder.Services.AddOcelot() |> ignore

    printfn "Construindo o app..."
    let app = builder.Build()

    //printfn "Configurando URLs..."
    //app.Urls.Add("http://localhost:8000")

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
        0
    else
        printfn "O servidor não pôde ser iniciado devido a erros no middleware."
        1
