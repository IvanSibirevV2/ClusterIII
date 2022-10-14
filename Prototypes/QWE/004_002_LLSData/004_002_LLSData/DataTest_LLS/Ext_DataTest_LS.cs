using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///////////////////////////////////////////
using Component;

namespace Component
{
    public static  class Extension_DataTest_LS
    {
        public static bool LSDataTest(this List<string> _ls)
        {
            Component.DataTest_LLS.IDataTest_LLS _ILLS_DataTest = (new Component.DataTest_LLS.DataTest_LLS()).Set_p_NeedTest(true);
            if (_ILLS_DataTest.p_NeedTest)
            {
                List<List<string>> _lls = new List<List<string>>();
                _lls.Add(_ls.Get_Copy()); _lls.Add(_ls.Get_Copy());
                for (int i = 0; i < _lls[0].Count; i++)
                    _lls[0][i] = "П" + Convert.ToString(i);
                _lls[0][0] += ";";
                if (_ILLS_DataTest.Set_p_LLS(_lls.Get_Copy()).p_NeedTest)
                {
                    bool _res = _ILLS_DataTest.Get_InterfaceCopy().Set_p_NeedShowConsole(false).Do().GetResalt().p_Resalt;//дЛЯ ТОГО ЧТОБЫ УЗНАТЬ, ВСЁ ЛИ ВПОРЯДКЕ
                    if (!_res) _ILLS_DataTest.Get_InterfaceCopy().Set_p_NeedShowConsole(true).Do();//дЛЯ ТОГО ЧТОБЫ ВЫВЕСТИ НА ЭКРАН, и УЗНАТЬ В КАКОМ  ТЕСТЕ  fAiL
                    return _res;
                }
            }
            return true;
        }
    }
}
