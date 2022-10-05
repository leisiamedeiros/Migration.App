using FluentMigrator.Runner;
using Microsoft.AspNetCore.Mvc;
using Migration.App.Creator.Extensions;
using Migration.App.Creator.Models;
using Migration.App.Infrastructure.Interfaces;
using Migration.App.WebApi.Filters;

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
        public async Task<IActionResult> GetMigrations()
        {
            var result = await _migrationRepository.GetMigrationsAppliedAsync();
            return Ok(result);
        }

        /// <summary>
        /// Create a migration class inside our infrastructure project
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [LocalOnly]
        [HttpPost("file/local")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateMigration(string fileName)
        {
            FileHandler.CreateMigrationClassFile(fileName);
            return StatusCode(StatusCodes.Status201Created);
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