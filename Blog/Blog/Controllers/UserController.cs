using Microsoft.AspNetCore.Mvc;

using Blog.models;
using Blog.services;
namespace Blog.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    public readonly UserService userservice;

    public UserController(UserService userservice)
    {
        this.userservice = userservice;
    }
    [HttpGet]
    public List<UserData> Getuser()
    {
        return userservice.Get();
    }
    [HttpPost]

    public async Task<IActionResult> PostStudent(UserData userdata)
    {
        await userservice.CreateAsync(userdata);
        return CreatedAtAction(nameof(Getuser), new { id = userdata.Id }, userdata);
    }
}
