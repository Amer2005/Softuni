using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p07_StringExplosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder explodedText = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != '>')
                {
                    explodedText.Append(text[i]);
                }
                else
                {
                    int explosionForce = text[i + 1] - '0';
                    i++;
                    explodedText.Append('>');

                    while (explosionForce > 0 && i < text.Length)
                    {
                        if (text[i] == '>')
                        {
                            explodedText.Append('>');
                            explosionForce += text[i + 1] - '0';

                            i++;
                        }

                        i++;
                        explosionForce--;
                    }

                    i--;
                }
            }

            Console.WriteLine(explodedText.ToString());
        }
    }
}
