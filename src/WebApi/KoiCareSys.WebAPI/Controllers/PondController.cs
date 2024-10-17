using KoiCareSys.Data.DTO;
using KoiCareSys.Data.Models;
using KoiCareSys.Serivice.Base;
using KoiCareSys.Service.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace KoiCareSys.WebAPI.Controllers
{
    [Route("odata/Ponds")]
    [ApiController]
    public class PondController : ODataController
    {
        private readonly IPondService _pondService;

        public PondController(IPondService pondService)
        {
            _pondService = pondService;
        }

        [EnableQuery]
        [HttpGet]
        public async Task<IActionResult> GetODataAll()
        {
            var result = await _pondService.GetODataAll();
            return Ok(result);
        }

        //[EnableQuery]
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Pond>>> GetPonds([FromQuery] string? search)
        //{
        //    try
        //    {
        //        var result = await _pondService.GetAll(search);
        //        if (result.Status > 0)
        //        {
        //            return Ok(result.Data as IEnumerable<Pond>);
        //        }
        //        else { return NotFound(result.Message); }
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        //[HttpGet("{id}")]
        //public async Task<IBusinessResult> GetById(Guid id)
        //{
        //    return await _pondService.GetById(id);
        //}

        [EnableQuery]
        [HttpGet("{id}")]
        public async Task<ActionResult<Pond>> GetPondById(Guid id)
        {
            try
            {
                var result = await _pondService.GetById(id);
                if (result.Status > 0)
                {
                    return Ok(result.Data as Pond);
                }
                else { return NotFound(result.Message); }
            }
            catch
            {
                return BadRequest();
            }
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IBusinessResult> Update([FromBody] PondDTO request)
        {
            return await _pondService.Update(request);
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IBusinessResult> Create([FromBody] PondDTO request)
        {
            return await _pondService.Create(request);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IBusinessResult> Delete(Guid id)
        {
            return await _pondService.DeleteById(id);
        }
    }
}
