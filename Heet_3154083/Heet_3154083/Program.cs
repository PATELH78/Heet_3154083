using Heet_3154083;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Heet_3154083.Entities;
class Program
{
    static void Main(string[] args)
    {
        string message = "Hello World!!";

        Console.WriteLine(message);
        TestDatabase();
    }

    public static void TestDatabase()
    {

        var context = new DataContext();
        var repo = new Repo(context);


        var user1 = new User
        {
            Name = "HeetPatel",
            Email = "patel79@example.com",
            PhoneNumber = "123-258-8523"
        };
        repo.Create<User>(user1);
        repo.CommitTransacton();

        List<User> users = repo.GetAll<User>();

        Console.WriteLine("User List");
        foreach (User user in users)
        {
            Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Email: {user.Email}, PhoneNumber: {user.PhoneNumber}");
        }



        user1.Name = "hetanshi";
        user1.Email = "abc@gmail.com";
        repo.Update<User>(user1);
        repo.CommitTransacton();

        List<User> users1 = repo.GetAll<User>();

        Console.WriteLine("User List");
        foreach (User user in users1)
        {
            Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Email: {user.Email}, PhoneNumber: {user.PhoneNumber}");
        }


        repo.Delete<User>(1);
        repo.CommitTransacton();
        List<User> users2 = repo.GetAll<User>();

        Console.WriteLine("User List");
        foreach (User user in users2)
        {
            Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Email: {user.Email}, PhoneNumber: {user.PhoneNumber}");
        }


    }
}