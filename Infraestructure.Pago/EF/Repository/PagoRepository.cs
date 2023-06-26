using Domain.Pagos.Model.Pago;
using Domain.Pagos.Repositories;
using Infraestructure.Pagos.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Pagos.EF.Repository
{
    internal class PagoRepository : IPagoRepository
    {
        private readonly WriteDbContext _context;

        public PagoRepository(WriteDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Pago obj)
        {
            await _context.Pagos.AddAsync(obj);
        }

        public async Task<Pago?> FindByIdAsync(Guid id)
        {
            return await _context.Pagos.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task UpdateAsync(Pago pago)
        {
            _context.Pagos.Update(pago);
            return Task.CompletedTask;
        }
    }
}
