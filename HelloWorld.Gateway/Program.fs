open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.AspNetCore.Hosting

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)

    // Configurar o Gateway para escutar na porta 80
    builder.WebHost.UseUrls("http://*:80") |> ignore

    let app = builder.Build()

    // Exemplo de rota padrão
    app.MapGet("/", Func<string>(fun () -> "Hello, World from API!")) |> ignore

    app.Run()

    0 // Exit code

