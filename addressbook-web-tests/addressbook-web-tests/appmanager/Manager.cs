using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;

namespace addressbook_web_tests.appmanager
{
    public class Manager : AuthTestBase
    {
        [Test]
        public void Method()
        {
            MyClass myClass = new MyClass();
            myClass.a = "попытка1";
            myClass.b = "попытка2";
            foreach (PropertyInfo prop in typeof(MyClass).GetProperties())
            {
                System.Console.Out.Write("{0} = {1}", prop.Name, prop.GetValue(myClass, null));
                System.Console.Out.Write(app.Contacts.GetNumberOfSearchResults());

            }
        }
    }
}
