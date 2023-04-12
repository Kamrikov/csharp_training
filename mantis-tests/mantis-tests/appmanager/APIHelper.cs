using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Firefox;
using mantis_tests.Mantis;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }
    public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            issue.category = issueData.Category;
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            client.mc_issue_add(account.Username, account.Password, issue);
        }
    }
}
