namespace Inventory.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IConfiguration _configuration;

    public UserRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private string ConnectionString
    {
        get
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
    }

    public async Task<int> GetUserId(string loginId, string password)
    {
        int userId = 0;
        string sql = @"SELECT UserID FROM Users WHERE IsActive = 1 AND LoginId=@LoginId AND Password=@Password";

        using (SqlConnection con = new SqlConnection(ConnectionString))
        {
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("LoginId", loginId);
            command.Parameters.AddWithValue("Password", password);

            await con.OpenAsync();

            object obj = await command.ExecuteScalarAsync();
            if (obj != null)
            {
                userId = Convert.ToInt32(obj.ToString());
            }

            await con.CloseAsync();               
        }            

        return userId;
    }

    public async Task<DataTable> GetUserById(int userId)
    {   
        DataTable dataTable = new DataTable();
        string sql = @"SELECT * FROM Users WHERE IsActive = 1 AND UserID=@UserID";

        using (SqlConnection con = new SqlConnection(ConnectionString))
        {
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("UserID", userId);                

            await con.OpenAsync();
            await command.ExecuteNonQueryAsync(); 
            await con.CloseAsync();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dataTable);
        }

        return dataTable;
    }

    public async Task<bool> IsActiveUser(int userId)
    {
        bool isActive = false;
        string sql = @"SELECT COUNT(*) FROM Users WHERE IsActive = 1 AND UserID=@UserID";

        using (SqlConnection con = new SqlConnection(ConnectionString))
        {
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("UserID", userId);                

            await con.OpenAsync();
            isActive = Convert.ToBoolean(await command.ExecuteScalarAsync());                
            await con.CloseAsync();                
        }

        return isActive;
    }        
}
