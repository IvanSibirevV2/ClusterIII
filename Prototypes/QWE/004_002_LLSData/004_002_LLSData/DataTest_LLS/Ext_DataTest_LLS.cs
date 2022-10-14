using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///////////////////////////////////////////////
using Component.DataTest_LLS;

namespace Component
{
    public static class Extension_DataTest_LLS
    {
        public static bool LLS_DataTest_(this List<List<string>> _LLS){return _LLS.LLS_DataTest_(true);}
        public static bool LLS_DataTest_(this List<List<string>> _LLS, bool _NeedDataTest)
        {
            Component.DataTest_LLS.IDataTest_LLS _ILLS_DataTest = (new Component.DataTest_LLS.DataTest_LLS())
                    .Set_p_LLS(_LLS.Get_Copy())
                    //.Set_p_NeedShowConsole(false)
                    .Set_p_NeedShowMessageBox(false)
                    .Set_p_NeedTest(true && _NeedDataTest)
                    ;
            if (_ILLS_DataTest.p_NeedTest)
            {
                bool _res = _ILLS_DataTest.Get_InterfaceCopy().Set_p_NeedShowConsole(false).Do().GetResalt().p_Resalt;//дЛЯ ТОГО ЧТОБЫ УЗНАТЬ, ВСЁ ЛИ ВПОРЯДКЕ
                if (!_res) _ILLS_DataTest.Get_InterfaceCopy().Set_p_NeedShowConsole(true).Do();//дЛЯ ТОГО ЧТОБЫ ВЫВЕСТИ НА ЭКРАН, и УЗНАТЬ В КАКОМ  ТЕСТЕ  fAiL
                return _res;
            }
            return true;
        }
    }
}
