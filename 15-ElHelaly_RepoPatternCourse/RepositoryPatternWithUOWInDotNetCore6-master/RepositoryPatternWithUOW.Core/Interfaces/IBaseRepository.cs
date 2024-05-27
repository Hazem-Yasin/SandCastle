using RepositoryPatternWithUOW.Core.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.Interfaces
{
    // Generic interface for a repository, where T is a class.
    public interface IBaseRepository<T> where T : class
    {
        // Synchronous method to get an entity by its ID.
        T GetById(int id);

        // Asynchronous method to get an entity by its ID.
        Task<T> GetByIdAsync(int id);

        // Synchronous method to get all entities.
        IEnumerable<T> GetAll();

        // Asynchronous method to get all entities.
        Task<IEnumerable<T>> GetAllAsync();

        // Synchronous method to find a single entity based on criteria.
        // Optionally includes related entities specified by the 'includes' parameter.
        T Find(Expression<Func<T, bool>> criteria, string[] includes = null);

        // Asynchronous method to find a single entity based on criteria.
        // Optionally includes related entities specified by the 'includes' parameter.
        Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null);

        // Synchronous method to find all entities matching the criteria.
        // Optionally includes related entities specified by the 'includes' parameter.
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null);

        // Synchronous method to find all entities matching the criteria with pagination.
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int take, int skip);

        // Synchronous method to find all entities matching the criteria with optional pagination and sorting.
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take, int? skip,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);

        // Asynchronous method to find all entities matching the criteria.
        // Optionally includes related entities specified by the 'includes' parameter.
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null);

        // Asynchronous method to find all entities matching the criteria with pagination.
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int skip, int take);

        // Asynchronous method to find all entities matching the criteria with optional pagination and sorting.
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? skip, int? take,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);

        // Synchronous method to add a new entity.
        T Add(T entity);

        // Asynchronous method to add a new entity.
        Task<T> AddAsync(T entity);

        // Synchronous method to add multiple new entities.
        IEnumerable<T> AddRange(IEnumerable<T> entities);

        // Asynchronous method to add multiple new entities.
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        // Synchronous method to update an existing entity.
        T Update(T entity);

        // Synchronous method to delete an existing entity.
        void Delete(T entity);

        // Synchronous method to delete multiple existing entities.
        void DeleteRange(IEnumerable<T> entities);

        // Synchronous method to attach an entity to the context.
        // Used when the entity is already in the database and you just want to track it.
        void Attach(T entity);

        // Synchronous method to attach multiple entities to the context.
        void AttachRange(IEnumerable<T> entities);

        // Synchronous method to count all entities.
        int Count();

        // Synchronous method to count entities matching the criteria.
        int Count(Expression<Func<T, bool>> criteria);

        // Asynchronous method to count all entities.
        Task<int> CountAsync();

        // Asynchronous method to count entities matching the criteria.
        Task<int> CountAsync(Expression<Func<T, bool>> criteria);
    }
}
