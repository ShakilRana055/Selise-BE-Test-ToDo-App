using Microsoft.AspNetCore.Mvc;
using OnsiteDataAccess;
using ToDoAppDataAccess;
using ToDoAppDomain.Model;

namespace ToDoApp.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDoController: ControllerBase
{
	private readonly IUnitOfWork unitOfWork;

	public ToDoController(IUnitOfWork unitOfWork)
	{
		this.unitOfWork = unitOfWork;
	}

    [HttpGet("GetCompleteUncompleteStatus/{hasDone}")]
    public async Task<IActionResult> GetCompleteUncompleteStatus(bool hasDone)
    {
        try
        {
            var toDos = await unitOfWork.TodoItem.GetCompleteUncompleteStatus(hasDone);
            return Ok(toDos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("MarkToDoItem/{id}/{hasDone}")]
    public async Task<IActionResult> MarkToDoItem(int id, bool hasDone)
    {
        try
        {
            var todo = await unitOfWork.TodoItem.GetFirstOrDefault(item => item.Id == id);
            if (todo == null) return NotFound();
            todo.HasDone = hasDone;
            await unitOfWork.Save();
            return Ok(todo);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetTaskByUserId/{userId}")]
    public async Task<IActionResult> GetTaskByUserId(int userId)
    {
        try
        {
            var toDoItems = await unitOfWork.TodoItem.GetTaskByUserId(userId);
            return Ok(toDoItems);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("AddNew")]
	public async Task<IActionResult> AddNew(ToDoItem toDoItem)
	{
		try
		{
			await unitOfWork.TodoItem.Save(toDoItem);
			await unitOfWork.Save();
			return Ok(toDoItem);
		}
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}