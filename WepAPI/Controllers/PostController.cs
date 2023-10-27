using Application.LogicInterface;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostLogic postLogic;

    public PostController(IPostLogic postLogic)
    {
        this.postLogic = postLogic;
    }
  
    [HttpPost]
    [Route("createPost")]
    public async Task<ActionResult<Post>> createAsync([FromBody]PostCreationDTO dto)
    {
        try
        {
            Post post = await postLogic.CreateAsync(dto);
            return Created($"/posts/{post.Id}", post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}