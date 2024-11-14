using Microsoft.EntityFrameworkCore;
using nobsDAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace nobsViewModels
{
    public class TaskViewModel
    {
        readonly private TaskDAO _taskDAO;

        public int? Id { get; set; }

        public string? Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime? DueDate { get; set; }

        public bool? isCompleted { get; set; }

        public TaskViewModel()
        {
            _taskDAO = new TaskDAO();
        }

        //
        // find a task using name property
        //
        public async Task GetByName()
        {
            try
            {
                PlannerItem task = await _taskDAO.GetByName(Name!);
                Name = task.Name;
                DueDate = task.DueDate;
                isCompleted = task.isCompleted;
                Description = task.Description;
                Id = task.Id;
            }
            catch (NullReferenceException nex)
            {
                Debug.WriteLine(nex.Message);
                Name = "not found";
            }
            catch (Exception ex)
            {
                Name = "not found";
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                MethodBase.GetCurrentMethod()!.Name + " " + ex.Message);
                throw;
            }
        }
        //
        // find a task using ID property
        //
        public async Task GetById()
        {
            try
            {
                PlannerItem task = await _taskDAO.GetById((int)Id!);
                Name = task.Name;
                DueDate = task.DueDate;
                isCompleted = task.isCompleted;
                Description = task.Description;
                Id = task.Id;
            }
            catch (NullReferenceException nex)
            {
                Debug.WriteLine(nex.Message);
                Name = "not found";
            }
            catch (Exception ex)
            {
                Name = "not found";
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                MethodBase.GetCurrentMethod()!.Name + " " + ex.Message);
                throw;
            }
        }

        public async Task GetByIsComplete()
        {
            try
            {
                PlannerItem task = await _taskDAO.GetByIsComplete(isCompleted);
                Name = task.Name;
                DueDate = task.DueDate;
                isCompleted = task.isCompleted;
                Description = task.Description;
                Id = task.Id;
            }
            catch (NullReferenceException nex)
            {
                Debug.WriteLine(nex.Message);
                Name = "not found";
            }
            catch (Exception ex)
            {
                Name = "not found";
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                MethodBase.GetCurrentMethod()!.Name + " " + ex.Message);
                throw;
            }
        }

        public async Task<List<TaskViewModel>> GetAll()
        {
            List<TaskViewModel> allVms = new();
            try
            {
                List<PlannerItem> allTasks = await _taskDAO.GetAll();
                foreach (PlannerItem task in allTasks)
                {
                    TaskViewModel taskVm = new()
                    {
                        Name = task.Name,
                        DueDate = task.DueDate,
                        isCompleted = task.isCompleted,
                        Description = task.Description,
                        Id = task.Id
                    };
                    allVms.Add(taskVm);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                MethodBase.GetCurrentMethod()!.Name + " " + ex.Message);
                throw;
            }
            return allVms;
        }

        public async Task Add()
        {
            Id = -1;
            try
            {
                PlannerItem task = new()
                {
                    Name = Name!,
                    DueDate = DueDate,
                    isCompleted = isCompleted,
                    Description = Description,  
                };
                Id = await _taskDAO.Add(task);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                MethodBase.GetCurrentMethod()!.Name + " " + ex.Message);
                throw;
            }
        }

        public async Task<int> Update()
        {
            int updateStatus;
            try
            {
                PlannerItem task = new()

                {
                    Name = Name!,
                    DueDate = DueDate,
                    isCompleted = isCompleted,
                    Description = Description,
                };
                updateStatus = -1; 
                updateStatus = Convert.ToInt16(await _taskDAO.Update(task)); 
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                MethodBase.GetCurrentMethod()!.Name + " " + ex.Message);
                throw;
            }
            return updateStatus;
        }

        public async Task<int> Delete()
        {
            try
            {
                return await _taskDAO.Delete(Id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                MethodBase.GetCurrentMethod()!.Name + " " + ex.Message);
                throw;
            }
        }


    }
}
