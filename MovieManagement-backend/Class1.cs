using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MovieManagement.API.Controllers

public class DatabaseHealthCheck : IHealthCheck
{
	private readonly IDbConnectionFactory _dbConnectionFactory;

	public DatabaseHealthCheck(IDbConnectionFactory dbConnectionFactory);
	{
	_dbConnectionFactory = dbConnectionFactory;
	}
	public async Task<HealthCheckResult> CheckHealthAsync(
		HealthCheckContext context,
		CancellationToken cancellationToken = new())
	{
		try 
		{
		using var connection = await _dbConnectionFactory.CreateConnect.CreateCommand();
		using var command = connection.CreateCommand();
		command.CommandText = "SELECT 1";
		command.ExecuteScalar();
		return HealthCheckResult.Healthy();

		}catch(Exception exeception)
		{
		return HealthCheckResult.Unhealthy(Exception: exception);
		}
	}
}
