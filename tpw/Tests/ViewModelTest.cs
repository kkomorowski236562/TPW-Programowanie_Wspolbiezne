﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel;

namespace Tests
{
    [TestClass]
    public class ViewModelTest
    {
        private PoolViewModel ViewModel = new();

        [TestMethod]
        public void CountTest()
        {
            Assert.AreEqual(ViewModel.Balls.Count, 0);
        }
        [TestMethod]
        public void HeightTest()
        {
            Assert.AreEqual(ViewModel.WindowHeight, 640);
        }
        [TestMethod]
        public void WidthTest()
        {
            Assert.AreEqual(ViewModel.WindowWidth, 1230);
        }


    }
}