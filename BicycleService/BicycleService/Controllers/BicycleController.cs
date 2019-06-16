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
    [Route("api/v{version:apiVersion}/bicycle")]
    public class BicycleController : Controller
    {
        private readonly BicycleServiceDbContext _context;

        public BicycleController(BicycleServiceDbContext context)
        {
            _context = context;
        }

        [Route("{bicycleId:min(1)}", Name = "GetBicycleById")]
        [HttpGet]
        public async Task<IActionResult> GetBicycleById(int bicycleId)
        {
            var bicycle = await _context.Bicycle.FirstOrDefaultAsync(x => x.BicycleId == bicycleId);

            if (bicycle != null)
            {
                return Ok(new BicycleViewModel
                {
                    BicycleId = bicycle.BicycleId,
                    UserId = bicycle.UserId,
                    ProductionDate = bicycle.ProductionDate,
                    Type = bicycle.Type
                });
            }
            return NotFound();
        }
        [Route("user/{userId:min(1)}", Name = "GetBicyclesByUserId")]
        [HttpGet]
        public async Task<IActionResult> GetBicyclesByUserId(int userId)
        {
            var bicycles = await _context.Bicycle.Where(x => x.UserId == userId).ToListAsync();
            var bicycleViewModels = bicycles.Select(x =>
                new BicycleViewModel
                {
                    BicycleId = x.BicycleId,
                    UserId = x.UserId,
                    ProductionDate = x.ProductionDate,
                    Type = x.Type
                }).ToList();

            if (bicycleViewModels.Count != 0)
            {
                return Ok(new BicycleListViewModel
                {
                    Bicycles = bicycleViewModels
                });
            }
            return NotFound();
        }
        [ValidateModel]
        public async Task<IActionResult> Post([FromBody] CreateBicycle createBicycle)
        {
            var bicycle = new Bicycle
            {
                UserId = createBicycle.UserId,
                ProductionDate = createBicycle.ProductionDate,
                Type = createBicycle.Type
            };
            await _context.AddAsync(bicycle);
            await _context.SaveChangesAsync();

            return Created(bicycle.BicycleId.ToString(), new BicycleViewModel
            {
                UserId = bicycle.UserId,
                ProductionDate = bicycle.ProductionDate,
                Type = bicycle.Type
            });
        }
        [Route("edit/{bicycleId:min(1)}", Name = "EditBicycle")]
        [ValidateModel]
        [HttpPatch]
        public async Task<IActionResult> EditBicycle([FromBody] EditBicycle editBicycle, int bicycleId)
        {
            var bicycle = await _context.Bicycle.FirstOrDefaultAsync(x => x.BicycleId == bicycleId);
            bicycle.UserId = editBicycle.UserId;
            bicycle.ProductionDate = editBicycle.ProductionDate;
            bicycle.Type = editBicycle.Type;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [Route("delete/{bicycleId:min(1)}", Name = "DeleteBicycle")]
        [ValidateModel]
        [HttpDelete]
        public async Task<IActionResult> DeleteBicycle(int bicycleId)
        {
            var bicycle = await _context.Bicycle.FirstOrDefaultAsync(x => x.BicycleId == bicycleId);
            if (bicycle != null)
            {
                _context.Remove(bicycle);
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }
    }
}