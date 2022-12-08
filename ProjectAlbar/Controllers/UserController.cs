using Microsoft.AspNetCore.Mvc;
using ProjectAlbar.BL;
using System.Threading.Tasks;
using ProjectAlbar.Models;
using AutoMapper;
using System.Net.Http;
using System.Net;
using System;


namespace ProjectAlbar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        IUserBL iuserBL;
        public userController(IUserBL iuserBL)
        {
            this.iuserBL = iuserBL;
        }

        // GET: api/<userController>
        [HttpGet("GetUser/{Username}/{password}")]
        public async Task<ActionResult<User>> Get(string username, string password)
        {
            User user = await iuserBL.getUser(username, password);
            if (user == null)
                return NoContent();
            return user;
        }

        [HttpGet("Login/{Username}/{password}")]
        public async Task<ActionResult<User>> Login(string username, string password)
        {
            User user = await iuserBL.getUser(username, password);
            if (user == null)
                return NoContent();
            return user;
        } 
        // POST api/<userController>
        [HttpPost("CreateUser")]
        public async Task<int> Post([FromBody] User value)
        {
            int result= await iuserBL.postUser(value);
            return result;
        }

        // PUT api/<userController>/5
        [HttpPut("UpdateUser/{id}")]
        public async Task<User> Put([FromBody] User value, int id)
        {
            value.LastLogIn = DateTime.Now;
            await iuserBL.putUser(value, id);
            return value;
        }

        // DELETE api/<userController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
