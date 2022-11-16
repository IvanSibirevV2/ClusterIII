using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace TP_ClusterIII
{
    [TestClass]
    public class UT_Standart_Super_Big_DataTest
    {
        [TestMethod]
        public void TM_Super_Small_DataTest_1(){Assert.IsTrue(new ClusterIII.Data.Standart.Super_Big().DataTest_1());}
        [TestMethod]
        public void TM_Super_Small_DataTest_1_Fail() {Assert.IsFalse((new ClusterIII.Data.Standart.Super_Big()).Set(a=> a.p_LLS[2].RemoveAt(2)).DataTest_1()) ; }
        [TestMethod]
        public void TM_Super_Small_DataTest_2() 
        {
            Assert.IsTrue(
                new ClusterIII.Data.Standart.Super_Big()
                .Set(_LLS: new System.Collections.Generic.List<System.Collections.Generic.List<string>>()
                    .Set_Add(new List<string>() { "À00", "Ï1", "Ï2", "Ï3", "Ï4", "Ï5" })
                    .Set_Add(new List<string>() { "À01", "1"})
                    .Set_Add(new List<string>() { "À02", "1", "1", "0", "0", "1" })
                    .Set_Add(new List<string>() { "À03", "1", "1", "0", "0", "0" })
                    .Set_Add(new List<string>() { "À04", "1", "0", "0", "0", "0" })
                    .Set_Add(new List<string>() { "À05", "1", "1", "0", "1", "1" })
                    .Set_Add(new List<string>() { "À06", "0", "0", "0", "0", "0" })
                    .Set_Add(new List<string>() { "À07", "1", "0", "0", "1", "1" })
                    .Set_Add(new List<string>() { "À08", "1", "1", "0", "0", "1" })
                    .Set_Add(new List<string>() { "À09", "1", "1", "1", "1", "1" })
                    .Set_Add(new List<string>() { "À10", "1", "0", "0", "1", "1" })
                )
                .DataTest_2()
            );
        }
        [TestMethod]
        public void TM_Super_Small_DataTest_3() { Assert.IsTrue(new ClusterIII.Data.Standart.Super_Big().DataTest_3()); }
        [TestMethod]
        public void TM_Super_Small_DataTest_All() { Assert.IsTrue(new ClusterIII.Data.Standart.Super_Big().DataTest_All()); }
    }
}
