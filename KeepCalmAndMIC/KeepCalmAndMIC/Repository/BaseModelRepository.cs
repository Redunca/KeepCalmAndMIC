﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KeepCalmAndMIC.Models;

namespace KeepCalmAndMIC.Repository
{
	public abstract class BaseModelRepository<T> : IRepository<T> where T : class
	{
		protected ApplicationDbContext Context { get; }

		protected BaseModelRepository(ApplicationDbContext context)
		{
			Context = context;
		}

		public virtual async Task<T> Add(T entity)
		{
			return Context.Set<T>().Add(entity);
		}

		public async Task Delete(T entity)
		{
			Context.Set<T>().Remove(entity);
		}

		public virtual async Task<List<T>> GetAllAsync()
		{
			return await Context.Set<T>().ToListAsync();
		}

		public virtual async Task<List<T>> GetAllAsync<TProperty>(Expression<Func<T, TProperty>> includePath)
		{
			return await Context.Set<T>().Include(includePath).ToListAsync();
		}

		public async Task<T> GetById(int id)
		{
			return await Context.Set<T>().FindAsync(id);
		}

		public async Task<List<T>> SearchFor(Expression<Func<T, bool>> predicate)
		{
			return await Context.Set<T>().Where(predicate).ToListAsync();
		}
	}
}