using Domain.DomainClasses;
using Domain.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeightTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightHistoryAPIController : ControllerBase
    {
        private readonly IWeightHistoryService _service;

        public WeightHistoryAPIController(IWeightHistoryService service)
        {
            _service = service;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeightHistory>>> Get()
        {
            var weights = await _service.GetAsync();
            return Ok(weights);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WeightHistory>> Get(int id)
        {
            var weight = await _service.GetAsync(id);
            if (weight == null)
            {
                return NotFound();
            }
            return Ok(weight);
        }

        [HttpPost]
        public async Task<ActionResult<WeightHistory>> Post([FromBody] WeightHistory weight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdWeight = await _service.CreateAsync(weight);
            return CreatedAtAction(nameof(Get), new { id = createdWeight.Id }, createdWeight);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] WeightHistory weight)
        {
            if (id != weight.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedWeight = await _service.UpdateAsync(id, weight);
            if (updatedWeight == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (deleted)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}