﻿using HR_LeaveManagement.Application.Contracts.Persistence;
using HR_LeaveManagement.Domain.Common;
using HR_LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_LeaveManagement.Persistence.Reposotories {
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity<int> {

        protected readonly HrDatabaseContext _context;

        public GenericRepository(HrDatabaseContext context) {
            _context = context;
        }
        
        public async Task CreateAsync(T entity) {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity) {
            _context.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity) {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync() {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id) {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}