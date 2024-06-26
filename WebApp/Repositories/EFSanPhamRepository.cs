﻿using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Repositories
{
    public class EFSanPhamRepository : ISanPhamRepository
    {
        private readonly AgriculturalProductsContext _context;

        public EFSanPhamRepository(AgriculturalProductsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SanPham>> GetAllAsync()
        {
            return await _context.SanPhams.ToListAsync();
        }

        public async Task<SanPham> GetByIdAsync(string id)
        {
            return await _context.SanPhams.FindAsync(id);
        }

        public async Task AddAsync(SanPham product)
        {
            _context.SanPhams.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SanPham product)
        {
            _context.SanPhams.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var product = await _context.SanPhams.FindAsync(id);
            _context.SanPhams.Remove(product);
            await _context.SaveChangesAsync();
        }
    }

}
