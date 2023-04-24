using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;
using TestStack.White.ScreenMap;
using System.Windows.Automation;
using TestStack.White.UIItems.PropertyGridItems;

namespace addressbook_tests_white
{
    public class ContactHelper : HelperBase
    {
        public static string CONTACTWINTITLE = "Contact Editor";
        public ContactHelper(ApplicationManager manager) : base(manager) { }
        public List<ContactData> GetContactList()
        {
            List<ContactData> list = new List<ContactData>();

            PropertyGridElementFinder tree = manager.MainWindow.Get<PropertyGridElementFinder>("uxAddressGrid");
            TreeNode root = tree.Nodes[0];

            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new ContactData()
                {
                    FirstName = item.Text
                });
            }
            return list;
        }
        public void Add(ContactData newContact)
        {
            Window dialogue = OpenContactDialogue();

            TextBox textBox = (TextBox)dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newContact.FirstName);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);

            SaveCloseContactDialogue(dialogue);
        }
        private Window OpenContactDialogue()
        {
            manager.MainWindow.Get<Button>("uxNewAddressButton").Click();
            return manager.MainWindow.ModalWindow(CONTACTWINTITLE);
        }
        private void SaveCloseContactDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxSaveAddressButton").Click();
        }
    }
}
