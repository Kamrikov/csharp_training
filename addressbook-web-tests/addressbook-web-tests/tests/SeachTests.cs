﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class SeachTests : AuthTestBase
    {
        [Test]
        public void TestSearch()
        {
            System.Console.Out.Write(app.Contacts.GetNumberOfSearchResults());
            /*
            MyClass myClass = new MyClass();
            myClass.a = "попытка1";
            myClass.b = "попытка2";
            string c = "";
            foreach (PropertyInfo prop in typeof(MyClass).GetProperties())
            {
                System.Console.Out.Write("{0} = {1}", prop.Name, prop.GetValue(myClass, null));
                System.Console.Out.Write(app.Contacts.GetNumberOfSearchResults());
                c = c + prop.GetValue(myClass, null);
            }

            */
            System.Console.Out.Write(6);
        }
    }
}
