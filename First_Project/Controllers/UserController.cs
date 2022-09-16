using First_Project.Data;
using First_Project.Model;
using Microsoft.AspNetCore.Mvc;

namespace First_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase  
    {
        private readonly UserDbContext _db;

        public UserController(UserDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetUser()
        {
            var val = _db.Users.ToList();
            return Ok(val);
        }
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetUserById")]
        public IActionResult GetUserById([FromRoute] Guid id)
        {
            var val = _db.Users.FirstOrDefault(x => x.Id == id);
            if (val == null)
            {
                return NotFound("Id is not found");

            }
            return Ok(val);
        }
        [HttpPost]
        public IActionResult AddUser([FromBody] User obj )
        {
            obj.Id = Guid.NewGuid();
             _db.Users.Add(obj);
            _db.SaveChanges();
            return CreatedAtAction(nameof(GetUserById), new {id=obj.Id}, obj);
       
        }
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult Updateuser([FromRoute] Guid id, [FromBody] User obj)
        {
            var val = _db.Users.FirstOrDefault(x => x.Id == id);
            if(val!= null)
            {
                val.PhoneNumber = obj.PhoneNumber;
                val.Name = obj.Name;
                val.Speed = obj.Speed;
                _db.SaveChanges();
                return Ok(val);
            }
            return NotFound("User is not present");



        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            var val=_db.Users.FirstOrDefault(x => x.Id == id);
            if(val!=null)
            {
                _db.Remove(val);
                _db.SaveChanges();
            }
            return NotFound("Not present");
        }




    }
}
