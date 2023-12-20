namespace Inventory.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int> GetUserId(string loginId, string password)
    {
        return await _userRepository.GetUserId(loginId, password);
    }

    public async Task<UserForListDto> GetUserById(int userId)
    {
        var userDt = await _userRepository.GetUserById(userId);
        UserForListDto user = null;

        if (userDt.Rows.Count > 0)
        {
            foreach (DataRow dr in userDt.Rows)
            {
                user = new UserForListDto();
                user.UserId = Convert.ToInt32(dr["UserID"]);
                user.LoginId = dr["LoginId"].ToString();
                user.FirstName = dr["FirstName"].ToString();
                user.LastName = dr["LastName"].ToString();
                user.Email = dr["Email"].ToString();
                user.IsActive = !dr.IsNull("IsActive") ? Convert.ToBoolean(dr["IsActive"]) : (bool?)null;
                user.CreatedBy = !dr.IsNull("CreatedBy") ? Convert.ToInt32(dr["CreatedBy"]) : (int?)null;
                user.CreatedDate = !dr.IsNull("CreatedDate") ? Convert.ToDateTime(dr["CreatedDate"]) : (DateTime?)null;
                user.UpdatedBy = !dr.IsNull("UpdatedBy") ? Convert.ToInt32(dr["UpdatedBy"]) : (int?)null;
                user.UpdatedDate = !dr.IsNull("UpdatedDate") ? Convert.ToDateTime(dr["UpdatedDate"]) : (DateTime?)null;
                user.TimeOut = Convert.ToInt32(dr["TimeOut"]);
            }
        }

        return user;
    }

    public async Task<bool> IsActiveUser(int userId)
    {
        return await _userRepository.IsActiveUser(userId);
    }
}
