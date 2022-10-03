using FluentMigrator.Runner;
using Microsoft.AspNetCore.Mvc;
using Migration.App.Creator.Models;
using Migration.App.Infrastructure.Interfaces;

namespace Migration.App.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MigrationsController : ControllerBase
    {
        private readonly ILogger<MigrationsController> _logger;
        private readonly IMigrationRepository _migrationRepository;
        private readonly IServiceProvider _serviceProvider;

        public MigrationsController(
            ILogger<MigrationsController> logger,
            IMigrationRepository migrationRepository,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _migrationRepository = migrationRepository;
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Get list applied migrations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VersionInfo))]
        public async Task<IActionResult> GetMigrations()
        {
            var result = await _migrationRepository.GetMigrationsAppliedAsync();
            return Ok(result);
        }

        /// <summary>
        /// Run migrations
        /// </summary>
        /// <returns></returns>
        [HttpPost("execute")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult RunMigrations()
        {
            // Instantiate the runner
            var runner = _serviceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            runner.MigrateUp();

            return StatusCode(StatusCodes.Status202Accepted);
        }
    }
}