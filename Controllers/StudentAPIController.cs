using ASPNET_WEb_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_WEb_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly AarohiContext context;

        public StudentAPIController(AarohiContext context)
        {
            this.context = context;
        }



        [HttpGet]
        public async Task<ActionResult<List<Registration1>>> GetStudents()
        {
           var data = await context.Registration1s.ToListAsync();
            return Ok(data);
        }


        [HttpGet("{ID}")]
        public async Task<ActionResult<Registration1>> GetStudentById(int ID)
        {
                 var student = await context.Registration1s.FindAsync(ID);
                 if(student == null) {

                return NotFound();
                    }
            return student;

        }



        [HttpPost]
        public async Task<ActionResult<Registration1>> CreateStudent(Registration1 std)
        {
            await context.Registration1s.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);
        }


        [HttpPut("{ID}")]
        public async Task<ActionResult<Registration1>> UpdateStudent(int ID , Registration1 std)
        {
            if (ID != std.Id)
            {
                return BadRequest();

            }
            context.Entry(std).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(std);

        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult<Registration1>> DeleteStudent(int ID)
        {
            var std = await context.Registration1s.FindAsync(ID);
            if(std == null)
            {
                return NotFound();
            }
             context.Registration1s.Remove(std);
            await context.SaveChangesAsync();
            return Ok();
     }



    }
}
