using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Interfaces;
using Warehouse.Model;

namespace CeilingCalc.Controllers
{
    /// <summary>
    /// Controller for working with request
    /// </summary>
    [Route("/api/RequestController")]
    [ApiController]
    public class RequestController : Controller
    {

        private IRequestRepository _requestRepository;


        public RequestController(IRequestRepository requstRepositoryr)
        {
            _requestRepository = requstRepositoryr;


        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">Requset retrieved</response>
        ///  <response code="400">Wrong request body</response>
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
           
            var pagedReponse = await _requestRepository.GetAllAsync();
            return Ok(pagedReponse);
        }

        /// <summary>
        /// Returns request by Id
        /// </summary>
        /// <param name="id">Request ID</param>
        /// <returns>Request</returns>
        /// <response code="200">Request retrieved</response>
        /// <response code="404">Request not found</response>
        /// <response code="500">Oops! Can't lookup your Request right now</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Request), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            var request = await _requestRepository.GetAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return Ok(request);
        }

        /// <summary>
        /// Removes request by id
        /// </summary>
        /// <param name="id">Request ID</param>
        /// <returns>Void</returns>
        /// <response code="200">Request removed</response>
        /// <response code="404">Request not found</response>
        /// <response code="500">Oops! Can't remove your Request right now</response>
        /// <response code="401">Non autorise</response>
        [ProducesResponseType(401)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = await _requestRepository.GetAsync(id);

            if (request != null)
            {
                await _requestRepository.Delete(request);
            }
            else return NotFound();
            return Ok("Request deleted!");
        }

        /// <summary>
        /// Making changes to one requst record of a specific ID.
        /// </summary>
        /// <remarks>
        ///     Implementation of the Patch method through the Put method. In order not to change any field of the record, leave it as it is in Example Value
        ///     
        ///Fields requst:
        ///

        /// <param name="id">Requst ID</param>
        /// <param name="dealer"></param>
        /// <response code="200">Requst changed</response>
        /// <response code="400">Something went wrong. Possibly invalid request body.</response>
        /// <response code="404">There is no requst for this id</response>
        /// <response code="500">Something went wrong. Possibly invalid request body.</response>

        [HttpPatch]
        public async Task<ActionResult> Patch(int id, [FromBody] Request request)
        {

            var oldRequest =await _requestRepository.GetAsync(id);

            if (oldRequest == null)
                return NotFound();

                if (request.Material == "string")
                request.Material = oldRequest.Material;
                if (request.Color == "string")
                request.Color = oldRequest.Color;
                if (request.Size == 0)
                request.Size = oldRequest.Size;
                if (request.Count == 0)
                 request.Count = oldRequest.Count; 
                if (request.DateOrder == DateOnly.FromDateTime(DateTime.Now)) ;
                request.DateOrder = oldRequest.DateOrder;
                if (request.ManagerOrder == "string")
                request.ManagerOrder = oldRequest.ManagerOrder;
                if (request.Status == 0)
                request.Status = oldRequest.Status;
                if (request.DateStatus == DateOnly.FromDateTime(DateTime.Now)) ;
                 request.DateStatus = oldRequest.DateStatus;

            await _requestRepository.Patch(oldRequest, request);

                return Ok("Dealer changed!");
            

        }

        /// <summary>
        /// Making changes to one or more requst fields
        /// </summary>
        /// <remarks>
        ///  Request example:
        ///
        ///     [
        ///     {
        ///        "op": "add",
        ///        "path": "FirstName",
        ///        "value": "Barry"
        ///     }
        ///     ]
        ///
        /// This example changes the value of the FirstName field of the selected dealer by id to "Barry"
        /// 
        ///     See more: https://learn.microsoft.com/ru-ru/aspnet/core/web-api/jsonpatch?view=aspnetcore-7.0#path-syntax
        ///     
        /// Properties can take Request field values:
        /// 

        ///     
        /// </remarks>
        /// <param name="id">Request ID</param>
        /// <param name="patchDoc"></param>
        /// <response code="200">Request changed</response>
        /// <response code="400">Something went wrong. Possibly invalid request body.</response>
        /// <response code="404">There is no request for this id</response>
        /// <response code="500">Something went wrong. Possibly invalid request body.</response>
        [HttpPatch("PatchJson")]
        public async Task<IActionResult> JsonPatchWithModelState(int id,
        [FromBody] JsonPatchDocument<Request> patchDoc)
        {
            if (patchDoc != null)
            {
                var request =await _requestRepository.GetAsync(id);
                patchDoc.ApplyTo(request);

                    await _requestRepository.JsonPatchWithModelState();
                    return new ObjectResult(request);


            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Create new request
        /// </summary>
        /// <param name="request">All fields of the request, except id. ID is generated automatically, leave 0.</param>
        /// <returns>New request</returns>
        /// <response code="200">Request created</response>
        /// <response code="400">Something went wrong. Possibly invalid request body.</response>
        /// <response code="500">Something went wrong.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] Request request)
        {


                await _requestRepository.Post(request);
                return Ok("Request created!");

        }

        /// <summary>
        /// Making changes to one request record of a specific ID
        /// </summary>
        /// <remarks>
        /// 
        ///  Warning! Unfilled fields will be assigned a default value, as in the scheme
        /// 
        /// Properties can take Request field values:
        /// 

        ///     
        /// </remarks>
        /// <param name="id">Request ID</param>
        /// <param name="request"></param>
        /// <response code="200">Request changed</response>
        /// <response code="400">Something went wrong. Possibly invalid request body.</response>
        /// <response code="404">There is no request for this id</response>
        /// <response code="500">Something went wrong. Possibly invalid request body.</response>


        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] Request request)
        {

            var oldRequest = await _requestRepository.GetAsync(id);

            if (oldRequest != null)
            {
                


                    await _requestRepository.Put(oldRequest, request);
                    return Ok("Request changed!");

            }
            else return NotFound();
            
        }
    }
}
