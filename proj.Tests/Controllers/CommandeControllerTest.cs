using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using proj.Controllers;
using proj.Models;
using proj.Service;

namespace proj.Tests.Controllers
{
    [TestClass]
    public class CommandeControllerTest
    {

        ICommande _stub;

        public CommandeControllerTest()
        {
            _stub = Substitute.For<ICommande>();
        }

        [TestMethod]
        public void TestIndex()
        {
            List<Commande> list = new List<Commande>();
            list.Add(new Commande());
            _stub.FIndAll().Returns(list);

            var x = new CommandesController(_stub);

            ViewResult v = x.Index() as ViewResult;
            IEnumerable<Commande> l = (IEnumerable<Commande>)v.ViewData.Model;

            CollectionAssert.AreEqual(list, (List<Commande>)l);
        }

        [TestMethod]
        public void TestReturnIndex()
        {
            List<Commande> list = new List<Commande>();
            list.Add(new Commande());
            _stub.FIndAll().Returns(list);

            var x = new CommandesController(_stub);

            ViewResult v = x.Index() as ViewResult;
            Assert.AreEqual(v.ViewName, "Index");
        }
    }
}
