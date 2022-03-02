using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p02_Articles
{
    public class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public void Edit(string newContent)
        {
            this.Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] inputs = input.Split(new string[] { ", "}, StringSplitOptions.RemoveEmptyEntries);

            Article article = new Article(inputs[0], inputs[1], inputs[2]);

            int numberOfEdits = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEdits; i++)
            {
                string editInput = Console.ReadLine();
                string[] editCommands = editInput.Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries);

                string action = editCommands[0];

                if (action == "Edit")
                {
                    string newContent = editCommands[1];

                    article.Edit(newContent);
                }
                else if (action == "ChangeAuthor")
                {
                    string newAuthor = editCommands[1];

                    article.ChangeAuthor(newAuthor);
                }
                else if (action == "Rename")
                {
                    string newTitle = editCommands[1];

                    article.Rename(newTitle);
                }
            }

            Console.WriteLine(article);
        }
    }
}
