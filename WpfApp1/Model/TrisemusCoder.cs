using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    internal class TrisemusCoder
    {
        private readonly Func<string, string> _coder;

        private readonly Func<string, string> _encoder;

        public TrisemusCoder(Func<string, string> converter)
        {
            _coder = converter;
        }

        public string ConvertText(string inputText)
        {
            return _coder(inputText);
        }
    }
}
