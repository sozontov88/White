using System;
using System.Collections.Generic;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.WindowsAPI;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using System.Windows.Automation;

namespace address_book_test_white
{
    public class GroupHelper:HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public GroupHelper(ApplicationManager manager):base (manager) 
        { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();  
            Window dialogue = OpenGroupsDialoge();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView"); //находим дерево елементов
            TreeNode root = tree.Nodes[0];  //элемент с 0 индексом
            foreach(TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                });
            }
                 
            CloseGroupsDialogue(dialogue);
            return new List<GroupData>();
        }

        public void Add(GroupData newGroup)
        {
            Window dialogue = OpenGroupsDialoge();
            dialogue.Get<Button>("uxNewAddressButton").Click();
            TextBox textbox = (TextBox)dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textbox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
           
            CloseGroupsDialogue(dialogue);
        }

        private void CloseGroupsDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxCloseAddressButton").Click();
           
        }

        private Window OpenGroupsDialoge()
        {

            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }
    }
}