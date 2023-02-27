using Azure.Core;
using CoursesWebApi.Models;

namespace CoursesWebApi.Services
{
    public interface IService<TRequest, TResponse>
    {
        public Task<TResponse> CallAsync(TRequest request);
    }

    public interface IService<TResponse>
    {
        public Task<TResponse> CallAsync();
    }
}
