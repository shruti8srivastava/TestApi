using System;
using Microsoft.AspNetCore.Mvc;
using TestApi.DTO;
using TestApi.Model;

namespace TestApi.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class HelloWorldController : ControllerBase
{
[HttpPost]
public IActionResult Post([FromBody] HelloWorldDTO helloWorldDTO){
    if(string.IsNullOrEmpty(helloWorldDTO.UserName)){
        return BadRequest("User Name cannot be Null");
    }
    HelloWorldModel helloWorldModel = new HelloWorldModel { Message = $"Hello {helloWorldDTO.UserName}!" };
    return Ok(helloWorldModel);
}
}
