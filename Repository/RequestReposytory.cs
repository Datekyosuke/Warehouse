using Microsoft.EntityFrameworkCore;
using Warehouse.AplicationContext;
using Warehouse.Interfaces;
using Warehouse.Model;

namespace Warehouse.Repository
{
    public class RequestReposytory : IRequestRepository
    {
        private readonly ApplicationContext _context;

        public RequestReposytory(ApplicationContext context)
        {
            _context = context;
        }


        public async Task Delete(Request request)
        {
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
        }


        public async Task<Request> GetAsync(int id)
        {
            var request = await _context.Requests.FirstOrDefaultAsync(p => p.Id == id);
            return request;
        }

        public async Task JsonPatchWithModelState()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Post(Request request)
        {
            _context.Add(request);
            await _context.SaveChangesAsync();
        }

        public async Task Put(Request oldRequest, Request request)
        {
            _context.Entry(oldRequest).CurrentValues.SetValues(request);
            await _context.SaveChangesAsync();
        }

        public async Task Patch(Request oldRequest, Request request)
        {
            _context.Entry(oldRequest).CurrentValues.SetValues(request);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Request>> GetAllAsync()
        {
            var listRequest = _context.Requests.Select(x=>x).ToList();
            return listRequest;
            //var totalRecords = 0;
            //var firstChar = propertyCamelCase[0].ToString().ToUpper();
            //var property = firstChar + propertyCamelCase.Substring(1);
            //var sortDealers =
            //            sort == "asc" ?
            //            _context.Dealers
            //            .Select(x => x)
            //            .OrderBy(x => EF.Property<object>(x, property)) :

            //            sort == "desc" ?
            //            _context.Dealers
            //           .Select(x => x)
            //           .OrderByDescending(x => EF.Property<object>(x, property)) :

            //            _context.Dealers
            //            .Select(x => x);



            //if (searchString is not null)
            //{
            //    string[] propertySearch = { "LastName", "FirstName", "City", "Telephone" };
            //    var matches = SearchHelper.Search(sortDealers.ToList(), searchString, propertySearch);
            //    totalRecords = matches.Distinct().Count();


            //    var sortedSearchEntities = matches
            //            .Where(x => x.Debts >= ranges.Min && x.Debts <= ranges.Max)
            //            .Distinct()
            //            .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
            //            .Take(validFilter.PageSize)
            //            .ToList();
            //    return PaginationHelper.CreatePagedReponse<Dealer>(sortedSearchEntities, validFilter, totalRecords, _uriService);
            //}
            //totalRecords = sortDealers.Count();
            //var sortedEntities = sortDealers
            //           .Where(x => x.Debts >= ranges.Min && x.Debts <= ranges.Max)
            //           .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
            //           .Take(validFilter.PageSize)
            //           .ToList();
            //return PaginationHelper.CreatePagedReponse<Dealer>(sortedEntities, validFilter, totalRecords, _uriService);


        }

    }
}
