using System.Text.Json;
using TransGr8_DD_Test.Models;

namespace TransGr8_DD_Test.Services;

public static class UserData
{
    static UserData()
    {
        Users = GetUsersFromJson();
    }

    private static List<User> GetUsersFromJson()
    {
        var userDataFilePath = Path.Combine(AppContext.BaseDirectory, "../../../UserData.json");
        var users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(userDataFilePath));

        return users;
    }

    public static User GetUserByIndex(int index)
    {
        if (index < 1 || index > Users.Count)
        {
            return null;
        }

        return Users[index - 1];
    }

    public static List<User> Users { get; }
}