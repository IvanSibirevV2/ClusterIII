using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClusterIII.Model;
using System.Collections.Generic;

namespace UnitTestProject1.UTModel
{
    [TestClass]
    public class UTCluster
    {
        /// <summary>
        /// Метод тестирования класса Cluster
        /// </summary>
        [TestMethod]
        public void ClusterUT()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n";
            // arrange      
                Cluster Expected = new Cluster();
                Expected.Name = "TestName";
                Expected.CGroupList= new List<Group>();
                Expected.SCluster = new List<Cluster>();
            
            // act
            Cluster Input = new Cluster(Expected.Name, Expected.CGroupList, Expected.SCluster);
            // assert
            Assert.AreEqual(Expected.Name, Input.Name, ErrorMessage + Convert.ToString(Input.GetType()) + ".Name");
            Assert.AreEqual(Expected.CGroupList, Input.CGroupList, ErrorMessage + Convert.ToString(Input.GetType()) + ".CGroupList");
            Assert.AreEqual(Expected.SCluster, Input.SCluster, ErrorMessage + Convert.ToString(Input.GetType()) + ".SCluster");
        }

        /// <summary>
        /// Метод тестирования класса Cluster.FaceClone()
        /// </summary>
        [TestMethod]
        public void Cluster_FaceClone_MethodUT()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n";
            // arrange            
            Cluster Expected = new Cluster("TestName", new List<Group>(), new List<Cluster>());            
            // act
            Cluster Input = Expected.FaceClone();            
            // assert            
            Assert.AreEqual(Expected.Name, Input.Name, ErrorMessage + Convert.ToString(Input.GetType()) + " .FaceClone() .Name");
            Assert.AreEqual(Expected.CGroupList.Count, Input.CGroupList.Count, ErrorMessage + Convert.ToString(Input.GetType()) + ".FaceClone() .CGroupList.Count");
            Assert.AreEqual(Expected.SCluster.Count, Input.SCluster.Count, ErrorMessage + Convert.ToString(Input.GetType()) + ".FaceClone() .SCluster.Count");
            Assert.AreNotEqual(Expected, Input, ErrorMessage + Convert.ToString(Input.GetType()) + ".FaceClone()");
        }

        /// <summary>
        /// Метод тестирования класса Cluster.FaceClone()
        /// </summary>
        [TestMethod]
        public void Cluster_SameFaceClone_MethodUT()
        {
            
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n";
            // arrange            

            Cluster Input = new Cluster("TestName", new List<Group>(new Group[2]), new List<Cluster>(new Cluster[2]));            
            // act
            Input=Input.SameFaceClone();
            
            
         
            // assert            
            Assert.AreEqual(Input.SCluster[0].Name, Input.Name, ErrorMessage + Convert.ToString(Input.GetType()) + " .FaceClone() .Name");
            /*
            Assert.AreEqual(Expected.Name, Input.Name, ErrorMessage + Convert.ToString(Input.GetType()) + " .FaceClone() .Name");
            Assert.AreEqual(Expected.CGroupList.Count, Input.CGroupList.Count, ErrorMessage + Convert.ToString(Input.GetType()) + ".FaceClone() .CGroupList.Count");
            Assert.AreNotEqual(Expected.SCluster.Count, Input.SCluster.Count, ErrorMessage + Convert.ToString(Input.GetType()) + ".FaceClone() .SCluster.Count");
            Assert.AreNotEqual(Expected, Input, ErrorMessage + Convert.ToString(Input.GetType()) + ".SCluster()");
            */
        }

        /// <summary>
        /// Метод тестирования класса Cluster.Add()
        /// </summary>
        [TestMethod]
        public void Cluster_Add_MethodUT()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n";
            // arrange            
            Cluster Input = new Cluster("TestName", new List<Group>(), new List<Cluster>(new Cluster[10]));            
            // act
            Input.SCluster.Add(new Cluster());
            // assert            
            Assert.AreEqual(11, Input.SCluster.Count, ErrorMessage + Convert.ToString(Input.GetType()) + "Add()");            
        }
        
        /// <summary>
        /// Метод тестирования класса Cluster.RemoveAt()
        /// </summary>
        [TestMethod]
        public void Cluster_RemoveAt_MethodUT()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n";
            // arrange            
            Cluster Input = new Cluster("TestName", new List<Group>(), new List<Cluster>(new Cluster[10]));
            // act
            Input.SCluster.RemoveAt(0);
            // assert            
            Assert.AreEqual(9, Input.SCluster.Count, ErrorMessage + Convert.ToString(Input.GetType()) + "Add()");
        }

        /// <summary>
        /// Метод тестирования класса Cluster.StandartCenterReloader()
        /// </summary>
        [TestMethod]
        public void Cluster_StandartCenterReloader_MethodUT()
        {
            
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n";
            // arrange            
            Param[] LocalParam = { new Param("", 1), new Param("", 1) };
            Group[] LocalGroup = { new Group("", new List<Param>(LocalParam)), new Group("", new List<Param>(LocalParam)) };
            Cluster Input = new Cluster("TestName", new List<Group>(LocalGroup), new List<Cluster>(new Cluster[10]));            
            Input.SameFaceClone();

            // act
            
            Input.StandartCenterReloader();
            double Expected=0;//= Input.CGroupList[0].GParamList[0].P;
            // assert            
            Assert.AreEqual(Expected, 3, ErrorMessage + Convert.ToString(Input.GetType()) + "Add()");
        }
        
        

    }
}
