using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P_DotNetCoreApi_BAL.Interfaces;
using P_DotNetCoreApi_BAL.ViewModel;
using P_DotNetCoreApi_DAL.Contract;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace P_DotNetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoMasterController : ControllerBase
    {
        private readonly ITodoMasterServices _todoMasterServices;
        public TodoMasterController(ITodoMasterServices todoMasterServices)
        {
            _todoMasterServices = todoMasterServices;
        }

        [HttpPost]
        [Route("Create-TodoList")]
        public async Task<ActionResult> CreateTodoList([FromBody] AddTodoMasterVM entity)
        {
            try
            {
                var results = await _todoMasterServices.CreateTodo(entity);
                if (results == 0)
                {
                    return Ok(new BaseResponse { Success = true, Message = "Create todo list successfully." });
                }
                return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse { Success = false, Message = "Email id already exists!" });

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetTodo-ById/{TodoId}")]
        public async Task<IActionResult> GetTodoById(int TodoId)
        {
            try
            {
                var results = await _todoMasterServices.GetTodoById(TodoId);
                if (results != null)
                {
                    return Ok(new BaseResponseModel<GetTodoMasterVM> { Success = true, Message = "Data received successfully", Data = results });
                }
                return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse { Success = false, Message = "Record not found!" });

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetAll-TodoList")]
        public async Task<IActionResult> GetAllTodo()
        {
            try
            {
                var results = await _todoMasterServices.GetAllTodo();
                if (results.Any())
                {
                    return Ok(new BaseResponseModel<List<GetTodoMasterVM>> { Success = true, Message = "Data received successfully.", Data = results });
                }
                return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse { Success = false, Message = "Record not found!" });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        [Route("Update-TodoList")]
        public async Task<IActionResult> UpdateTodoList([FromBody] EditTodoMasterVM entity)
        {
            try
            {
                var result = await _todoMasterServices.UpdateTodo(entity);

                if (result == 0)
                {
                    return Ok(new BaseResponse { Success = true, Message = "Update todo list successfully." });
                }
                if (result == 2)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse { Success = false, Message = "Email id already exists!" });
                }
                return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse { Success = false, Message = "Record not found!" });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        [Route("Delete-TodoList/{TodoId}")]
        public async Task<IActionResult> DeleteTodoById(int TodoId)
        {
            try
            {
                var result = await _todoMasterServices.DeleteTodoById(TodoId);

                if (result == 0)
                {
                    return Ok(new BaseResponse { Success = true, Message = "Todo list delete successfully." });
                }
                return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse { Success = false, Message = "Record not found!" });
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
