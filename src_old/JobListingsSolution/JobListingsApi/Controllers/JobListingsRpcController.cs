using JobListingsApi.Adapters;
using JobListingsApi.Models;
using Microsoft.AspNetCore.Mvc;

 namespace JobListingsApi.Controllers;

[ApiController]
public class JobListingsRpcController : ControllerBase
{

    private readonly JobsApiHttpAdapter _adapter;

    public JobListingsRpcController(JobsApiHttpAdapter adapter)
    {
        _adapter = adapter;
    }

    [HttpPost("job-listings-rpc/{job}/openings")]
    public async Task<ActionResult> AddJobListing([FromRoute] string job, [FromBody] JobListingCreateModel request)

    {
        var jobExists = await _adapter.JobExistsAsync(job);
        if (jobExists)
        {
            return Ok("That Job Exists");
        } else
        {
            return NotFound("No Job with that title exists");
        }
    }
}



