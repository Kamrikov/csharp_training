using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [SetUpFixture]
    public class TestSuitFixture
    {
        [SetUp]
        public void InitApplicationManager() 
        {
            ApplicationManager app = ApplicationManager.GetInstance();
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }
        [TearDown]
        public void StopApplicationManager() // После Лекции 3.2 этого метода не должно быть
        {
            ApplicationManager.GetInstance().Stop();
        }
    }
}
