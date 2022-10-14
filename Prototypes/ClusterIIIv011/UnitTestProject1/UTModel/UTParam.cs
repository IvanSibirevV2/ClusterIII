using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClusterIII.Model;

namespace UnitTestProject1.UTModel
{    
    [TestClass]
    public class UTParam
    {
        /// <summary>
        /// Метод тестирования класса Param
        /// </summary>
        [TestMethod]
        public void ParamUT()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n";

            // arrange            
            Param Expected = new Param();
            Expected.Name = "TestName";
            Expected.P=new double();
            // act
            Param Input = new Param(Expected.Name, Expected.P);
            // assert
            Assert.AreEqual( Expected.Name  , Input.Name   , ErrorMessage + Convert.ToString( Input.GetType() ) + ".Name");
            Assert.AreEqual( Expected.P     , Input.P      , ErrorMessage + Convert.ToString( Input.GetType() ) + ".P"   );
        }
        /// <summary>
        /// Метод тестирования класса Param.FaceClone()
        /// </summary>
        [TestMethod]
        public void Param_FaceClone_MethodUT()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n";
            // arrange            
            Param Expected = new Param("TestName", new double()); ;            
            // act
            Param Input = Expected.FaceClone();            
            // assert
            Assert.AreEqual(Expected.Name, Input.Name, ErrorMessage + Convert.ToString(Input.GetType()) + " .FaceClone() .Name");
            Assert.AreEqual(Expected.P, Input.P, ErrorMessage + Convert.ToString(Input.GetType()) + ".FaceClone() .P");
            Assert.AreNotEqual(Expected, Input, ErrorMessage + Convert.ToString(Input.GetType()) + ".FaceClone()");
        }
    }
}
