using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p03_Articles2._0
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
            int numberOfArticles = int.Parse(Console.ReadLine());

            Article[] articles = new Article[numberOfArticles];

            for (int i = 0; i < numberOfArticles; i++)
            {
                string input = Console.ReadLine();
                string[] commands = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                articles[i] = new Article(commands[0], commands[1], commands[2]);
            }

            string orderAction = Console.ReadLine();

            if (orderAction == "title")
            {
                articles = articles.OrderBy(x => x.Title).ToArray();
            }
            else if (orderAction == "content")
            {
                articles = articles.OrderBy(x => x.Content).ToArray();
            }
            else
            {
                articles = articles.OrderBy(x => x.Author).ToArray();
            }

            Console.WriteLine(string.Join("\n", articles.ToList()));
        }
    }
}
