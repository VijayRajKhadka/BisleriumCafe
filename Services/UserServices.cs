using BisleriumCafe.Components.Pages;
using BisleriumCafe.Models;
using BisleriumCafe.NewFolder;
using BisleriumCafe.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumCafe.Services;

public class UserServices : JsonServices<User>
{

    public const String SeedUsername = "admin";
    public const String SeedPhoneNumber = "111";
    public const String SeedPassword = "admin";


    public static String userDirectoryPath = Utility.GetUserDirectoryPath();

    public static void SeedUser()
    {
        var users = GetAllData(userDirectoryPath).FirstOrDefault(x => x.Role == Role.Admin);

        if (users == null)
        {
            CreateUser(Guid.Empty, SeedUsername, SeedPhoneNumber, SeedPassword, Role.Admin);
        }

    }
    public static List<User> CreateUser(Guid userID, string username, string phoneNumber, string password, Role role)
    {
        username = username.Trim();
        phoneNumber = phoneNumber.Trim();

        if (username == "" || phoneNumber == "" || password == "")
        {
            throw new Exception("Please Enter Valid Details");
        }

        var users = GetAllData(userDirectoryPath);
        
        var userExists = users.Any(x => x.PhoneNumber == phoneNumber);

        if (userExists)
        {
            throw new Exception("Sorry, User Already Exsist.");
        }

        var user = new User()
        {
            Username = username,
            PhoneNumber = phoneNumber,
            HashPassword = Utility.PasswordHash(password),
            Role = role,
            CreatedBy = userID,
        };

        users.Add(user);

        SaveData(users, userDirectoryPath);

        return users;

    }

    public static User Login(String phoneNumber, String password)
    {   
        var users = GetAllData(userDirectoryPath);
        

        var loginError = "Wrong Credentials";

        var user = users.FirstOrDefault(x => x.PhoneNumber == phoneNumber.Trim().ToLower());

        if (user == null)
        {
            throw new Exception(loginError);
        }

        bool validPassword = Utility.CheckHashPassword(password, user.HashPassword);

        if (!validPassword)
        {
            throw new Exception(loginError);
        }
        return user;
    }
    public static List<User> Delete(String phoneNumber)
    {
        var users = GetAllData(userDirectoryPath);

        var user = users.FirstOrDefault(x => x.PhoneNumber == phoneNumber);

        if (user == null)
        {
            throw new Exception("User not found.");
        }

        users.Remove(user);

        SaveData(users,userDirectoryPath);

        return users;
    }
}
