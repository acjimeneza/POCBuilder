using Microsoft.AspNetCore.Mvc;

namespace pocBuilder.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;

    private readonly ILoggerTest _generalLogger;


    public UserController(ILogger<UserController> logger, IConfiguration configuration, ILoggerTest generalLogger)
    {
        _logger = logger;
        _configuration = configuration;
        _generalLogger = generalLogger;
        // _generalLogger = new GeneralLogger(configuration, logger); // Avoid the use of this process it always creates the object

    }

    [HttpGet("GetUser")]
    public User Get([FromQuery] String name)
    {
        return new User
        {
            Date = DateTime.Now,
            Name = name
        };
    }

    [HttpGet("GetError")]
    public string GetError()
    {
        _logger.LogError("This is one error emulated");
        _generalLogger.LogException("Info");
        return "Log => Error";
    }

    [HttpGet("GetInfo")]
    public string GetInfo()
    {
        _logger.LogInformation("This is one information Log emulated");
        _generalLogger.LogEvent("Info");
        return "Log => Info";
    }

    [HttpGet("GetWarning")]
    public string GetWarning()
    {
        _logger.LogWarning("This is one Warning Log emulated");
        _generalLogger.LogRequest("Info");
        return "Log => Warning";
    }

    [HttpGet("GetConfig")]
    public async Task<IActionResult>  GetConfig([FromQuery(Name = "conf")] string conf)
    {
        var result = await Task.FromResult<string>(_configuration[conf]);
            return Ok(result);
    }
}
