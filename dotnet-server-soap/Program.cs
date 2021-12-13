using SoapCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddSoapCore();
services.AddSingleton<CalculatriceService>();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => {
	endpoints.UseSoapEndpoint<CalculatriceService>("/Calculatrice.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
});

app.Run();