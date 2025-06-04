namespace MikeyaWarehouse.Infrastructure.Persistence.Configurations;

public record DatabaseSettings
{
    public string DB_HOST     { get; set; } = "localhost";
    public int DB_PORT        { get; set; } = 5432;
    public string DB_NAME     { get; set; } = "DbName";
    public string DB_USER     { get; set; } = "DbUser";
    public string DB_PASSWORD { get; set; } = "DbPassword";
        
    public string ConnectionString =>
        $"Host={DB_HOST};" +
        $"Port={DB_PORT};" +
        $"Database={DB_NAME};" +
        $"Username={DB_USER};" +
        $"Password={DB_PASSWORD}";

    public static DatabaseSettings Create(
        string host,
        int port,
        string name,
        string user,
        string password)
    {
        return new DatabaseSettings
        {
            DB_HOST = host,
            DB_PORT = port,
            DB_NAME = name,
            DB_USER = user,
            DB_PASSWORD = password
        };
    }
}
