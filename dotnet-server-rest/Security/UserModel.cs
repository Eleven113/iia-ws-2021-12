namespace Security;

using System.ComponentModel.DataAnnotations;

public record UserModel
{
	[Required]
	public string Username { get; set; }

	[Required]
	public string Password { get; set; }

	public UserModel()
	{

	}

	public UserModel(string username, string password)
	{
		this.Username = username;
		this.Password = password;
	}
}