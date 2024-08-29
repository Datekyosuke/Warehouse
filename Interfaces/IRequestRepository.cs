using Warehouse.Model;

namespace Warehouse.Interfaces
{
    public interface IRequestRepository
    {
        public Task<Request> GetAsync(int id);
        public Task Delete(Request request);
        public Task Put(Request oldRequest, Request request);
        public Task JsonPatchWithModelState();
        public Task Post(Request request);

        public Task Patch(Request oldRequest, Request request);

        public Task<List<Request>> GetAllAsync();
    }
}