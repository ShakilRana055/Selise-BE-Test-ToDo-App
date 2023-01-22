using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OnsiteDataAccess;
using System;
using ToDoAppDataAccess;
using ToDoAppDomain.Model;

namespace ToDoApp.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{
	private readonly IUnitOfWork unitOfWork;
	private readonly IValidator<User> validator;

	public UserController(IUnitOfWork unitOfWork, IValidator<User> validator)
	{
		this.unitOfWork = unitOfWork;
		this.validator = validator;
	}

	[HttpPut("UpdateUser/{id}")]
    public async Task<IActionResult> UpdateUser(int id, User user)
    {
        try
        {
            var exist = await unitOfWork.User.GetFirstOrDefault(item => item.Id == id);
            if (exist == null) return NotFound("User not Found");
			exist.FirstName = user.FirstName;
			exist.LastName = user.LastName;
            await unitOfWork.Save();
            return Ok(exist);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("Register")]
	public async Task<IActionResult>Register(User user)
	{
		try
		{
			var result = await validator.ValidateAsync(user);
			if (result.IsValid)
			{
				var exist = await unitOfWork.User.GetFirstOrDefault(item => item.UserName == user.UserName || item.Email == user.Email);
				if (exist != null) return BadRequest("User Already exist");
				await unitOfWork.User.Save(user);
				await unitOfWork.Save();
				return Ok(user);
			}
			return BadRequest(result.Errors);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}