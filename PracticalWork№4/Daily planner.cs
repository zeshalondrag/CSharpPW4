using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CSharpPW4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            List<Note> notes = new List<Note>();

            Note note1 = new Note();
            note1.Name = "ИТ";
            note1.Description = "Сделать 8 - ую практическую работу по ИТ.";
            note1.Date = new DateTime(2023, 12, 4);
            notes.Add(note1);

            Note note2 = new Note();
            note2.Name = "Python";
            note2.Description = "Доделать 4 - ую практическую работу по Python.";
            note2.Date = new DateTime(2023, 12, 5);
            notes.Add(note2);

            Note note3 = new Note();
            note3.Name = "БД";
            note3.Description = "Сделать и сдать 4 -ую, 5 -ую и 6 - ую практическую работу по БД.";
            note3.Date = new DateTime(2023, 12, 6);
            notes.Add(note3);

            Note note4 = new Note();
            note4.Name = "C#";
            note4.Description = "НАДЕЮСЬ ВЫ ПРОВЕРИТЕ ЭТУ РАБОТУ!";
            note4.Date = new DateTime(2023, 12, 7);
            notes.Add(note4);

            Note note5 = new Note();
            note5.Name = "Магазин";
            note5.Description = "Сгонять за чипсиками и за пивком";
            note5.Date = new DateTime(2023, 12, 8);
            notes.Add(note5);

            DateTime dateTime = DateTime.Today;

            int position = 0;
            int foreachI = 0;

            Console.WriteLine($"->Ежендевник\r\n  Сегодняшняя дата: {DateTime.Today.ToShortDateString()}\r\n  Выбрана дата: {dateTime.ToShortDateString()}\r\n  Создать заметку\r\n  Заметки на сегодня:");
            
            do
            {
                foreachI = Input(dateTime, notes, foreachI);

                ConsoleKeyInfo key = Console.ReadKey(true);

                if ((key.Key == ConsoleKey.UpArrow) || (key.Key == ConsoleKey.W) || (key.Key == ConsoleKey.DownArrow) || (key.Key == ConsoleKey.S))
                {
                    position = Arrows(key, position, foreachI);
                }

                else if (position == 2 & ((key.Key == ConsoleKey.LeftArrow) || (key.Key == ConsoleKey.A) || (key.Key == ConsoleKey.RightArrow) || (key.Key == ConsoleKey.D)))
                {
                    dateTime = DateChange(key, dateTime, notes, position);
                }

                else if (position == 3 & key.Key == ConsoleKey.Enter)
                {
                    notes = NotesCreate(notes, dateTime);
                }

                else if (position > 4 & key.Key == ConsoleKey.Enter)
                {
                    Information(foreachI, dateTime, position, notes);
                }
            }
            while (true);
        }

        static int Arrows(ConsoleKeyInfo key, int position, int foreachI)
        {
            int prevPosition = 0;

            if ((key.Key == ConsoleKey.UpArrow) || (key.Key == ConsoleKey.W))
            {
                if (position == 0)
                {
                    position = 0;
                    prevPosition = 0;
                }

                else
                {
                    prevPosition = position;
                    position--;
                }
            }

            else if ((key.Key == ConsoleKey.DownArrow) || (key.Key == ConsoleKey.S))
            {

                prevPosition = position;
                position++;
            }

            Console.SetCursorPosition(0, prevPosition);
            Console.Write("  ");
            Console.SetCursorPosition(0, position);
            Console.Write("->");

            return position;
        }

        static DateTime DateChange(ConsoleKeyInfo key, DateTime dateTime, List<Note> notes, int position)
        {
            if ((key.Key == ConsoleKey.LeftArrow) || (key.Key == ConsoleKey.A))
            {
                dateTime = dateTime.AddDays(-1);
            }

            else if ((key.Key == ConsoleKey.RightArrow) || (key.Key == ConsoleKey.D))
            {
                dateTime = dateTime.AddDays(1);
            }

            Console.SetCursorPosition(16, 2);
            Console.WriteLine(dateTime.ToShortDateString());

            return dateTime;
        }

        static int Input(DateTime dateTime, List<Note> notes, int foreachI)
        {
            int amount = 0;

            foreach (var item in notes)
            {
                if (item.Date == dateTime)
                {
                    amount++;
                }

                if (amount > foreachI)
                {
                    foreachI = amount;
                }
            }

            for (int i = 0; i <= foreachI; i++)
            {
                Console.SetCursorPosition(2, 5 + i);

                for (int j = 0; j < 59; j++)
                {
                    Console.Write("  ");
                }
            }


            int forI = 0;

            for (int i = 0; i < notes.Count; i++)
            {
                if (notes[i].Date == dateTime)
                {
                    Console.SetCursorPosition(2, 5 + forI);

                    Console.WriteLine($"{forI}. {notes[i].Name}");

                    forI++;
                }

            }

            return foreachI;
        }

        static List<Note> NotesCreate(List<Note> notes, DateTime dateTime)
        {
            Console.CursorVisible = true;

            bool access = false;

            Note newNote = new Note();

            newNote.Date = dateTime;

            Console.SetCursorPosition(2, 5);
            Console.Write("Введите имя новой заметки: ");
            newNote.Name = Console.ReadLine();

            Console.SetCursorPosition(2, 6);
            Console.Write("Введите содержание новой заметки: ");
            newNote.Description = Console.ReadLine();

            notes.Add(newNote);

            Console.CursorVisible = false;

            Console.SetCursorPosition(2, 5);
            for (int i = 0; i < 19 + newNote.Name.Length; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(2, 6);
            for (int i = 0; i < 26 + newNote.Description.Length; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(2, 5);

            return notes;
        }

        static void Information(int foreachI, DateTime dateTime, int position, List<Note> notes)
        {
            for (int i = 0; i < 3 * foreachI; i++)
            {
                Console.SetCursorPosition(2, position + foreachI + i);

                for (int j = 0; j < 59; j++)
                {
                    Console.Write("  ");
                }
            }

            List<Note> currentNotes = new List<Note>();

            for (int i = 0; i < notes.Count; i++)
            {
                if (notes[i].Date == dateTime)
                {
                    currentNotes.Add(notes[i]);
                }
            }

            Console.SetCursorPosition(2, position + foreachI + 1);
            Console.WriteLine("Название: " + currentNotes[position - 5].Name);
            Console.SetCursorPosition(2, position + foreachI + 2);
            Console.WriteLine("Дата: " + currentNotes[position - 5].Date.ToString("D"));
            Console.SetCursorPosition(2, position + foreachI + 3);
            Console.WriteLine("Содержание: " + currentNotes[position - 5].Description);
        }
    }
}
