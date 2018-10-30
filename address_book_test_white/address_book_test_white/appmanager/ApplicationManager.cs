﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace address_book_test_white
{
    public class ApplicationManager
    {
        public static string WinTitle = "Free Address Book";
        private GroupHelper grouphelper;
        public ApplicationManager()
        {
            Application app = Application.Launch(@"c:\Program Files (x86)\GAS Softwares\Free Address Book\AddressBook.exe");
            MainWindow= app.GetWindow(WinTitle);
           
            grouphelper = new GroupHelper(this);
        }
        public void Stop()
        {
            MainWindow.Get<Button>("uxExitAddressButton").Click();
           
        }
        public GroupHelper Groups
        {
            get { return grouphelper; }

        }
        public Window MainWindow { get; private set; }
        
    }
}
