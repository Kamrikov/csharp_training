using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        { 
        }
        public ContactHelper Create(ContactData contact)
        {
            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();

            manager.Navigator.ReturnToHomePage();
            return this;
        }
        public ContactHelper Modify(ContactData newData)
        {
            SelectContact();
            InitContactModification();
            FillContactForm(newData);
            SubmitContactModification();

            manager.Navigator.ReturnToHomePage();
            return this;
        }
        public ContactHelper Remove()
        {
            SelectContact();
            RemoveContact();
            return this;
        }
        public ContactHelper SelectContact()
        {
            driver.FindElement(By.XPath("//td/input")).Click();
            return this;
        }
        public void InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            return this;
        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactHelper CheckForContact()
        {
            if (!IsElementPresent(By.XPath("//td/input")))
            {
                ContactData contact = new ContactData("НетКонтактов", "НетКонтактов");
                Create(contact);
            }
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name=entry]"));
            foreach (IWebElement element in elements)
            {
                contacts.Add(new ContactData(element.Text, element.Text));
            }
            return contacts;
        }
    }
}
