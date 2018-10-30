using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace address_book_test_white
{
  public  class TestBase
    {
      public  ApplicationManager app;

        [TestFixtureSetUp]
        public void Initialisation()
        {
            app = new ApplicationManager();
        }

        [TestFixtureTearDown]
        public void stopApplication()
        {
            app.Stop();
        }
    }
}
