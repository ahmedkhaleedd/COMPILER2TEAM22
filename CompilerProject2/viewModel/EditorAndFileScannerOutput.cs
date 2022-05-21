using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompilerProject2.Models;

namespace CompilerProject2.viewModel
{
    public class EditorAndFileScannerOutput
    {
        public List<Token> EditorScannerOutPut { get; set; }
        public List<Token> FileScannerOutPut { get; set; }
        public int EditorNumberOfErors { get; set; }
        public int FileNumberOfErors { get; set; }
    }
}
