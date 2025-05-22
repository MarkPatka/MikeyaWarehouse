namespace MikeyaWarehouse.Infrastructure.Persistence.Configurations;

public record DatabaseSettings
{
    public string DB_HOST { get; init; } = "localhost";
    public int DB_PORT { get; init; } = 5432;
    public string DB_NAME { get; init; } = "DbName";
    public string DB_USER { get; init; } = "DbUser";
    public string DB_PASSWORD { get; init; } = "DbPassword";
        
    public string ConnectionString =>
        $"Host={DB_HOST};" +
        $"Port={DB_PORT};" +
        $"Database={DB_NAME};" +
        $"Username={DB_USER};" +
        $"Password={DB_PASSWORD}";
}
