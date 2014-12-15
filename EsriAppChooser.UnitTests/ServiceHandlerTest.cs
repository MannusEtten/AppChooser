using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EsriApplicationChooser;

namespace EsriAppChooser.UnitTests
{
    [TestClass]
    public class ServiceHandlerTest
    {
        private ServiceHandler _handle;

        [TestInitialize]
        public void Setup()
        {
        }

        [TestMethod]
        public void Handle_With_Invalid_Service_Name_Doesnt_Give_Exception()
        {
            _handle = new ServiceHandler();
            _handle.Handle("Mannus");
        }
    }
}
