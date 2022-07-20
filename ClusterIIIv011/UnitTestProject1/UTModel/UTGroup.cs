using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClusterIII.Model;
using System.Collections.Generic;


namespace UnitTestProject1.UTModel
{
    [TestClass]
    public class UTGroup
    {
        /// <summary>
        /// Метод тестирования класса Group
        /// </summary>
        [TestMethod]
        public void GroupUT()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n";
            // arrange            
            Group Expected = new Group();
            Expected.Name = "TestName";
            Expected.GParamList = new List<Param>();
            // act
            Group Input = new Group(Expected.Name,Expected.GParamList);
            // assert
            Assert.AreEqual(Expected.Name, Input.Name, ErrorMessage + Convert.ToString(Input.GetType()) + ".Name");
            Assert.AreEqual(Expected.GParamList, Input.GParamList, ErrorMessage + Convert.ToString(Input.GetType()) + ".GParamList");
        }

        /// <summary>
        /// Метод тестирования Group.FaceClone()
        /// </summary>
        [TestMethod]
        public void Group_FaceClone_MethodUT()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n";
            // arrange            
            Group Expected = new Group();
            Expected.Name = "TestName";
            Expected.GParamList = new List<Param>();
            // act
            Group Input = Expected.FaceClone();            
            // assert
            Assert.AreEqual(Expected.Name, Input.Name, ErrorMessage + Convert.ToString(Input.GetType()) + " .FaceClone() .Name");
            Assert.AreEqual(Expected.GParamList.Count, Input.GParamList.Count, ErrorMessage + Convert.ToString(Input.GetType()) + ".FaceClone() .GParamList.Count");
            Assert.AreNotEqual(Expected, Input, ErrorMessage + Convert.ToString(Input.GetType()) + ".FaceClone()");
        }

       
    }
}
