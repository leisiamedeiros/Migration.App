using Microsoft.AspNetCore.Mvc;
using Migration.App.Infrastructure.Interfaces;

namespace Migration.App.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MigrationsController : ControllerBase
    {
        private readonly ILogger<MigrationsController> _logger;
        private readonly IMigrationRepository _migrationRepository;

        public MigrationsController(
            ILogger<MigrationsController> logger,
            IMigrationRepository migrationRepository)
        {
            _logger = logger;
            _migrationRepository = migrationRepository;
        }

        /// <summary>
        /// Get migrations list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMigrations()
        {
            var result = await _migrationRepository.GetMigrationsAsync();
            return Ok(result);
        }

    }
}