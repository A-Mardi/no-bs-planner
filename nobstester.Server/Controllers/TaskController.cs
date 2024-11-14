using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nobsViewModels;
using System.Diagnostics;
using System.Reflection;

namespace nobstester.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                TaskViewModel viewmodel = new() { Name = name };
                await viewmodel.GetByName();
                return Ok(viewmodel);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                MethodBase.GetCurrentMethod()!.Name + " " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<TaskViewModel> allTasksVm;
                TaskViewModel vm = new();
                allTasksVm = await vm.GetAll();
                return Ok(allTasksVm);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " + MethodBase.GetCurrentMethod()!.Name + " " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("status/{isComplete}")]
        public async Task<IActionResult> GetByIsComplete(bool isComplete)
        {
            try
            {
                TaskViewModel viewmodel = new() { isCompleted = isComplete };
                await viewmodel.GetByIsComplete();
                return Ok(viewmodel);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                MethodBase.GetCurrentMethod()!.Name + " " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TaskViewModel taskViewModel)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            try
            {

                await taskViewModel.Add();
                if (taskViewModel.Id > 0)
                {
                    return Ok(taskViewModel);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Task could not be added.");
                }
            }
            catch (Exception ex){
                Debug.WriteLine("Problem in " + GetType().Name + " " + MethodBase.GetCurrentMethod()!.Name + " " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TaskViewModel taskViewModel)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState); 
            }

            try{
                taskViewModel.Id = id;
                int result = await taskViewModel.Update();

                if (result == 1){
                    return Ok(taskViewModel); 
                }
                else if (result == 0){
                    return NotFound("Task not found or no data was updated.");
                }
                else{
                    return StatusCode(StatusCodes.Status500InternalServerError, "Task could not be updated.");
                }
            }
            catch (Exception ex){
                Debug.WriteLine("Problem in " + GetType().Name + " " + MethodBase.GetCurrentMethod()!.Name + " " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);    
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                TaskViewModel viewmodel = new() { Id = id };

                int result = await viewmodel.Delete();

                if (result == 1){
                    return Ok($"Task with Id {id} deleted successfully.");
                }
                else if (result == 0){
                    return NotFound("Task not found.");
                }
                else{
                    return StatusCode(StatusCodes.Status500InternalServerError, "Task could not be deleted.");
                }
            }
            catch (Exception ex){
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                MethodBase.GetCurrentMethod()!.Name + " " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError); 
            }
        }




    }
}
