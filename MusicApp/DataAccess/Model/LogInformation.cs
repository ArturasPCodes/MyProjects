using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class LogInformation
    {
        public string FileName { get; set; }
        public DateTime InsertedAt { get; set; }

        public override string ToString()
        {
            return $"{FileName}, {InsertedAt}";
        }
    }
}
