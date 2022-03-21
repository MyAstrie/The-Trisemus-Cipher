using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    internal class TextConverter
    {
        private string _encodingString;
        private string _decodingString;

        public string EncodingString
        {
            get
            {
                return _encodingString;
            }
            set
            {
                _encodingString = value;
            }
        }

        public string DecodingString
        {
            get
            {
                return _decodingString;
            }
            set
            {
                _decodingString = value;
            }
        }
    }
}
