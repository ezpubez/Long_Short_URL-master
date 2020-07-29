using Long_Short_URL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Long_Short_URL.Data
{
    public class ShortLink
    {
        // Символы для генерации короткой ссылки.
        string alphabet = "qwertyuiopasdfghjklzxcvbnm1234567890";
        // Паттерн проверки регулярного выражения URL.
        string pattern = @"/(?:([^\:]*)\:\/\/)?(?:([^\:\@]*)(?:\:([^\@]*))?\@)?(?:([^\/\:]*)\.(?=[^\.\/\:]*\.[^\.\/\:]*))?([^\.\/\:]*)(?:\.([^\/\.\:]*))?(?:\:([0-9]*))?(\/[^\?#]*(?=.*?\/)\/)?([^\?#]*)?(?:\?([^#]*))?(?:#(.*))?/";

        // Генерированная строка.
        StringBuilder tempStr;
        // Генератор случайных чисел.
        Random rnd;
        // Возвращаемый объект.
        Link _link;

        public ShortLink()
        {
            _link = new Link();
            rnd = new Random();
            tempStr = new StringBuilder();
        }
        // Метод для сокращения ссылки
        public Link Cut(string link)
        {
            if (Regex.IsMatch(link, pattern, RegexOptions.IgnoreCase))
            {
                _link.LongUrl = link;
                for (int i = 0; i < 6; i++)
                {
                    tempStr.Append(alphabet[rnd.Next(alphabet.Length - 1)]);
                }
                _link.ShortUrl = tempStr.ToString();
                return _link;
            }
            else
            {
                return null;
            }
        }
    }
}
