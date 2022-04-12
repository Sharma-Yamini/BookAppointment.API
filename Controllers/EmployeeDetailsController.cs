using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookAppointment.API.Models;

namespace BookAppointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailsController : ControllerBase
    {
        private readonly AppointmentContext _context;

        public EmployeeDetailsController(AppointmentContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeDetails
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<EmployeeDetail>>> GetEmployeeDetails()
        {
            return await _context.EmployeeDetails.ToListAsync();
        }

        // GET: api/EmployeeDetails/5
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<EmployeeDetail>> GetEmployeeDetail(int id)
        {
            var employeeDetail = await _context.EmployeeDetails.FindAsync(id);

            if (employeeDetail == null)
            {
                return NotFound();
            }

            return employeeDetail;
        }

        // PUT: api/EmployeeDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutEmployeeDetail(int id, EmployeeDetail employeeDetail)
        {
            if (id != employeeDetail.EmployeeCode)
            {
                return BadRequest();
            }

            _context.Entry(employeeDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmployeeDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Create")]
        public async Task<ActionResult<EmployeeDetail>> PostEmployeeDetail(EmployeeDetail employeeDetail)
        {
            _context.EmployeeDetails.Add(employeeDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeDetail", new { id = employeeDetail.EmployeeCode }, employeeDetail);
        }

        // DELETE: api/EmployeeDetails/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEmployeeDetail(int id)
        //{
        //    var employeeDetail = await _context.EmployeeDetails.FindAsync(id);
        //    if (employeeDetail == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.EmployeeDetails.Remove(employeeDetail);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool EmployeeDetailExists(int id)
        {
            return _context.EmployeeDetails.Any(e => e.EmployeeCode == id);
        }
    }
}
