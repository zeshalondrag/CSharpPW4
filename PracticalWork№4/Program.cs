using System;
using System.Collections.Generic;

namespace NoteApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Note> notes = new List<Note>
            {
                new Note { Name = "Заметка 1", Date = new DateTime(2023, 6, 6), Description = "Описание 1" },
                new Note { Name = "Заметка 2", Date = new DateTime(2023, 6, 8), Description = "Описание 2" },
                new Note { Name = "Заметка 3", Date = new DateTime(2023, 6, 13), Description = "Описание 3" },
                new Note { Name = "Заметка 4", Date = new DateTime(2023, 6, 16), Description = "Описание 4" },
                new Note { Name = "Заметка 5", Date = new DateTime(2023, 6, 18), Description = "Описание 5" }
            };

            ConsoleKeyInfo key;
            int currentNoteIndex = 0;

            do
            {
                Console.Clear();
                PrintNotes(notes, currentNoteIndex);
                PrintMenu(notes[currentNoteIndex]);

                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    ShowNoteInfo(notes[currentNoteIndex]);
                    Console.ReadLine();
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    currentNoteIndex = (currentNoteIndex + 1) % notes.Count;
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    currentNoteIndex = (currentNoteIndex - 1 + notes.Count) % notes.Count;
                }
                else if (key.Key == ConsoleKey.T)
                {
                    CreateNewNote(notes);
                }
            } while (key.Key != ConsoleKey.Escape);
        }

        static void PrintNotes(List<Note> notes, int currentNoteIndex)
        {
            for (int i = 0; i < notes.Count; i++)
            {
                if (i == currentNoteIndex)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ResetColor();
                }

                Console.WriteLine(notes[i].Name);
            }
        }

        static void PrintMenu(Note note)
        {
            Console.WriteLine($"\nДата: {note.Date.ToShortDateString()}");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("1 - Для перемещения используйте стрелки влево и вправо");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("2 - Чтобы открыть заметку нажмите Enter");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("3 - Нажми букву T чтобы создать новую заметку");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("4 - Для того чтобы выйти нажмите ESC");
            Console.WriteLine("--------------------------------------");
        }

        static void ShowNoteInfo(Note note)
        {
            Console.WriteLine("\n\nИнформация заметки:");
            Console.WriteLine($"Имя: {note.Name}");
            Console.WriteLine($"Описание: {note.Description}");
            Console.WriteLine($"Дата: {note.Date.ToShortDateString()}");
        }

        static void CreateNewNote(List<Note> notes)
        {
            Console.Clear();
            Console.WriteLine("Создание новой заметки:");

            Console.Write("Введите имя заметки: ");
            string name = Console.ReadLine();

            Console.Write("Введите описание заметки: ");
            string description = Console.ReadLine();

            DateTime date = DateTime.Now;

            Note newNote = new Note { Name = name, Date = date, Description = description };
            notes.Add(newNote);

            Console.WriteLine("\nЗаметка успешно создана!");
            Console.ReadLine();
        }
    }

    class Note
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
