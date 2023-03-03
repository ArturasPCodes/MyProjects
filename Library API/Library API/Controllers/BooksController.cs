using Azure.Core;
using Library_API.Models;
using Library_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IService<CreateBookRequest, BookModel> createBookService;
        private IService<UpdateBookRequest, BookModel> updateBookService;
        private IService<int, BookModel> getBookService;
        private IService<int, List<BookModel>> listBooksService;
        private IService<int, bool> deleteBookService;

        //Using UpdateBookStatusResponse as I cannot use IService<int, BookModel> as getBookService is using it
        private IService<int, UpdateBookStatusResponse> updateBookStatusService;

        public BooksController(
            IService<CreateBookRequest, BookModel> createBookService,
            IService<int, UpdateBookStatusResponse> updateBookStatusService,
            IService<UpdateBookRequest, BookModel> updateBookService,
            IService<int, BookModel> getBookService,
            IService<int, List<BookModel>> listBooksService,
            IService<int, bool> deleteBookService)
        {
            this.createBookService = createBookService;
            this.updateBookStatusService = updateBookStatusService;
            this.updateBookService = updateBookService;
            this.getBookService = getBookService;
            this.listBooksService = listBooksService;
            this.deleteBookService = deleteBookService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(CreateBookRequest request)
        {
            try
            {
                var result = await createBookService.CallAsync(request);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError , "Failed to create a new book, contact admin");
            }
        }

        [HttpPatch("UpdateBookStatus")]
        public async Task<ActionResult> UpdateBookStatusAsync(int id)
        {
            try
            {
                var result = await updateBookStatusService.CallAsync(id);
                return Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Request is null");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to change book status, contact admin");
            }
        }

        [HttpPatch("UpdateBookData")]
        public async Task<ActionResult> UpdateBookDataAsync(UpdateBookRequest request, int id)
        {
            try
            {
                var result = await updateBookService.CallAsync(request);
                return Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Request is null");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to change book data, contact admin");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOneAsync(int id)
        {
            try
            {
                var result = await getBookService.CallAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retreive data, contact admin");
            }
        }

        [HttpGet("List")]
        public async Task<ActionResult> GetListAsync(int limit)
        {
            try
            {
                var result = await listBooksService.CallAsync(limit);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retreive data, contact admin");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await deleteBookService.CallAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete data, contact admin");
            }
        }
    }
}
