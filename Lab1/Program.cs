using System;
using System.Collections.Generic;


namespace Notebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в программу Записная книжка!");
            bool contin = true;
            int command;
            int id;
            while (contin) //Цикл программы (выполнение команд, пока пользователь из нее не выйдет)
            {


                Console.WriteLine("Ниже представлен список команд с их id. \nВыберите нужную команду и введите ее id и нажмите Enter!");
                Console.WriteLine("ID   Описание команды");
                Console.WriteLine("1    Создание новой учетной записи");
                Console.WriteLine("2    Редактирование созданных записей");
                Console.WriteLine("3    Удаление созданных записей");
                Console.WriteLine("4    Просмотр созданных записей");//при запуске данной команды возможен просмотр информации о каждой записи по отдельности
                Console.WriteLine("5    Заполнить записную книгу тестовыми значениями");
                Console.WriteLine("6    Выход");
                Console.Write("Введите id: ");

                if (int.TryParse(Console.ReadLine(), out id))
                {

                    Console.Clear();
                    switch (id)
                    { //Выбор команды для исполнения

                        case 1:
                            Notebook.Add();
                            Console.WriteLine("Готово!");
                            Console.WriteLine("-------------------------");

                            Console.WriteLine("1 - На главную, \nEnter - Выйти из программы");

                            Console.Write("Введите команду: ");
                            if (int.TryParse(Console.ReadLine(), out command))
                            {
                                if (command == 1) { Console.Clear(); continue; }
                                else contin = false;
                            }
                            else contin = false;
                            break;
                        case 2:
                            Notebook.Edit();

                            Console.WriteLine("-------------------------");

                            Console.WriteLine("1 - На главную, \nEnter - Выйти из программы");

                            Console.Write("Введите команду: ");
                            if (int.TryParse(Console.ReadLine(), out command))
                            {
                                if (command == 1) { Console.Clear(); continue; }
                                else contin = false;
                            }
                            else contin = false;
                            break;
                        case 3:
                            Notebook.DeleteAccount();
                            Console.WriteLine("-------------------------");

                            Console.WriteLine("1 - На главную, \nEnter - Выйти из программы");

                            Console.Write("Введите команду: ");
                            if (int.TryParse(Console.ReadLine(), out command))
                            {
                                if (command == 1) { Console.Clear(); continue; }
                                else contin = false;
                            }
                            else contin = false;
                            break;
                        case 4:
                            Notebook.ShowAll();
                        choose:
                            Console.WriteLine("-------------------------");

                            Console.WriteLine("1 - На главную, \n2 - Просмотр информации о конкретной учетной записи, \nEnter - Выйти из программы");
                            //int command;
                            Console.Write("Введите команду: ");
                            if (int.TryParse(Console.ReadLine(), out command))
                            {
                                if (command == 1) { Console.Clear(); continue; }
                                if (command == 2) { Console.Clear(); Notebook.ShowOne(); goto choose; }
                                else contin = false;
                            }
                            else contin = false;
                            break;
                        case 5:
                            Notebook.TestCollect();
                            Console.WriteLine("Готово!");
                            Console.WriteLine("-------------------------");

                            Console.WriteLine("1 - На главную, \nEnter - Выйти из программы");

                            Console.Write("Введите команду: ");
                            if (int.TryParse(Console.ReadLine(), out command))
                            {
                                if (command == 1) { Console.Clear(); continue; }
                                else contin = false;
                            }
                            else contin = false;
                            break;
                        case 6:
                            contin = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Введен неверный id! Пожалуйста, введите верный id.");
                            break;
                    }

                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("Введен неверный id! Пожалуйста, введите верный id.");
                }
            }
        }
    }

    public class Notebook
    {
        public static List<Human> list = new List<Human>();
        public static void Edit() //Функция отвечает за редактирование учетной записи пользователя
        {
            //Console.Clear();
            Console.WriteLine("Режим редактирования");


            if (list.Count > 0)
            {
                ShowAll();
                Console.Write("Введите id пользователя: ");
                int id;
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    if (id >= 0 && id < list.Count)
                    {
                        Console.WriteLine($"Выбран пользователь с id {id}: " + list[id]);
                        Console.WriteLine("Если хотите оставить поле без изменений - нажмите Enter,\nЕсли хотите удалить НЕОБЯЗАТЕЛЬНОЕ поле - введите '-'");

                    surname:
                        Console.Write("(Обязательное) Фамилия: ");
                        string surname = Console.ReadLine();
                        if (!string.IsNullOrEmpty(surname))
                        {
                            foreach (var e in surname) { if (!char.IsLetter(e)) { Console.WriteLine("Поле Фамилия не должно содержать иных символов, кроме букв!"); goto surname; } }
                            list[id].LastName = surname;
                        }

                    firstname:
                        Console.Write("(Обязательное) Имя: ");
                        string firstname = Console.ReadLine();
                        if (!string.IsNullOrEmpty(firstname))
                        {
                            foreach (var e in firstname) { if (!char.IsLetter(e)) { Console.WriteLine("Поле Имя не должно содержать иных символов, кроме букв!"); goto firstname; } }
                            list[id].FirstName = firstname;
                        }

                    middlename:
                        Console.Write("Отчество: ");
                        string middlename = Console.ReadLine();
                        if (!string.IsNullOrEmpty(middlename))
                        {
                            if (middlename == "-") list[id].MiddleName = middlename;
                            else
                            {
                                foreach (var e in middlename) { if (!char.IsLetter(e)) { Console.WriteLine("Поле Отчество не должно содержать иных символов, кроме букв!"); goto middlename; } }
                                list[id].MiddleName = middlename;
                            }
                        }

                    phone:
                        Console.Write("(Обязательное) Телефон: ");
                        long phone;
                        string s = Console.ReadLine();
                        if (!string.IsNullOrEmpty(s))
                        {
                            if (!long.TryParse(s, out phone)) { Console.WriteLine("Поле Телефон должно быть заполнено и не должно содержать иных символов, кроме цифр!"); goto phone; }
                            list[id].PhoneNumber = phone;
                        }

                    country:
                        Console.Write("(Обязательное) Страна: ");
                        string country = Console.ReadLine();
                        if (!string.IsNullOrEmpty(country))
                        {
                            foreach (var e in country) { if (!char.IsLetter(e)) { Console.WriteLine("Поле Страна не должно содержать иных символов, кроме букв!"); goto country; } }
                            list[id].Country = country;
                        }

                    birth:
                        Console.Write("Дата рождения (Число.Месяц.Год): ");
                        DateTime birth;
                        string str = Console.ReadLine();
                        if (!string.IsNullOrEmpty(str))
                        {
                            if (str == "-") list[id].BirthDate = Convert.ToDateTime("01.01.0001");
                            else { if (!DateTime.TryParse(str, out birth)) { Console.WriteLine("Поле Дата рождения введено некорректно!"); goto birth; } list[id].BirthDate = birth; }
                        }


                        Console.Write("Организация: ");
                        string organization = Console.ReadLine();
                        if (!string.IsNullOrEmpty(organization))
                        {
                            list[id].Organization = organization;
                        }

                        Console.Write("Должность: ");
                        string employee = Console.ReadLine();
                        if (!string.IsNullOrEmpty(employee))
                        {
                            list[id].Employee = employee;
                        }

                        Console.Write("Дополнительные сведения: ");
                        string notes = Console.ReadLine();
                        if (!string.IsNullOrEmpty(notes))
                        {
                            list[id].Notes = notes;
                        }

                        Console.WriteLine("Готово!");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Введен некорректный id! Попробуйте заново!");
                        Edit();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Введен некорректный id! Попробуйте заново!");
                    Edit();
                }
            }
            else { Console.WriteLine("В записной книжке пока пусто!"); }
        }
        public static void Add() //Функция отвечает за добавление учетной записи пользователя
        {

            Console.WriteLine("Добавление новой учетной записи.");
            Console.WriteLine("Обязательные поля помечены, необязательные поля можете оставить пустыми, нажав Enter");

        surname:
            Console.Write("(Обязательное) Фамилия: ");
            string surname = Console.ReadLine();
            if (string.IsNullOrEmpty(surname)) { Console.WriteLine("Обязательные поля должны быть заполнены!"); goto surname; }
            else
            {
                foreach (var e in surname) { if (!char.IsLetter(e)) { Console.WriteLine("Поле Фамилия не должно содержать иных символов, кроме букв!"); goto surname; } }
            }

        firstname:
            Console.Write("(Обязательное) Имя: ");
            string firstname = Console.ReadLine();
            if (string.IsNullOrEmpty(firstname)) { Console.WriteLine("Обязательные поля должны быть заполнены!"); goto firstname; }
            else
            {
                foreach (var e in firstname) { if (!char.IsLetter(e)) { Console.WriteLine("Поле Имя не должно содержать иных символов, кроме букв!"); goto firstname; } }
            }

        middlename:
            Console.Write("Отчество: ");
            string middlename = Console.ReadLine();
            if (string.IsNullOrEmpty(middlename)) { middlename = "-"; }
            else
            {
                foreach (var e in middlename) { if (!char.IsLetter(e)) { Console.WriteLine("Поле Отчество не должно содержать иных символов, кроме букв!"); goto middlename; } }
            }

        phone:
            Console.Write("(Обязательное) Телефон: ");
            long phone;
            if (!long.TryParse(Console.ReadLine(), out phone)) { Console.WriteLine("Поле Телефон должно быть заполнено и не должно содержать иных символов, кроме цифр!"); goto phone; }

        country:
            Console.Write("(Обязательное) Страна: ");
            string country = Console.ReadLine();
            if (string.IsNullOrEmpty(country)) { Console.WriteLine("Обязательные поля должны быть заполнены!"); goto country; }
            else
            {
                foreach (var e in country) { if (!char.IsLetter(e)) { Console.WriteLine("Поле Страна не должно содержать иных символов, кроме букв!"); goto country; } }
            }

        birth:
            Console.Write("Дата рождения (Число.Месяц.Год): ");
            DateTime birth;
            string str = Console.ReadLine();
            if (string.IsNullOrEmpty(str)) { birth = Convert.ToDateTime("01.01.0001"); }
            else
            {
                if (!DateTime.TryParse(str, out birth)) { Console.WriteLine("Поле Дата рождения введено некорректно!"); goto birth; }
            }

            Console.Write("Организация: ");
            string organization = Console.ReadLine();
            if (string.IsNullOrEmpty(organization)) organization = "-";

            Console.Write("Должность: ");
            string employee = Console.ReadLine();
            if (string.IsNullOrEmpty(employee)) employee = "-";

            Console.Write("Дополнительные сведения: ");
            string notes = Console.ReadLine();
            if (string.IsNullOrEmpty(notes)) notes = "-";

            list.Add(new Human(firstname, surname, middlename, phone, country, birth, organization, employee, notes));
        }
        public static void TestCollect() //Функция отвечает за добавление тестовых учетных записей
        {
            list.Add(new Human("Константин", "Горбунов", "Дмитриевич", 89112863362, "Российская Федерация", Convert.ToDateTime("26.11.2000"), "ITMO", "Студент", "Сдает лабораторную"));
            list.Add(new Human("Александр", "Тестов", "Александрович", 89111234563, "Российская Федерация", Convert.ToDateTime("27.11.2000"), "МТС", "Менеджер", "Работник месяца"));
            list.Add(new Human("Илья", "Крутой", "Олегович", 89111234563, "Российская Федерация", Convert.ToDateTime("28.11.1988"), "Билайн", "Менеджер", "Не работник месяца"));
            list.Add(new Human("Олег", "Воронцов", "Владимирович", 89145363463, "Российская Федерация", Convert.ToDateTime("29.11.1980"), "Мегафон", "Менеджер", "Хочет открыть свое ИП"));
        }
        public static void DeleteAccount() //Функция отвечает за удаление учетной записи пользователя
        {

            if (list.Count > 0)
            {

                ShowAll();
                Console.WriteLine("--------------------");
                Console.Write("Введите id пользователя, которого Вы хотите удалить: ");
                int id;
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    if (id >= 0 && id < list.Count)
                    {
                        list.RemoveAt(id);
                        Console.Clear();
                        Console.WriteLine($"Пользователь с id {id} успешно удален!");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Введен неверный id! Пожалуйста, введите верный id.");
                        DeleteAccount();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Введен неверный id! Пожалуйста, введите верный id.");
                    DeleteAccount();
                }
            }
            else
            {
                Console.WriteLine("Удалять пока некого!");
            }
        }
        public static void ShowAll() //Функция отвечает за вывод в консоль всех учетных записей
        {
            if (list.Count == 0) { Console.WriteLine("В записной книжке пока пусто!"); }
            else
            {
                Console.WriteLine("id\tУчетная запись");

                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine(i + " \t" + list[i]);
                }
            }
        }
        public static void ShowOne() //Функция отвечает за вывод в консоль одной учетной записи пользователя
        {

            if (list.Count > 0)
            {
                ShowAll();
                Console.Write("Введите id пользователя: ");
                int id;
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    if (id >= 0 && id < list.Count)
                    {
                        Console.Clear();
                        string birth;
                        if (list[id].BirthDate == Convert.ToDateTime("01.01.0001")) birth = "-"; else birth = list[id].BirthDate.ToString("dd MMMM yyyy");
                        Console.WriteLine($"Информация о пользователе с id {id}");
                        Console.WriteLine($"Фамилия: {list[id].LastName}\n" +
                            $"Имя: {list[id].FirstName}\n" +
                            $"Отчество: {list[id].MiddleName}\n" +
                            $"Номер телефона: {list[id].PhoneNumber}\n" +
                            $"Страна: {list[id].Country}\n" +
                            $"Дата рождения: {birth}\n" +
                            $"Организация: {list[id].Organization}\n" +
                            $"Должность: {list[id].Employee}\n" +
                            $"Дополнительные сведения: {list[id].Notes}\n");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Введен некорректный id! Попробуйте заново!");
                        ShowOne();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Введен некорректный id! Попробуйте заново!");
                    ShowOne();
                }
            }
            else { Console.WriteLine("В записной книжке пока пусто!"); }
        }
    }
    public class Human //Данный класс описывает пользователя
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public long PhoneNumber { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
        public string Organization { get; set; }
        public string Employee { get; set; }
        public string Notes { get; set; }
        public override string ToString()
        {
            return $"{LastName}  {FirstName}  Телефон: {PhoneNumber}";
        }
        public Human(string firstName, string lastName, string middleName, long phoneNumber, string country, DateTime birthDate, string organization, string employee, string notes)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Country = country;
            if (string.IsNullOrEmpty(middleName)) MiddleName = "-"; else MiddleName = middleName;
            if (string.IsNullOrEmpty(organization)) Organization = "-"; else Organization = organization;
            if (string.IsNullOrEmpty(employee)) Employee = "-"; else Employee = employee;
            if (string.IsNullOrEmpty(notes)) Notes = "-"; else Notes = notes;
            BirthDate = birthDate;
        }
    }
}
