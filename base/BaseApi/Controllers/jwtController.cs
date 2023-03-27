using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class jwtController : ControllerBase
    {
        private readonly IJWTService jwtService;

        public jwtController(IJWTService jwtService)
        {
            this.jwtService = jwtService;
        }

        // GET: api/<jwtController>
        [HttpGet]
        public string Get()
        {
            var res = jwtService.Generrate(new Model.User() { age=12,id=21122112,address="no addres",name="kannai",role=true});
            return res ;
        }
    }
}
