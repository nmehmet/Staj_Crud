using Proje.EntityFramework.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Proje.EntityFramework.Data;
using AutoMapper;
using Microsoft.AspNetCore.Routing.Template;


namespace Proje.Services.Repositories
{
    public class BaseRepository<TRequest , TResponse , Entity> : IBaseRepository<TRequest , TResponse> where TRequest : class
                                                                                                 where TResponse : class
                                                                                                 where Entity : class
    {
        private readonly DataContext _context;
        private readonly DbSet<Entity> _dbset;
        private readonly IMapper _mapper;
        public BaseRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _dbset = _context.Set<Entity>();
            _mapper = mapper;
        }
        public virtual async Task<List<TResponse>> GetAll()
        {
            
            var items = await _dbset.ToListAsync();
            return _mapper.Map<List<TResponse>>(items);
        }
        public async Task<TResponse> GetById(int id)
        {
            var item = await _dbset.FindAsync(id);
            if (item != null)
            {
                _context.Entry(item).State = EntityState.Detached;
                return _mapper.Map<TResponse>(item);
            }
            throw new Exception("Aranan Girdi Bulunamadı...");
            
        }
        public virtual async Task<TResponse> Add(TRequest entity)
        {
            Entity item = _mapper.Map<Entity>(entity);
            await _dbset.AddAsync(item);
            await Save();
            return _mapper.Map<TResponse>(item);
        }
        public async Task<TResponse> UpdateById(TRequest entity , int id )
        {
            Entity item =_mapper.Map<Entity>(await GetById(id));
            if(item != null)
            {
                _mapper.Map(entity,item);
                _dbset.Update(item);
                await Save();
                return _mapper.Map<TResponse>(item);
            }
            throw new Exception("Aranan girdi bulunamadı...");
        }
        public async Task<TResponse> Delete(int id)
        {
            var olditem = await GetById(id);
            var item = _dbset.Remove(_mapper.Map<Entity>(await _dbset.FindAsync(id)));
            await Save();
            return olditem;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
