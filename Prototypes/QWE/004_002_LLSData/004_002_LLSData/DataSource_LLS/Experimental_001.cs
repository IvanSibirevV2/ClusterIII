using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.LLSDataSource.Experimental
{
    /// <summary>Набор данных для эксперимента №1 Ценность родителей/учеников</summary>
    public static class _001
    {
        /// <summary>Данные для эксперимента Ценность родителей/учеников</summary>
        public static List<List<string>> Data_LLS1()
        {
            return (List<List<string>>)
                (new List<string>[] {
                    (new string[] {(new SPExtractor("Name","Experimental._001.LLS1()"))
                        .Set_Param("SoName","Ценности родителей 1")
                        .p_String       ,   "П1_1", "П6_1", "П2_1", "П3_1", "П4_1", "П5_1"  }).ToList<string>()
                    ,(new string[] {"A01)Комфортность"
                                        ,	"4",    "4",	"4",	"10",	"2.5",  "3.5"   }).ToList<string>()	
                    ,(new string[] {"A02)Традиции"
                                        ,	"10",   "10",   "5",    "1",    "9",    "7"     }).ToList<string>()	
                    ,(new string[] {"A03)Доброта"
                                        ,   "7",    "7",    "1",    "3",    "1",    "1"     }).ToList<string>()	
                    ,(new string[] {"A04)Универсализм"
                                        ,   "8",    "8",    "6",    "6",    "8",    "3.5"   }).ToList<string>()	
                    ,(new string[] {"A05)Самостоятельность"
                                        ,   "1",    "1",    "3",    "7",    "4.5",   "5"    }).ToList<string>()	
                    ,(new string[] {"A06)Стимуляция"
                                        ,   "3",    "3",    "9",    "8.5",  "10",   "8"     }).ToList<string>()	
                    ,(new string[] {"A07)Гедонизм"
                                        ,   "9",    "9",    "2",    "5",    "6",    "6"     }).ToList<string>()	
                    ,(new string[] {"A08)Достижения"
                        	            ,   "2",    "2",    "8",    "2",    "2.5",  "9"     }).ToList<string>()	
                    ,(new string[] {"A09)Власть"
                                        ,   "5",    "5",    "10",   "8.5",  "7",    "10"    }).ToList<string>()	
                    ,(new string[] {"A10)Безопасность"
                                        ,   "6",    "6",    "7",    "4",    "4.5",  "2"     }).ToList<string>()	
                }).ToList<List<string>>();
        }
        public static void Test_Data_LLS1()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed))
                .WriteLine((new Component.StackTracer()).Get_STSS());
            (new Component.DataTest_LLS.DataTest_LLS(Component.LLSDataSource.Experimental._001.Data_LLS1().Get_Copy()))
                .Set_p_NeedShowMessageBox(true)
                .Set_p_NeedShowConsole(true)
                .Do()
            ;
        }
        /// <summary>Данныедля эксперимента Ценность родителей/учеников</summary>
        public static List<List<string>> Data_LLS2()
        {
            return (List<List<string>>)
                (new List<string>[] {
                    (new string[] {(new SPExtractor("Name","Experimental._001.LLS2()"))
                        .Set_Param("SoName","Ценности родителей 2")
                        .p_String       ,   "П1_1", "П6_1", "П2_1", "П3_1", "П4_1", "П5_1"  }).ToList<string>()
                    ,(new string[] {"A01)Комфортность"
                                        ,   "9",    "9",    "7",    "4",    "5.5",  "4"     }).ToList<string>()
                    ,(new string[] {"A02)Традиции"
                                        ,   "10",   "10",   "4",    "9",    "7",    "8"     }).ToList<string>()
                    ,(new string[] {"A03)Доброта"
                                        ,   "3",    "3",    "8.5",  "2",    "2.5",  "1"     }).ToList<string>()	
                    ,(new string[] {"A04)Универсализм"
                                        ,   "5",    "5",    "1",    "1",    "8",    "2"     }).ToList<string>()	
                    ,(new string[] {"A05)Самостоятельность"
                                        ,   "2",    "2",    "2",    "5",    "4",    "3"     }).ToList<string>()	
                    ,(new string[] {"A06)Стимуляция"
                                        ,   "1",    "1",    "4",    "7.5",  "9.5",  "6.5"   }).ToList<string>()	
                    ,(new string[] {"A07)Гедонизм"
                                        ,   "8",    "8",    "4",    "7.5",  "9.5",  "5"     }).ToList<string>()	
                    ,(new string[] {"A08)Достижения"
                                        ,   "6",    "6",    "8.5",  "6",    "1",    "9"     }).ToList<string>()	
                    ,(new string[] {"A09)Власть"
                                        ,   "7",    "7",    "10",   "10",   "5.5",  "10"    }).ToList<string>()	
                    ,(new string[] {"A10)Безопасность"
                                        ,   "4",    "4",    "6",    "3",    "2.5",  "6.5"   }).ToList<string>()	
                }).ToList<List<string>>();
        }
        public static void Test_Data_LLS2()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed))
                .WriteLine((new Component.StackTracer()).Get_STSS());

            (new Component.DataTest_LLS.DataTest_LLS(Component.LLSDataSource.Experimental._001.Data_LLS2().Get_Copy()))
                .Set_p_NeedShowMessageBox(true)
                .Set_p_NeedShowConsole(true)
                .Do()
            ;
        }
        /// <summary>Данныедля эксперимента Ценность родителей/учеников</summary>
        public static List<List<string>> Data_LLS3()
        {
            return (List<List<string>>)
                (new List<string>[] {
                    (new string[] {
                        (new SPExtractor("Name","Experimental._001.LLS3()"))
                        .Set_Param("SoName","Ценности родителей 3")
                        .p_String                 ,"Конформность",    "Традиции", "Доброта",  "Универсализм", "Самостоят-ть", "Стимуляция",   "Гедонизм", "Достижения",   "Власть",   "Безопасность"  }).ToList<string>()
                    ,(new string[] {"A01)Гончаренко Игорь"
                        ,"1.5",             "2.75",     "2.5",      "2.33",         "3.25",         "3.67",         "0.67",     "2.00",         "2.00",     "1.6"           }).ToList<string>()
                    ,(new string[] {"A02)Журавлев Г."
                        ,"1",               "1.5",      "4",        "2.17",         "1.5",          "3.00",         "3.00",     "3.00",         "2.33",     "2.8"           }).ToList<string>()
                    ,(new string[] {"A03)Бочкарев И."
                        ,"2.25",            "2.25",     "2.25",     "2.00",         "2.75",         "2.00",         "2.33",     "2.00",         "2.67",     "2.2"           }).ToList<string>()
                    ,(new string[] {"A04)Торбеев Д."
                        ,"1",               "3.5",      "3.5",      "1.33",         "1.25",         "2.67",         "1.67",     "1.75",         "2.00",     "2.8"           }).ToList<string>()
                    ,(new string[] {"A05)Выборнов Н."
                        ,"2",               "2",        "2.5",      "2.50",         "3",            "3.00",         "2.67",     "3.50",         "3.00",     "2"             }).ToList<string>()
                    ,(new string[] {"A06)Тарханов Н."
                        ,"1.75",            "3.5",      "2",        "2.67",         "3",            "2.33",         "2.33",     "2.25",         "2.00",     "1.8"           }).ToList<string>()        
                    ,(new string[] {"A07)Першин Н."
                        ,"1.25",            "2",        "1.75",     "2.17",         "2.25",         "2.67",         "2.00",     "1.50",         "0.67",     "2"             }).ToList<string>()
                    ,(new string[] {"A08)Титов Г."
                        ,"2.75",            "3.25",     "2.75",     "2.50",         "2.25",         "3.00",         "3.00",     "3.00",         "3.67",     "3"             }).ToList<string>()
                    ,(new string[] {"A09)Ашырглыжов А."
                        ,"3.25",            "1.75",     "2.75",     "1.00",         "3",            "2.33",         "2.67",     "1.50",         "2.33",     "2.4"           }).ToList<string>()
                    ,(new string[] {"A10)Вишневецкий М."
                        ,"1.75",            "2",        "2",        "1.17",         "1.75",         "3.00",         "2.00",     "3.00",         "2.67",     "2"             }).ToList<string>()
                    ,(new string[] {"A11)Леонов С."
                        ,"2.75",            "1.75",     "1.75",     "1.83",         "3",            "2.33",         "2.00",     "0.50",         "1.67",     "2.2"           }).ToList<string>()
                    ,(new string[] {"A12)Кращенко Д."
                        ,"3.5",             "2.5",      "3",        "2.83",         "2",            "1.00",         "1.67",     "4.00",         "3.00",     "3"             }).ToList<string>()
                    ,(new string[] {"A13)Пудахин А."
                        ,"3.5",             "1.5",      "2.25",     "3.50",         "2.25",         "3.67",         "2.67",     "2.50",         "2.00",     "3.2"           }).ToList<string>()
                    ,(new string[] {"A14)Константинов С."
                        ,"2.25",            "2.75",     "2.5",      "3.17",         "2.75",         "1.33",         "1.33",     "1.00",         "3.00",     "3"             }).ToList<string>()
                    ,(new string[] {"A15)Соколов П."
                        ,"2",               "2.25",     "2.25",     "0.17",         "1",            "2.00",         "2.00",     "0.25",         "3.33",     "1.8"           }).ToList<string>()
                    ,(new string[] {"A16)Петров М."
                        ,"2.25",            "3.25",     "2",        "2.83",         "3",            "3.33",         "1.33",     "2.00",         "2.33",     "1.4"           }).ToList<string>()
                    ,(new string[] {"A17)Берш Л."
                        ,"1.75",            "1.75",     "1",        "2.67",         "3.75",         "3.67",         "1.33",     "3.50",         "3.00",     "1.2"           }).ToList<string>()
                    ,(new string[] {"A18)Коновалов С."
                        ,"1.5",             "2.5",      "2.5",      "3.50",         "2.5",          "2.00",         "2.67",     "2.50",         "2.67",     "3.2"           }).ToList<string>()
                    ,(new string[] {"A19)Кондиков А."
                        ,"2.5",             "1.75",     "2.5",      "2.33",         "2.75",         "1.67",         "3.00",     "3.00",         "1.00",     "3.2"           }).ToList<string>()
                    ,(new string[] {"A20)Ставицкий П."
                        ,"1.75",            "3",        "3.5",      "2.50",         "3.25",         "3.00",         "2.00",     "2.25",         "1.67",     "2.6"           }).ToList<string>()
                    ,(new string[] {"A21)Данилов А."
                        ,"2.75",            "3.25",     "2.25",     "1.67",         "2.5",          "2.67",         "2.33",     "2.75",         "3.33",     "1.8"           }).ToList<string>()
                    ,(new string[] {"A22)Крымкин К."
                        ,"3",               "2.5",      "3.5",      "2.00",         "2",            "3.33",         "2.00",     "1.75",         "2.67",     "3.4"           }).ToList<string>()
                    ,(new string[] {"A23)Пахомкин Е."
                        ,"2.75",            "3.25",     "2",        "2.00",         "2.5",          "2.67",         "2.00",     "0.50",         "2.00",     "2.8"           }).ToList<string>()
                    ,(new string[] {"A24)Храмов А."
                        ,"2.75",            "1.25",     "2.5",      "1.50",         "2",            "1.00",         "3.67",     "0.50",         "0.67",     "2"             }).ToList<string>()
                    ,(new string[] {"A25)Тарасов Д."
                        ,"1.5",             "2.75",     "2.5",      "2.33",         "3.25",         "3.67",         "0.67",     "2.00",         "2.00",     "1.6"           }).ToList<string>()
                    ,(new string[] {"A26)Сенгатуллова Ю."
                        ,"1",               "1.5",      "4",        "2.17",         "1.5",          "3.00",         "3.00",     "3.00",         "2.33",     "2.8"           }).ToList<string>()
                    ,(new string[] {"A27)Пайдутова В."
                        ,"2.25",            "2.25",     "2.25",     "2.00",         "2.75",         "2.00",         "2.33",     "2.00",         "2.67",     "2.2"           }).ToList<string>()
                    ,(new string[] {"A28)Гайнуллина А."
                        ,"1",               "3.5",      "3.5",      "1.33",         "1.25",         "2.67",         "1.67",     "1.75",         "2.00",     "2.8"           }).ToList<string>()
                    ,(new string[] {"A29)Чистова А."
                        ,"2",               "2",        "2.5",      "2.50",         "3",            "3.00",         "2.67",     "3.50",         "3.00",     "2"             }).ToList<string>()
                    ,(new string[] {"A30)Анисимова Д."
                        ,"1.75",            "3.5",      "2",        "2.67",         "3",            "2.33",         "2.33",     "2.25",         "2.00",     "1.8"           }).ToList<string>()
                    ,(new string[] {"A31)Богданова А."
                        ,"1.25",            "2",        "1.75",     "2.17",         "2.25",         "2.67",         "2.00",     "1.50",         "0.67",     "2"             }).ToList<string>()
                    ,(new string[] {"A32)Угланова Е."
                        ,"2.75",            "3.25",     "2.75",     "2.50",         "2.25",         "3.00",         "3.00",     "3.00",         "3.67",     "3"             }).ToList<string>()
                    ,(new string[] {"A33)Петренко Е."
                        ,"3.25",            "1.75",     "2.75",     "1.00",         "3",            "2.33",         "2.67",     "1.50",         "2.33",     "2.4"           }).ToList<string>()
                    ,(new string[] {"A34)Фалкина В."
                        ,"1.75",            "2",        "2",        "1.17",         "1.75",         "3.00",         "2.00",     "3.00",         "2.67",     "2"             }).ToList<string>()
                    ,(new string[] {"A35)Панчайкина Э."
                        ,"2.75",            "1.75",     "1.75",     "1.83",         "3",            "2.33",         "2.00",     "0.50",         "1.67",     "2.2"           }).ToList<string>()
                    ,(new string[] {"A36)Петров Е."
                        ,"3.5",             "2.5",      "3",        "2.83",         "2",            "1.00",         "1.67",     "4.00",         "3.00",     "3"             }).ToList<string>()
                    ,(new string[] {"A37)Тарасова Е."
                        ,"3.5",             "1.5",      "2.25",     "3.50",         "2.25",         "3.67",         "2.67",     "2.50",         "2.00",     "3.2"           }).ToList<string>()
                    ,(new string[] {"A38)Жаркова М."
                        ,"2.25",            "2.75",     "2.5",      "3.17",         "2.75",         "1.33",         "1.33",     "1.00",         "3.00",     "3"             }).ToList<string>()
                    ,(new string[] {"A39)Кузина А."
                        ,"2",               "2.25",     "2.25",     "0.17",         "1",            "2.00",         "2.00",     "0.25",         "3.33",     "1.8"           }).ToList<string>()
                    ,(new string[] {"A40)Костина С."
                        ,"2.25",            "3.25",     "2",        "2.83",         "3",            "3.33",         "1.33",     "2.00",         "2.33",     "1.4"           }).ToList<string>()
                    ,(new string[] {"A41)Узбекова Е."
                        ,"1.75",            "1.75",     "1",        "2.67",         "3.75",         "3.67",         "1.33",     "3.50",         "3.00",     "1.2"           }).ToList<string>()
                    ,(new string[] {"A42)Захарова М."
                        ,"1.5",             "2.5",      "2.5",      "3.50",         "2.5",          "2.00",         "2.67",     "2.50",         "2.67",     "3.2"           }).ToList<string>()
                    ,(new string[] {"A43)Ильенко И."
                        ,"2.5",             "1.75",     "2.5",      "2.33",         "2.75",         "1.67",         "3.00",     "3.00",         "1.00",     "3.2"           }).ToList<string>()
                    ,(new string[] {"A44)Кондрашова Д."
                        ,"1.75",            "3",        "3.5",      "2.50",         "3.25",         "3.00",         "2.00",     "2.25",         "1.67",     "2.6"           }).ToList<string>()
                    ,(new string[] {"A45)Ключевская Ю."
                        ,"2.75",            "3.25",     "2.25",     "1.67",         "2.5",          "2.67",         "2.33",     "2.75",         "3.33",     "1.8"           }).ToList<string>()
                    ,(new string[] {"A46)Осипова М."
                        ,"3",               "2.5",      "3.5",      "2.00",         "2",            "3.33",         "2.00",     "1.75",         "2.67",     "3.4"           }).ToList<string>()
                    ,(new string[] {"A47)Чкадуа Л."
                        ,"2.75",            "3.25",     "2",        "2.00",         "2.5",          "2.67",         "2.00",     "0.50",         "2.00",     "2.8"           }).ToList<string>()
                    ,(new string[] {"A48)Чечина Д."
                        ,"2.75",            "1.25",     "2.5",      "1.50",         "2",            "1.00",         "3.67",     "0.50",         "0.67",     "2"             }).ToList<string>()
                    ,(new string[] {"A49)Солдатова В."
                        ,"3.5",             "2.5",      "3",        "2.83",         "2",            "1.00",         "1.67",     "4.00",         "3.00",     "3"             }).ToList<string>()
                    ,(new string[] {"A50)Русова П."
                        ,"2",               "2",        "2.5",      "2.50",         "3",            "3.00",         "2.67",     "3.50",         "3.00",     "2"             }).ToList<string>()
                    ,(new string[] {"A51)Литвинова К."
                        ,"2.00",            "1.50",     "3.00",     "1.17",         "2.25",         "1.00",         "1.00",     "3.50",         "2.00",     "3.00"          }).ToList<string>()
                    ,(new string[] {"A52)Хан Е."
                        ,"1.75",            "0.25",     "3.25",     "3.00",         "2.75",         "1.00",         "1.33",     "0.00",         "-0.67",    "1.00"          }).ToList<string>()
                }).ToList<List<string>>();
        }
        public static void Test_Data_LLS3()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed))
                .WriteLine((new Component.StackTracer()).Get_STSS());

            (new Component.DataTest_LLS.DataTest_LLS(Component.LLSDataSource.Experimental._001.Data_LLS3().Get_Copy()))
                .Set_p_NeedShowMessageBox(true)
                .Set_p_NeedShowConsole(true)
                .Do()
            ;
        }
        public static void Test_OLL_Experimental_001_Data_()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed))
                .WriteLine((new Component.StackTracer()).Get_STSS());

            Console.WriteLine("\nTest_Resalt_ Component.LLSDataSource.Experimental._001.Data_LLS1=" +
                Convert.ToString(
                    (new Component.DataTest_LLS.DataTest_LLS(Component.LLSDataSource.Experimental._001.Data_LLS1()))
                    .Set_p_NeedShowMessageBox(false).Set_p_NeedShowConsole(false).GetResalt().p_Resalt
                )
            );
            Console.WriteLine("\nTest_Resalt_ Component.LLSDataSource.Experimental._001.Data_LLS2=" +
                Convert.ToString((new Component.DataTest_LLS.DataTest_LLS(Component.LLSDataSource.Experimental._001.Data_LLS2()))
                    .Set_p_NeedShowMessageBox(false).Set_p_NeedShowConsole(false).GetResalt().p_Resalt
                )
            );
            Console.WriteLine("\nTest_Resalt_ Component.LLSDataSource.Experimental._001.Data_LLS3=" +
                Convert.ToString((new Component.DataTest_LLS.DataTest_LLS(Component.LLSDataSource.Experimental._001.Data_LLS3()))
                    .Set_p_NeedShowMessageBox(false).Set_p_NeedShowConsole(false).GetResalt().p_Resalt
                )
            );
            
        }
    }
}