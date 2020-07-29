using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Long_Short_URL.Models
{
    public class Link
    {
        // ID записи.
        public int Id { get; set; }
        // Длинная ссылка.
        public string LongUrl { get; set; }
        // Короткая ссылка.
        public string ShortUrl { get; set; }
        // Количество переходов по ссылке.
        public int CountTransition { get; set; }
        private DateTime _returnDate = DateTime.MinValue;
        // Дата.
        public DateTime Date
        {
            get
            {
                return (_returnDate == DateTime.MinValue) ? DateTime.Now : _returnDate;
            }
            set { _returnDate = value; }
        }

    }
}
