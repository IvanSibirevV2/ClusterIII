using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace TP_ClusterIII
{
    [TestClass]
    public class UT_Standart_Super_Small_DataTest
    {
        /*
        [TestMethod]
        public void TM_Super_Small_DataTest_1(){Assert.IsTrue(new ClusterIII.Data.Standart.Super_Small().DataTest_1());}
        [TestMethod]
        public void TM_Super_Small_DataTest_1_Fail() {Assert.IsFalse((new ClusterIII.Data.Standart.Super_Small()).Set(a=> a.p_LLS[2].RemoveAt(2)).DataTest_1()) ; }
        [TestMethod]
        public void TM_Super_Small_DataTest_2() { Assert.IsTrue(new ClusterIII.Data.Standart.Super_Small().DataTest_2()); }
        [TestMethod]
        public void TM_Super_Small_DataTest_2_Fail() 
        {
            Assert.IsFalse((new ClusterIII.Data.Standart.Super_Small()).Set(a => a.p_LLS[2].RemoveAt(2)).DataTest_1()); 
        }

        [TestMethod]
        public void TM_Super_Small_DataTest_3() { Assert.IsTrue(new ClusterIII.Data.Standart.Super_Small().DataTest_3()); }
        [TestMethod]
        public void TM_Super_Small_DataTest_3_Fail() 
        {
            Assert.IsFalse((new ClusterIII.Data.Standart.Super_Small()).Set(a => a.p_LLS[2].RemoveAt(2)).DataTest_1());
        }
        */
        [TestMethod]
        public void TM_Super_Small_DataTest_All() { Assert.IsTrue(new ClusterIII.Data.Standart.Super_Small().DataTest_All()); }
    }
}
