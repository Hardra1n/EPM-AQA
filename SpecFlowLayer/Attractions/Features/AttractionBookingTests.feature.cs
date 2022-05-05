﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SpecFlowLayer.Attractions.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("AttractionBookingTests")]
    [NUnit.Framework.CategoryAttribute("UITest")]
    public partial class AttractionBookingTestsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "UITest"};
        
#line 1 "AttractionBookingTests.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Attractions/Features", "AttractionBookingTests", null, ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Change DateTime")]
        [NUnit.Framework.TestCaseAttribute("New", null)]
        public void ChangeDateTime(string search, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("search", search);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Change DateTime", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 4
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
 testRunner.Given("booking page is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 6
 testRunner.When("attractions page is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 7
 testRunner.And(string.Format("enter {0} search string", search), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 8
 testRunner.And("choose cruise result", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 9
 testRunner.And("get date time values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 10
 testRunner.And("choose date time", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 11
 testRunner.And("get date time values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 12
 testRunner.Then("datetime should be not equivalent", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Choose ticket")]
        [NUnit.Framework.TestCaseAttribute("New", "/book", null)]
        public void ChooseTicket(string search, string urlPart, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("search", search);
            argumentsOfScenario.Add("urlPart", urlPart);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Choose ticket", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 18
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 19
 testRunner.Given("booking page is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 20
 testRunner.When("attractions page is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 21
 testRunner.And(string.Format("enter {0} search string", search), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 22
 testRunner.And("choose cruise result", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 23
 testRunner.And("ticket booking page is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 24
 testRunner.Then(string.Format("ticket booking page url should contain {0}", urlPart), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("ChooseTicket_WhenTicketIsNotAdded")]
        [NUnit.Framework.TestCaseAttribute("New", null)]
        public void ChooseTicket_WhenTicketIsNotAdded(string search, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("search", search);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ChooseTicket_WhenTicketIsNotAdded", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 30
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 31
 testRunner.Given("booking page is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 32
 testRunner.When("attractions page is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 33
 testRunner.And(string.Format("enter {0} search string", search), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 34
 testRunner.And("choose cruise result", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 35
 testRunner.And("choose adult ticket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 36
 testRunner.And("click submit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 37
 testRunner.Then("attraction single page url shouldn\'t contain book", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("SubmitData_WhenDataArePut_ShouldGoToPayPage")]
        [NUnit.Framework.TestCaseAttribute("New", "Igor", "Valeriy", "testMail@mail.com", "441234567", "/pay", "/pay", null)]
        public void SubmitData_WhenDataArePut_ShouldGoToPayPage(string search, string firstName, string lastName, string email, string phone, string urlPart, string submit, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("search", search);
            argumentsOfScenario.Add("firstName", firstName);
            argumentsOfScenario.Add("lastName", lastName);
            argumentsOfScenario.Add("email", email);
            argumentsOfScenario.Add("phone", phone);
            argumentsOfScenario.Add("urlPart", urlPart);
            argumentsOfScenario.Add("submit", submit);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SubmitData_WhenDataArePut_ShouldGoToPayPage", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 43
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 44
 testRunner.Given("booking page is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 45
 testRunner.When("attractions page is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 46
 testRunner.And(string.Format("enter {0} search string", search), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 47
 testRunner.And("choose cruise result", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 48
 testRunner.And("ticket booking page is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 49
 testRunner.And(string.Format("enter personal data \'{0}\' \'{1}\' \'{2}\' \'{3}\'", firstName, lastName, email, phone), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 50
 testRunner.And(string.Format("submit data {0}", submit), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 51
 testRunner.Then(string.Format("ticket booking page url should contain {0}", urlPart), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("SubmitData_WhenDataIsNotPut_ShouldStayOnPage")]
        [NUnit.Framework.TestCaseAttribute("New", "/book", "/pay", null)]
        public void SubmitData_WhenDataIsNotPut_ShouldStayOnPage(string search, string submit, string urlpart, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("search", search);
            argumentsOfScenario.Add("submit", submit);
            argumentsOfScenario.Add("urlpart", urlpart);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SubmitData_WhenDataIsNotPut_ShouldStayOnPage", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 57
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 58
 testRunner.Given("booking page is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 59
 testRunner.When("attractions page is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 60
 testRunner.And(string.Format("enter {0} search string", search), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 61
 testRunner.And("choose cruise result", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 62
 testRunner.And("ticket booking page is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 63
 testRunner.And(string.Format("submit data {0}", submit), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 64
 testRunner.Then("ticket booking page url shouldn\'t contain <urlPart>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion