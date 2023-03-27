using BaseApi.Dtos;
using BaseApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PersonManagerController : ControllerBase
    {
        mycontext _c;
        public PersonManagerController(mycontext mycontext)
        {

            _c = mycontext;
        }
            
        // GET: api/<PersonManagerController>
        [Authorize]
        [HttpGet("Getall")]
        public IEnumerable<User> Get()
        {
            return _c.UserT;
        }

        // GET api/<PersonManagerController>/5
        [Authorize]
        [HttpGet("{id}")]
        public User Get(long id)
        {
            if(id==0)return null;
            var item=_c.UserT.FirstOrDefault(x => x.id==id);  
            return item;
        }

        // POST api/<PersonManagerController>
        [HttpPost]
        [Authorize]
        public IEnumerable<User> Post([FromBody] UserCerateDto USerotp)
        {
            if(USerotp ==null) return null ;
          
            User u=new User() { address= USerotp.address,
            age=USerotp.age,name= USerotp.name,role=true};
            _c.UserT.Add(u);
            _c.SaveChanges();
            return  _c.UserT.ToList();
        }

        // PUT api/<PersonManagerController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{

        //}

        //// DELETE api/<PersonManagerController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
