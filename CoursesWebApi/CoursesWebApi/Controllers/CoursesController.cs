using CoursesWebApi.Models;
using CoursesWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CoursesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private IService<CreateCourseRequest, CourseModel> createCourseService;
        private IService<UpdateCourseRequest, CourseModel> updateCourseService;
        private IService<int, CourseModel> getCourseService;
        private IService<List<CourseModel>> listCourseService;
        private IService<int, bool> deleteCourseService;

        public CoursesController(
            IService<CreateCourseRequest, CourseModel> createCourseService,
            IService<UpdateCourseRequest, CourseModel> updateCourseService,
            IService<int, CourseModel> getCourseService,
            IService<List<CourseModel>> listCourseService,
            IService<int, bool> deleteCourseService)
        {
            this.createCourseService = createCourseService;
            this.updateCourseService = updateCourseService;
            this.getCourseService = getCourseService;
            this.listCourseService = listCourseService;
            this.deleteCourseService = deleteCourseService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCourseRequest request)
        {
            try
            {
                var result = await createCourseService.CallAsync(request);

                return Ok(result);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Problemos su duomenu baze");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Kreiptis i administratoriu");
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateAsync(UpdateCourseRequest request, int id)
        {
            try
            {
                var result = await updateCourseService.CallAsync(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Kreiptis i administratoriu");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            try
            {
                var result = await getCourseService.CallAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Kreiptis i administratoriu");
            }
        }

        [HttpGet("List")]
        public async Task<ActionResult> ListAsync()
        {
            try
            {
                var result = await listCourseService.CallAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Kreiptis i administratoriu");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var result = await deleteCourseService.CallAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Kreiptis i administratoriu");
            }
        }
    }
}
