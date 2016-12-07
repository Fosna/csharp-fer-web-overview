using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;

namespace CourseWork.Models.Db
{
    /// <summary>
    /// Creates random student code.
    /// </summary>
    public class StudentCodeRandomizer : IRandomizerPlugin<string>
    {
        private const int MIN_RAND_NUM = 1000;
        private const int MAX_RAND_NUM = 100000;

        private readonly Random _numberRandomizer;

        public StudentCodeRandomizer()
        {
            _numberRandomizer = new Random();
        }

        public string GetValue()
        {
            var val = _numberRandomizer.Next(MIN_RAND_NUM, MAX_RAND_NUM).ToString().PadLeft(5, '0');
            return val;
        }
    }
}
