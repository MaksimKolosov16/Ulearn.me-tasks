using System;
using System.Linq;
using System.Text;
using Xunit;

namespace DecodeMessage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var message = new[]
            {
                "решИла нЕ Упрощать и зашифРОВАтЬ Все послаНИЕ",
                "дАже не Старайся нИЧЕГО у тЕбя нЕ получится с расшифРОВкой",
                "Сдавайся НЕ твоего ума Ты не споСОбЕн Но может быть",
                "если особенно упорно подойдешь к делу",
                "",
                "будет Трудно конечнО",
                "Код ведЬ не из простых",
                "очень ХОРОШИЙ код",
                "то у тебя все получится",
                "и я буДу Писать тЕбЕ еще",
                "",
                "чао"
            };

            var expected = "Писать ХОРОШИЙ Код Трудно Но Ты НЕ Сдавайся Старайся Все Упрощать";

            var decodedMessage = DecodeMessage(message);

            Assert.True(decodedMessage == expected);
        }

        private static string DecodeMessage(string[] lines)
        {
            var words = lines.Select(l => l.Split(' ')).SelectMany(w => w);

            var startedWithUpperLetter = words.Where(w => w.Length > 0 && char.IsUpper(w[0])).ToArray();

            return string.Join(" ", startedWithUpperLetter.Reverse());
        }
    }
}