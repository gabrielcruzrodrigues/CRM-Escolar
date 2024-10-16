using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_Escolar.Data;
using CRM_Escolar.Domains;
using CRM_Escolar.Repository.Interfaces;
using CRM_Escolar.ViewModels;
using Microsoft.EntityFrameworkCore;
using CRM_Escolar.Extensions;

namespace CRM_Escolar.Repository
{
    public class IllnessRepository : IIllnessRepository
    {
        private readonly MyAppContext _context;
        private readonly ILogger<IllnessRepository> _logger;

        public IllnessRepository(MyAppContext context, ILogger<IllnessRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Illness>> GetAll()
        {
            return await _context.Illnesses
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<Illness> GetById(int illnessId)
        {
            var Illness = await _context.Illnesses
                    .AsNoTracking()
                    .FirstOrDefaultAsync(i => i.Id.Equals(illnessId));

            if (Illness is null)
            {
                throw new HttpResponseException(404, $"The illness with id {illnessId} not found");
            }

            return Illness;
        }

        public async Task<Illness> Create(CreateIllnessViewModel createIllnessViewModel)
        {
            Illness illness = createIllnessViewModel.CreateIlless();
            try
            {
                await _context.Illnesses.AddAsync(illness);
                await _context.SaveChangesAsync();
                return illness;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Un error occurred when tryning create a new Illness! - err: {ex.Message}");
                throw new HttpResponseException(400, "Un error occurred when tryning create a new Illness");
            }
        }
    }
}