using Microsoft.EntityFrameworkCore;
using P_DotNetCoreApi_BAL.Interfaces;
using P_DotNetCoreApi_BAL.ViewModel;
using P_DotNetCoreApi_DAL.DBContextF;
using P_DotNetCoreApi_DAL.Models;
using P_DotNetCoreApi_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_DotNetCoreApi_BAL.Service
{
    public class TodoMasterServices : ITodoMasterServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TodoMaster> _todoMastersRepository;
        private readonly DBContextFiledb _dbContext;
        public TodoMasterServices(IUnitOfWork unitOfWork, IRepository<TodoMaster> todoMastersRepository, DBContextFiledb dbContext)
        {
            _unitOfWork = unitOfWork;
            _todoMastersRepository = todoMastersRepository;
            _dbContext = dbContext;
        }

        public async Task<int> CreateTodo(AddTodoMasterVM entity)
        {
            var IsTodo = await _dbContext.TodoMasters.Where(x => x.Email == entity.Email).FirstOrDefaultAsync();

            if (IsTodo != null)
            {
                return 1; // duplicate value check return
            }
            else
            {
                TodoMaster todoMaster = new TodoMaster()
                {
                    Name = entity.Name,
                    Email = entity.Email,
                    Number = entity.Number,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                };
                await _todoMastersRepository.AddAsync(todoMaster);
                await _dbContext.SaveChangesAsync();

                return 0; // sucess
            }

        }

        public async Task<int> DeleteTodoById(int TodoId)
        {
            var IsTodo = await _dbContext.TodoMasters.Where(x => x.Id == TodoId).FirstOrDefaultAsync();

            if (IsTodo == null)
            {
                return 1; // not found record
            }
            else
            {
                await _todoMastersRepository.DeleteAsync(TodoId);
                await _dbContext.SaveChangesAsync();
                return 0; // sucess
            }
        }

        public async Task<List<GetTodoMasterVM>> GetAllTodo()
        {
            var result = await (from tm in _dbContext.TodoMasters
                                select new GetTodoMasterVM
                                {
                                    Id = tm.Id,
                                    Name = tm.Name,
                                    Email = tm.Email,
                                    Number = tm.Number,
                                    CreatedDate = tm.CreatedDate,
                                    IsActive = tm.IsActive,
                                    LastModifiedDate = tm.LastModifiedDate,

                                }).AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<GetTodoMasterVM> GetTodoById(int TodoId)
        {
            var result = await (from tm in _dbContext.TodoMasters
                                where tm.Id == TodoId
                                select new GetTodoMasterVM
                                {
                                    Id = tm.Id,
                                    Name = tm.Name,
                                    Email = tm.Email,
                                    Number = tm.Number,
                                    CreatedDate = tm.CreatedDate,
                                    IsActive = tm.IsActive,
                                    LastModifiedDate = tm.LastModifiedDate,

                                }).AsNoTracking().FirstOrDefaultAsync();
            return result;
        }

        public async Task<int> UpdateTodo(EditTodoMasterVM entity)
        {

            var IsTodo = await _dbContext.TodoMasters.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

            if (IsTodo.Email == entity.Email)
            {
                return 2;
            }


            if (IsTodo == null)
            {
                return 1; // not found record
            }
            else
            {

                IsTodo.Name = entity.Name;
                IsTodo.Email = entity.Email;
                IsTodo.Number = entity.Number;
                IsTodo.LastModifiedDate = DateTime.Now;
                await _todoMastersRepository.UpdateAsync(IsTodo);
                await _dbContext.SaveChangesAsync();

                return 0; // sucess
            }
        }
    }
}
