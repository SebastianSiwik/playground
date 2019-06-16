using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BicycleService.Api.BindingModels;
using BicycleService.Api.Validation;
using BicycleService.Api.ViewModels;
using BicycleService.Data.Sql;
using BicycleService.Data.Sql.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BicycleService.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/workshop")]
    public class WorkshopController : Controller
    {
        private readonly BicycleServiceDbContext _context;

        public WorkshopController(BicycleServiceDbContext context)
        {
            _context = context;
        }

        [Route("{workshopId:min(1)}", Name = "GetWorkshopById")]
        [HttpGet]
        public async Task<IActionResult> GetWorkshopById(int workshopId)
        {
            var workshop = await _context.Workshop.FirstOrDefaultAsync(x => x.WorkshopId == workshopId);

            if (workshop != null)
            {
                return Ok(new WorkshopViewModel
                {
                    WorkshopId = workshop.WorkshopId,
                    Address = workshop.Address,
                    EmployeeCount = workshop.EmployeeCount
                });
            }
            return NotFound();
        }
        [ValidateModel]
        public async Task<IActionResult> Post([FromBody] CreateWorkshop createWorkshop)
        {
            var workshop = new Workshop
            {
                Address = createWorkshop.Address,
                EmployeeCount = createWorkshop.EmployeeCount
            };
            await _context.AddAsync(workshop);
            await _context.SaveChangesAsync();

            return Created(workshop.WorkshopId.ToString(), new WorkshopViewModel
            {
                WorkshopId = workshop.WorkshopId,
                Address = workshop.Address,
                EmployeeCount = workshop.EmployeeCount
            });
        }
        [Route("edit/{workshopId:min(1)}", Name = "EditWorkshop")]
        [ValidateModel]
        [HttpPatch]
        public async Task<IActionResult> EditWorkshop([FromBody] EditWorkshop editWorkshop, int workshopId)
        {
            var workshop = await _context.Workshop.FirstOrDefaultAsync(x => x.WorkshopId == workshopId);
            workshop.Address = editWorkshop.Address;
            workshop.EmployeeCount = editWorkshop.EmployeeCount;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [Route("delete/{workshopId:min(1)}", Name = "DeleteWorkshop")]
        [ValidateModel]
        [HttpDelete]
        public async Task<IActionResult> DeleteWorkshop(int workshopId)
        {
            var workshop = await _context.Workshop.FirstOrDefaultAsync(x => x.WorkshopId == workshopId);
            if (workshop != null)
            {
                _context.Remove(workshop);
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }
    }
}