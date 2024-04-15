namespace backend02;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Projeto Web - LH Pets v1");

        app.UseStaticFiles();

        app.MapGet("/index", (HttpContext context)=> {
            context.Response.Redirect("index.html", false);
        });

        Banco dba= new Banco();
        app.MapGet("/listarClientes", (HttpContext context) => {
            context.Response.WriteAsync(dba.GetListaString());
        });

        app.Run();
    }
}
