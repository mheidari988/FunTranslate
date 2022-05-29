using Dapper;
using FunTranslate.Application;
using FunTranslate.Application.Contracts.Persistence.Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FunTranslate.Persistence.Dapper;
public class DapperSqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _configuration;

    public DapperSqlDataAccess(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }
    public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters)
    {
        using IDbConnection connection = new SqlConnection(_configuration
            .GetConnectionString(ApplicationConsts.ConnectionStrings.FunTranslateDbConnectionString));
        return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(string storedProcedure, T parameters)
    {
        using IDbConnection connection = new SqlConnection(_configuration
            .GetConnectionString(ApplicationConsts.ConnectionStrings.FunTranslateDbConnectionString));
        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}
