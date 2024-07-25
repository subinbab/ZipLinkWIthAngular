using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Core;
using Microsoft.EntityFrameworkCore;

namespace Ziplink.Infrastructure.EFRepository;

    public class ZipilinkRepository<T> : IZiplinkRepository<T> where T : class
    {
        private readonly ZiplinkDbContext _context;
        readonly DbSet<T> dbSet;
        IEnumerable<T> entities = new List<T>();
    private  IQueryable<T>? query;
        T? entity ;
        private static readonly ILog _logger = LogManager.GetLogger(typeof(ZipilinkRepository<T>));
    public ZipilinkRepository(ZiplinkDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        dbSet = _context.Set<T>();
    }
    public async Task Add(T entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
            }
            catch (Exception ex)
            {
            _logger.Error("log4net:Error in post controller", ex);
            }

        }

        public void  Delete(T entity)
        {
            try
            {
                dbSet.Remove(entity);
            }
            catch (Exception ex)
            {
            _logger.Error("log4net:Error in post controller", ex);
            }

        }

        public async Task<IEnumerable<T>> Get()
        {
            try
            {
                entities = await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
            _logger.Error("log4net:Error in post controller", ex);
            }
            return entities;
        }
        public IQueryable<T> Get(params Expression<Func<T, object>>[] includes)
        {
            try
            {
                IQueryable<T> result = dbSet;
                query = includes.Aggregate(result, (current, includeProperty) => current.Include(includeProperty));
            return query;
        }
            catch (Exception ex)
            {
            _logger.Error("log4net:Error in post controller", ex);
            throw new ArgumentNullException() ;
            }
           
        }

    public async Task<T> GetByIdAsync(int id)
    {
        try
        {
            entity = await dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), $"Entity with id {id} not found.");
            }
        }
        catch (ArgumentNullException ex)
        {
            _logger.Error("Entity not found.", ex);
            throw; // Re-throw the exception to be handled by the calling code
        }
        catch (Exception ex)
        {
            _logger.Error("An error occurred while retrieving the entity.", ex);
            throw; // Re-throw the exception to be handled by the calling code
        }

        return entity;
    }

    public async Task<T> GetById(int id, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                IQueryable<T> result = dbSet;
                query = includes.Aggregate(result, (current, includeProperty) => current.Include(includeProperty));
                /*foreach (var includeProperty in includes)
                {
                    dbSet.Include(includeProperty);
                }*/
                 entity = await dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), $"Entity with id {id} not found.");
            }
            return entity;
            }
            catch (Exception ex)
            {
                _logger.Error("log4net:Error in post controller", ex);
            throw new ArgumentNullException(nameof(entity), $"Entity with id {id} not found.");
            }

        }

        public async Task Save()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.Error("log4net:Error in post controller", ex);
            }

        }

        public void Update(T entity)
        {
            try
            {
                dbSet.Update(entity);
            }
            catch (Exception ex)
            {
                _logger.Error("log4net:Error in post controller", ex);
            }

        }
    }



