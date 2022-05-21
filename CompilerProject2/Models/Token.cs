using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompilerProject2.Models
{
    public class Token
    {
        public string Name { get; set; } // Token name
        public string Type { get; set; } // Token type
        public int Line { get; set; } //Excist in line number ??
    }
}
