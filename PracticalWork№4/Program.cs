using System;
using System.Collections.Generic;

class Note
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public DateTime CompletionDate { get; set; }

    public Note(string title, string description, DateTime date, DateTime completionDate)
    {
        Title = title;
        Description = description;
        Date = date;
        CompletionDate = completionDate;
    }
}

class Program
{
    static List<Note> notes = new List<Note>();
    static Note selectedNote;
    static void Main(string[] args)
    {
        notes.Add(new Note("Заметочка 1", "Описание 1", new DateTime(2023, 7, 5), new DateTime(2023, 7, 6)));
        notes.Add(new Note("Заметочка 2", "Описание 2", new DateTime(2023, 12, 20), new DateTime(2023, 12, 21)));
        notes.Add(new Note("Заметочка 3", "Описание 3", new DateTime(2023, 9, 17), new DateTime(2023, 9, 18)));
        notes.Add(new Note("Заметочка 4", "Описание 4", new DateTime(2023, 10, 28), new DateTime(2023, 10, 29)));
        notes.Add(new Note("Заметочка 5", "Описание 5", new DateTime(2023, 11, 9), new DateTime(2023, 11, 10)));

        selectedNote = notes[0];

        notedescription();

        bool running = true;

        do
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.Clear();

            if (keyInfo.Key == ConsoleKey.T)
            {
                createnote();
                notedescription();
            }
            else if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                int currentIndex = notes.IndexOf(selectedNote);
                if (currentIndex > 0)
                    selectedNote = notes[currentIndex - 1];

                notedescription();
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                int currentIndex = notes.IndexOf(selectedNote);
                if (currentIndex < notes.Count - 1)
                    selectedNote = notes[currentIndex + 1];

                notedescription();
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                notedetails();
                notedescription();
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                running = false;
            }
        } while (running);
    }

    static void notedescription()
    {
        Console.WriteLine("Дата: " + selectedNote.Date.ToString("dd.MM.yyyy |"));
        Console.WriteLine("------------------");

        for (int i = 0; i < notes.Count; i++)
        {
            if (notes[i] == selectedNote)
                Console.WriteLine("> " + notes[i].Title);
            else
                Console.WriteLine(notes[i].Title);
        }

        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("1 - Для перемещения используйте стрелки влево и вправо |");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("2 - Чтобы открыть заметку нажмите Enter |");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("3 - Нажми букву T чтобы создать новую заметку |");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("4 - Для того чтобы выйти нажмите ESC |");
        Console.WriteLine("--------------------------------------");
    }

    static void notedetails()
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Развёрнутая информация:");
        Console.WriteLine();
        Console.WriteLine("Топовое название: " + selectedNote.Title);
        Console.WriteLine();
        Console.WriteLine("Наикрутейшее описание: " + selectedNote.Description);
        Console.WriteLine();
        Console.WriteLine("Невероятная дата: " + selectedNote.Date.ToString("dd.MM.yyyy"));
        Console.WriteLine();
        Console.WriteLine("Дата окончания : " + selectedNote.CompletionDate.ToString("dd.MM.yyyy"));
        Console.WriteLine("------------------------");
        Console.WriteLine("Закройте глага и нажмите рукой по клаве чтобы выйти...");
        Console.ReadKey();
        Console.Clear();
    }

    static void createnote()
    {
        Console.Write("Введите топовое название заметки: ");
        string title = Console.ReadLine();

        Console.Write("Введите наикрутейшее описание примечания: ");
        string description = Console.ReadLine();

        DateTime date = DateTime.Now;
        DateTime completionDate = date;

        Note newNote = new Note(title, description, date, completionDate);
        notes.Add(newNote);
        selectedNote = newNote;
    }
}