using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace address_book_test_white
{
    [TestFixture]
    public class GroupCreationTest: TestBase
    {
        [Test]
        public void TestGropCreation()
        {
            List<GroupData> oldgroup = app.Groups.GetGroupList();
            GroupData newGroup = new GroupData()
            {
                Name = "White"
            };
            app.Groups.Add(newGroup);
            
            List<GroupData> newgroup = app.Groups.GetGroupList();
            oldgroup.Add(newGroup);
            oldgroup.Sort();
            newgroup.Sort();
            Assert.AreEqual(oldgroup, newgroup);
        }
    }
}
