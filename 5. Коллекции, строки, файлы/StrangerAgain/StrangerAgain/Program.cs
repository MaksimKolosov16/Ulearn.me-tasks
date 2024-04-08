using System;
using System.Text;

namespace StrangerAgain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var strangersMessage = new[]
            {
                "push Привет! Это снова я! Пока!",
                "pop 5",
                "push Как твои успехи? Плохо?",
                "push qwertyuiop",
                "push 1234567890",
                "pop 26"
            };

            Console.WriteLine(ApplyCommands(strangersMessage));
        }

        private static string ApplyCommands(string[] commands)
        {
            var stringBuilder = new StringBuilder();

            foreach (var command in commands)
            {
                var parts = command.Split(' ');

                if (parts[0] == "push")
                    stringBuilder.Append(string.Join(' ', parts.Skip(1)));
                else if (parts[0] == "pop")
                {
                    var numberOfLettersToRemove = int.Parse(parts[1]);
                    stringBuilder.Remove(stringBuilder.Length - numberOfLettersToRemove, numberOfLettersToRemove);
                }
                else
                    throw new Exception("Unexpected command format");
            }

            return stringBuilder.ToString();
        }
    }
}