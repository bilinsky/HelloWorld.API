
open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Hosting
open Ocelot.DependencyInjection
open Ocelot.Middleware

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)

    // Configurar o Ocelot
    builder.WebHost.UseUrls("http://*:80") |> ignore
    builder.Services.AddOcelot() |> ignore

    let app = builder.Build()

    // Configurar o middleware do Ocelot
    app.UseOcelot().Wait()

    0 // Exit code

