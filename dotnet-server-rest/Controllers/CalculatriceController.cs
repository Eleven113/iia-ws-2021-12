using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_server_rest.Controllers;

[ApiController]
[Authorize]
[Route("/api/calculatrice")]
public class CalculatriceController : ControllerBase
{
    [HttpGet("additionner")]
    public CalculatriceResult Additionner(int a, int b)
    {
        return new CalculatriceResult(a + b);
    }

    [HttpGet("soustraire")]
    public CalculatriceResult Soustraire(int a, int b)
    {
        return new CalculatriceResult(a - b);
    }
}