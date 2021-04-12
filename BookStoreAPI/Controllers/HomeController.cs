using System.Collections;
using System.Collections.Generic;
using BookStoreAPI.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    /// <summary>
    /// This is my first API controller
    /// </summary>
    [Route("api2/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILoggerService _logger;

        public HomeController(ILoggerService logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// I struggled with this function for 2 days!
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInfo("Accessed Home Controller");
            return new string[] {"value 1", "value 2"};
        }

        /// <summary>
        /// Simple stuff this, i understand you!
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            _logger.LogDebug("you called Get: " + id);
            return id.ToString();
        }

        /// <summary>
        /// Put method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            _logger.LogWarn("Put is not implemented yet");
        }

        /// <summary>
        /// Delete me not!
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logger.LogWarn("Nothing to delete");
        }

        /// <summary>
        /// Poster boy Kohli!
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _logger.LogWarn("Post is not implemented yet");
        }
    }
}