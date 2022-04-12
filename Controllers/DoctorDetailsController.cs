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
    public class DoctorDetailsController : ControllerBase
    {
        private readonly AppointmentContext _context;

        public DoctorDetailsController(AppointmentContext context)
        {
            _context = context;
        }

        // GET: api/DoctorDetails
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<DoctorDetail>>> GetDoctorDetails()
        {
            return await _context.DoctorDetails.ToListAsync();
        }

        // GET: api/DoctorDetails/5
        [HttpGet("(GetById/{id}")]
        public async Task<ActionResult<DoctorDetail>> GetDoctorDetail(int id)
        {
            var doctorDetail = await _context.DoctorDetails.FindAsync(id);

            if (doctorDetail == null)
            {
                return NotFound();
            }

            return Ok(doctorDetail);
        }
        [HttpGet("GetBySpecialization/{specialization}")]
        public async Task<ActionResult<IEnumerable<DoctorDetail>>> GetBySpecialization(string specialization)
        {
            if (string.IsNullOrWhiteSpace(specialization))
            {
                return BadRequest();
            }
            var doctorDetail = await _context.DoctorDetails.Where(x => x.Specialization.ToLower() == specialization.ToLower()).ToListAsync();
            if(doctorDetail == null)
            {
                return NotFound();
            }
            return Ok(doctorDetail);
        }
        [HttpGet("GetByName/{firstname}")]
        public async Task<ActionResult<IEnumerable<DoctorDetail>>> GetByName(string firstName)
        {
            if(string.IsNullOrWhiteSpace(firstName))
            {
                return BadRequest();
            }
            var doctorDetail = await _context.DoctorDetails.Where(x => x.FirstName.ToLower() == firstName.ToLower()).ToListAsync();
            if (doctorDetail == null)
            {
                return NotFound();
            }
            return Ok(doctorDetail);
        }


// PUT: api/DoctorDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctorDetail(int id, DoctorDetail doctorDetail)
        {
            if (id != doctorDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(doctorDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorDetailExists(id))
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

        // POST: api/DoctorDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DoctorDetail>> PostDoctorDetail(DoctorDetail doctorDetail)
        {
            _context.DoctorDetails.Add(doctorDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctorDetail", new { id = doctorDetail.Id }, doctorDetail);
        }

        // DELETE: api/DoctorDetails/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDoctorDetail(int id)
        //{
        //    var doctorDetail = await _context.DoctorDetails.FindAsync(id);
        //    if (doctorDetail == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.DoctorDetails.Remove(doctorDetail);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool DoctorDetailExists(int id)
        {
            return _context.DoctorDetails.Any(e => e.Id == id);
        }
    }
}
