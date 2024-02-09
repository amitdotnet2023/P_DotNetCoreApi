using P_DotNetCoreApi_BAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_DotNetCoreApi_BAL.Interfaces
{
    public interface ITodoMasterServices
    {
        Task<int> CreateTodo(AddTodoMasterVM entity);
        Task<GetTodoMasterVM> GetTodoById(int TodoId);
        Task<List<GetTodoMasterVM>> GetAllTodo();
        Task<int> UpdateTodo(EditTodoMasterVM entity);
        Task<int> DeleteTodoById(int TodoId);

    }
}
