using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nobsDAL;
using nobsViewModels;

namespace nobsTests
{
    public class ViewModelsTests
    {

        [Fact]
        public async Task Task_AddTest()
        {
            TaskViewModel vm;
            vm = new()
            {
                Name = "Info5052",
                Description = "test",
                DueDate = DateTime.UtcNow.AddDays(7),
                isCompleted = false,
            };
            await vm.Add();
            Assert.True(vm.Id > 0);
        }
        [Fact]
        public async Task Student_GetByLastnameTest()
        {
            TaskViewModel vm = new() { Name = "Homwork" };
            await vm.GetByName();
            Assert.True(vm.Id > 0);
        }


        [Fact]
        public async Task Task_UpdateTest()
        {
            TaskViewModel vm = new() { Name = "Homework" };
            await vm.GetByName();
            Console.WriteLine($"Description before update: {vm.Description}");
            Console.WriteLine($"Name: {vm.Name}");
            vm.Description = vm.Description == "Info5052" ? "Info5052 prep" : "Info5052";

            Assert.True(await vm.Update() == 1);
        }

        [Fact]
        public async Task Task_DeleteTest()
        {
            TaskViewModel vm = new() { Name = "Ibrahime" };
            await vm.GetByName();
            Assert.True(await vm.Delete() == 1); 
        }
    }
}
