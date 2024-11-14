using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace nobsDAL
{
    public class TaskDAO
    {
        public async Task<List<PlannerItem>> GetAll()
        {
            List<PlannerItem> allTasks;
            try
            {
                NobsTaskerContext _db = new();
                allTasks = await _db.PlannerItems.ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                MethodBase.GetCurrentMethod()!.Name + " " + ex.Message);
                throw;
            }
            return allTasks;
        }
        public async Task<PlannerItem> GetById(int id)
        {
            PlannerItem? selectedTask;
            try
            {
                NobsTaskerContext _db = new();
                selectedTask = await _db.PlannerItems.FirstOrDefaultAsync(task => task.Id ==
               id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                MethodBase.GetCurrentMethod()!.Name + " " + ex.Message);
                throw;
            }
            return selectedTask!;
        }
        public async Task<PlannerItem> GetByName(string name)
        {
            PlannerItem? selectedTasks;
            try
            {
                NobsTaskerContext _db = new();
                selectedTasks = await _db.PlannerItems.FirstOrDefaultAsync(task => task.Name ==
               name);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                MethodBase.GetCurrentMethod()!.Name + " " + ex.Message);
                throw;
            }
            return selectedTasks!;
        }

        public async Task<PlannerItem> GetByDueDate(DateTime dueDate)
        {
            PlannerItem? selectedTasks;
            try
            {
                NobsTaskerContext _db = new();
                selectedTasks = await _db.PlannerItems.FirstOrDefaultAsync(task => task.DueDate ==
               dueDate);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                MethodBase.GetCurrentMethod()!.Name + " " + ex.Message);
                throw;
            }
            return selectedTasks!;
        }

        public async Task<PlannerItem> GetByIsComplete(bool? isComplete)
        {
            PlannerItem? selectedTask;
            try
            {
                NobsTaskerContext _db = new();
                selectedTask = await _db.PlannerItems.FirstOrDefaultAsync(task => task.isCompleted ==
               isComplete);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                MethodBase.GetCurrentMethod()!.Name + " " + ex.Message);
                throw;
            }
            return selectedTask!;
        }

        public async Task<int> Add(PlannerItem newTask)
        {
            try
            {
                NobsTaskerContext _db = new();
                await _db.PlannerItems.AddAsync(newTask);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                MethodBase.GetCurrentMethod()!.Name + " " + ex.Message);
                throw;
            }
            return newTask.Id;
        }

        public async Task<int> Update(PlannerItem updatedTask)
        {
            int taskUpdated = -1;
            try
            {
                using (NobsTaskerContext _db = new())
                {
                    PlannerItem? currentTask = await _db.PlannerItems.FirstOrDefaultAsync(task => task.Id == updatedTask.Id);
                    if (currentTask == null)
                    {
                        return 0; 
                    }

                    // Update the currentTask with the values from updatedTask
                    _db.Entry(currentTask).CurrentValues.SetValues(updatedTask);
                    taskUpdated = await _db.SaveChangesAsync(); 
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                MethodBase.GetCurrentMethod()!.Name + " " + ex.Message);
                throw;
            }
            return taskUpdated;
        }


        public async Task<int> Delete(int? id)
        {
            int tasksDeleted = -1;
            try
            {
                NobsTaskerContext _db = new();
                PlannerItem? selectedTask = await _db.PlannerItems.FirstOrDefaultAsync(stu => stu.Id == id);
                _db.PlannerItems.Remove(selectedTask!);
                tasksDeleted = await _db.SaveChangesAsync(); // returns # of rows removed
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem in " + GetType().Name + " " +
                MethodBase.GetCurrentMethod()!.Name + " " + ex.Message);
                throw;
            }
            return tasksDeleted;
        }


    }
}
