using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//////////////////////////////////////////////////////
using Component;

namespace Component.LLSDataSource
{
    public static class Standart_Small
    {
        public static List<List<string>> Data_Super_Small()
        {
            return (new List<string>[] {
                    (new string[] {(new SPExtractor("Name","Data_Super_Small")).p_String
                                        ,	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                    ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                    ,(new string[] {"А2",	"1",	"1",	"0",	"0",	"1"	}).ToList<string>()	
                    ,(new string[] {"А3",	"1",	"1",	"0",	"0",	"0"	}).ToList<string>()	
                    ,(new string[] {"А4",	"1",	"1",	"0",	"0",	"0"	}).ToList<string>()	
                    ,(new string[] {"А5",	"1",	"1",	"0",	"1",	"1"	}).ToList<string>()	
                    ,(new string[] {"А6",	"0",	"0",	"0",	"0",	"0"	}).ToList<string>()	
                    ,(new string[] {"А7",	"1",	"0",	"0",	"1",	"1"	}).ToList<string>()	
                    ,(new string[] {"А8",	"1",	"1",	"0",	"0",	"1"	}).ToList<string>()	
                    ,(new string[] {"А9",	"1",	"1",	"1",	"1",	"1"	}).ToList<string>()	
                    ,(new string[] {"А10",	"1",	"0",	"0",	"1",	"1"	}).ToList<string>()	
                }).ToList<List<string>>();
                ;
        }
    }
}