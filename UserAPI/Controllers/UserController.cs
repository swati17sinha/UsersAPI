using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using UserAPI.Data;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly List<User> users = new List<User>()
        {
            new User(){Name="John", Age=23, Email="john.doe@google.com", UserId=1},
            new User(){Name="John2", Age=22, Email="john.doe2@google.com", UserId=2}
        };

        private UserDbContext _dbContext;
        public UserController(ILogger<UserController> logger, UserDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user= _dbContext.User.Where(u => u.UserId.Equals(id)).SingleOrDefault();
            return user;
        }
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return _dbContext.User.ToList();
        }
    }
}