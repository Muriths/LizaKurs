using System;
using System.IO;
using System.Text;
namespace kak;
internal class Program
{
    static void Main(string[] args)
    {
        string[] person = HelloWindow().Split (new char[] { ' ' });
        string lvl = Logics(person[0], person[1])? "Администратор" : "Пользователь";
        string choose = Choose(lvl);
        switch (choose)
        {
            case "1":
                ShowBooks();
                break;
            case "2":
                AddZametka();
                break;
            case "3":
                GetMarks();
                break;
        }
        Console.WriteLine($"Здравствуйте ! Ваш уровень доступа {lvl}\n");
    }

    static string HelloWindow()
    {
        
        Console.WriteLine("Введите Login");
        string login = Console.ReadLine();
        Console.WriteLine("Введите Password");
        string password = Console.ReadLine();
        FilesWriter(login, password);
        return login + " " + password;
        Console.WriteLine("");
    }
    static string Choose(string lvl)
    {
        if(lvl == "Пользователь")
        {
            Console.WriteLine("Выберете из списка:");
            Console.WriteLine("1.Просмотреть имеющиеся книги.\n2.Добавить заметку." +
                "\n3.Поставить оценку.");
        }
        else
        {
            Console.WriteLine("Выберете из списка :");
            Console.WriteLine("1.Удалить существующего пользователя.\n2.Сменить пользователя");
        }
       return Console.ReadLine();
    }

    static void FilesWriter(string login, string password) //Реализация метода для записи пользователя
    {
        var person = $"login : {login} | password {password}";
        StreamWriter sw = new StreamWriter("users.txt", true);
        sw.WriteLine(person);
        sw.Close();
    }
    static bool Logics(string login, string password) // реализация логики определения заходит admin или user 
    {
        if (login == "admin" && password == "admin")
        {
            return true;
        }
        return false;
    }

    static void ShowBooks() //Показывает какие книги сейчас можно прочитать
    {
        StreamReader sr = new StreamReader("books.txt");
        while(!sr.EndOfStream)
        {
            Console.WriteLine(sr.ReadLine());
        }
        sr.Close();
    }
    static void AddZametka()//Добавление заметок
    {
        StreamWriter sw = new StreamWriter("books.txt", true);
        Console.WriteLine("Введите название заметки");
        string name = Console.ReadLine();
        Console.WriteLine("Введите содеражиние вашей заметки");
        string zametka = Console.ReadLine();
        sw.WriteLine(name + " - " +zametka );
        sw.Close();
    }
    static void DeleteUser() //Удаление юзеров
    {
        List<string> userList = new List<string>();
        StreamReader sr = new StreamReader("users.txt", true);
        int i = 0;
        while (!sr.EndOfStream)
        {
            userList.Add(sr.ReadLine());
            Console.WriteLine($"{i + 1 }.{sr.ReadLine()}");
        }
        Console.WriteLine("Выбери пользователя, которого хочешь удалить из базы данных");
        int choose = int.Parse(Console.ReadLine());
        userList.Remove(userList[choose - 1]);
    }
    static void GetMarks()
    {
        StreamWriter sw = new StreamWriter("marks.txt", true);
        Console.WriteLine("Введите оценку, за данный проект :) ");
        sw.WriteLine(Console.ReadLine());
        Console.WriteLine("Ваш результат записан. Благодарим за оценивание !");
        sw.Close();
    }
    static void ConsolClear()
    {
        Console.Clear();
    }
}