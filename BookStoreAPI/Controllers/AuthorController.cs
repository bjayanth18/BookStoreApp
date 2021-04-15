using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookStoreAPI.Contracts;
using BookStoreAPI.Data;
using BookStoreAPI.DTO;
using BookStoreAPI.RequestDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace BookStoreAPI.Controllers
{
    /// <summary>
    /// API to perform CRUD operations on Authors
    /// </summary>
    [Route("api2/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class AuthorController : ControllerBase
    {
        private readonly ILoggerService _logger;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService authorService, ILoggerService logger, IMapper mapper)
        {
            _logger = logger;
            _authorService = authorService;
            _mapper = mapper;
        }

        /// <summary>
        /// Fetch all Authors in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            try
            {
                _logger.LogInfo("Fetching all authors");
                var authors = await _authorService.RetrieveAll();
                var response = _mapper.Map<IList<AuthorDTO>>(authors);
                _logger.LogInfo("Fetch complete");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    $"Custom exception occured: {ex.Message + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.StackTrace}");
            }
        }

        /// <summary>
        /// Fetch author with a specific ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            try
            {
                _logger.LogInfo($"Fetching author: {id}");
                var author = await _authorService.Retrieve(id);
                if (author == null)
                {
                    return Ok("Author not found");
                }
                else
                {
                    var response = _mapper.Map<AuthorDTO>(author);
                    _logger.LogInfo("Fetch complete");
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    $"Custom exception occured: {ex.Message + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.StackTrace}");
            }
        }

        /// <summary>
        /// Put method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("id")]
        public async Task<IActionResult> Put(int id, [FromBody] AuthorRequestDto authReqDto)
        {
            _logger.LogInfo("Updating Author");
            try
            {
                if (authReqDto == null) return BadRequest("Input data is null");
                if (!ModelState.IsValid) return BadRequest("Mandatory fields First Name, Last Name missing");
                var authDto = _mapper.Map<AuthorDTO>(authReqDto);
                authDto.Id = id;
                var result = await _authorService.Update(_mapper.Map<Author>(authDto));
                _logger.LogInfo($"Author {authDto.FirstName} updated");
                return Ok($"Updated author {authDto.FirstName} {authDto.LastName} successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Delete me not!
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInfo($"Deleting author {id}");
                Author auth = await _authorService.Retrieve(id);
                var result = await _authorService.Delete(auth);
                _logger.LogInfo("Author deleted");

                return Ok($"Deleted author {auth.FirstName} {auth.LastName} successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(
                    $"Exception Occurred: {ex.Message} {Environment.NewLine} {ex.InnerException} {Environment.NewLine}{ex.StackTrace}");
            }
        }

        /// <summary>
        /// Creates an Author
        /// </summary>
        /// <param name="authReqDto"></param>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AuthorRequestDto authReqDto)
        {
            _logger.LogInfo("Creating Author");
            try
            {
                if (authReqDto == null) return BadRequest("Input data is null");
                if (!ModelState.IsValid) return BadRequest("Mandatory fields First Name, Last Name missing");
                var authDto = _mapper.Map<AuthorDTO>(authReqDto);
                var result = await _authorService.Create(_mapper.Map<Author>(authDto));

                _logger.LogInfo(result
                    ? $"Author {authReqDto.FirstName} created"
                    : $"Author {authReqDto.FirstName} failed");

                return Created("Created author successfully", new {authReqDto});
            }
            catch (Exception ex)
            {
                return BadRequest(
                    $"Exception Occurred: {ex.Message} {Environment.NewLine} {ex.InnerException} {Environment.NewLine}{ex.StackTrace}");
            }
        }
    }
}