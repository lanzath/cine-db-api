using System.Data;
using Microsoft.Data.Sqlite;

namespace CineDb.Infrastructure.Database.Dapper;

public interface IDapperContext
{
    IDbConnection GetConnection();
}

public sealed class DapperContext : IDapperContext
{
    private const string _connectionString = "Data Source=../CineDb.Infrastructure.Database/Database.sqlite";

    public DapperContext()
    { }

    public IDbConnection GetConnection()
    {
        return new SqliteConnection(_connectionString);
    }
}