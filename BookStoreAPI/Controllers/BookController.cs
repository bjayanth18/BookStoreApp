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

namespace BookStoreAPI.Controllers
{
    [Route("api2/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public BookController(IBookRepository bookRepository, ILoggerService logger, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Fetch all Books in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                _logger.LogInfo("Fetching all books");
                var authors = await _bookRepository.RetrieveAll();
                var response = _mapper.Map<IList<BookDTO>>(authors);
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
        /// Fetch book with a specific ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            try
            {
                _logger.LogInfo($"Fetching book: {id}");
                var book = await _bookRepository.Retrieve(id);
                if (book == null)
                {
                    return Ok("Book not found");
                }
                else
                {
                    var response = _mapper.Map<BookDTO>(book);
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
        /// Creates an Book
        /// </summary>
        /// <param name="bookRequestDto"></param>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookRequestDTO bookRequestDto)
        {
            _logger.LogInfo("Creating Book");
            try
            {
                if (bookRequestDto == null) return BadRequest("Input data is null");
                if (!ModelState.IsValid) return BadRequest("Mandatory fields missing");
                var bookDto = _mapper.Map<BookDTO>(bookRequestDto);
                var result = await _bookRepository.Create(_mapper.Map<Book>(bookDto));

                _logger.LogInfo(result
                    ? $"Author {bookRequestDto.Title} created"
                    : $"Author {bookRequestDto.Title} failed");

                return Created("Created book successfully", new {bookRequestDto});
            }
            catch (Exception ex)
            {
                return BadRequest(
                    $"Exception Occurred: {ex.Message} {Environment.NewLine} {ex.InnerException} {Environment.NewLine}{ex.StackTrace}");
            }
        }
        
        /// <summary>
        /// Put method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("id")]
        public async Task<IActionResult> Put(int id, [FromBody] BookRequestDTO bookRequestDto)
        {
            _logger.LogInfo("Updating Book");
            try
            {
                if (bookRequestDto == null) return BadRequest("Input data is null");
                if (!ModelState.IsValid) return BadRequest("Mandatory fields missing");
                var bookDto = _mapper.Map<BookDTO>(bookRequestDto);
                bookDto.Bookid = id;
                var result = await _bookRepository.Update(_mapper.Map<Book>(bookDto));
                _logger.LogInfo($"Book {bookDto.Title} updated");
                return Ok($"Updated book {bookDto.Title} successfully");
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
                _logger.LogInfo($"Deleting book {id}");
                var book = await _bookRepository.Retrieve(id);
                var result = await _bookRepository.Delete(book);
                _logger.LogInfo("Book deleted");

                return Ok($"Deleted book {book.Title} successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(
                    $"Exception Occurred: {ex.Message} {Environment.NewLine} {ex.InnerException} {Environment.NewLine}{ex.StackTrace}");
            }
        }

    }
}