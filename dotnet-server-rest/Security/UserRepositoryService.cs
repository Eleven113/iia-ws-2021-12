namespace Security;

public class UserRepositoryService : IUserRepositoryService
{
	private List<UserModel> _users => new()
	{
		new("jeremy", "toto")
	};
	
	public UserModel GetUser(UserModel userModel)
	{
		return _users.FirstOrDefault(x => string.Equals(x.Username, userModel.Username) && string.Equals(x.Password, userModel.Password));
	}
}