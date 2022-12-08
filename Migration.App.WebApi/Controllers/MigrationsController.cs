using FluentMigrator.Runner;
using Microsoft.AspNetCore.Mvc;
using Migration.App.Domain.Models;
using Migration.App.Infrastructure.Interfaces;
using Migration.App.WebApi.Transport;

namespace Migration.App.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MigrationsController : ControllerBase
    {
        private readonly IMigrationRepository _migrationRepository;
        private readonly IServiceProvider _serviceProvider;

        public MigrationsController(
            IMigrationRepository migrationRepository,
            IServiceProvider serviceProvider)
        {
            _migrationRepository = migrationRepository;
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Get list applied migrations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VersionInfo))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
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