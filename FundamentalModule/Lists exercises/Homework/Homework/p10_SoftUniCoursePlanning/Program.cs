using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p10_SoftUniCoursePlanning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lessons = Console.ReadLine().Split(new string[] { ", "}, StringSplitOptions.RemoveEmptyEntries).ToList();

            string input;

            //Databases\nDatabases-Exercise

            while ((input = Console.ReadLine()) != "course start")
            {
                string[] arguments = input.Split(':');

                string action = arguments[0];

                if (action == "Add")
                {
                    string lesson = arguments[1];

                    if (lessons.Contains(lesson))
                    {
                        continue;
                    }

                    lessons.Add(lesson);
                }
                if (action == "Insert")
                {
                    string lesson = arguments[1];
                    int index = int.Parse(arguments[2]);

                    if (lessons.Contains(lesson))
                    {
                        continue;
                    }

                    lessons.Insert(index, lesson);
                }
                if (action == "Remove")
                {
                    string lesson = arguments[1];

                    if (!lessons.Contains(lesson))
                    {
                        continue;
                    }

                    RemoveLesson(lessons, lesson);
                }
                if (action == "Swap")
                {
                    string lesson1 = arguments[1];
                    string lesson2 = arguments[2];

                    int lesson1Index = FindLeson(lessons, lesson1);
                    int lesson2Index = FindLeson(lessons, lesson2);

                    if (lesson1Index == -1 || lesson2Index == -1)
                    {
                        continue;
                    }

                    string temp = lessons[lesson2Index];

                    lessons[lesson2Index] = lessons[lesson1Index];
                    lessons[lesson1Index] = temp;
                }
                if (action == "Exercise")
                {
                    string lesson = arguments[1];

                    int lessonIndex = FindLeson(lessons, lesson);
                    if (lessonIndex != -1)
                    {
                        if (lesson.Split('\n').Length > 1)
                        {
                            continue;
                        }

                        lessons.RemoveAt(lessonIndex);
                    }
                    else
                    {
                        lessonIndex = lessons.Count();
                    }

                    lessons.Insert(lessonIndex, $"{lesson}\n{lesson}-Exercise");
                }
            }

            int indexNow = 0;

            for (int i = 0; i < lessons.Count; i++)
            {
                indexNow++;

                string lesson = lessons[i];

                if(lesson.Split('\n').Count() > 1)
                {
                    string[] lessonExercises = lesson.Split('\n');

                    Console.WriteLine($"{indexNow}.{lessonExercises[0]}");

                    indexNow++;

                    Console.WriteLine($"{indexNow}.{lessonExercises[1]}");
                }
                else
                {
                    Console.WriteLine($"{indexNow}.{lesson}");
                }
            }
        }

        static int FindLeson(List<string> lessons, string lesson)
        {
            int index = lessons.IndexOf(lesson);

            if (index != -1)
            {
                return index;
            }

            return lessons.IndexOf($"{lesson}\n{lesson}-Exercise");
        }

        static void RemoveLesson(List<string> lessons, string lesson)
        {
            lessons.Remove(lesson);
            lessons.Remove($"{lesson}\n{lesson}-Exercise");
        }
    }
}
