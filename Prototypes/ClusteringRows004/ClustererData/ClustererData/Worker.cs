using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClustererData
{
    public class Worker
    {
        public List<string> GetRow(string text)
        {            
            return text.Split('\n').ToList();
        }
        public List<string> GetWord(string text)
        {
            return text.Split('\t').ToList();
        }
    }
}
