using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;


namespace StudyGroups.Test.UI
{
    public class StudyGroup
    {
        private IPage _page;

        [OneTimeSetUp]
        public

async Task Setup()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync();
            _page = await browser.NewPageAsync();
        }

        [OneTimeTearDown]
        public async Task Teardown()
        {
            await _page.CloseAsync();
        }

        [Test]
        public async Task CreateStudyGroup_ValidData_Succeeds()
        {

            var name = "Awesome Math Group";
            var subject = "Math";


            await _page.GotoAsync("http://localhost:5000/study-groups/create");
            await _page.FillAsync("#name", name);
            await _page.SelectOptionAsync("#subject", subject.ToString());
            await _page.ClickAsync("button[type='submit']");


            var successMessage = await _page.TextContentAsync("#success-message");
            Assert.That(successMessage, Is.EqualTo($"Study group '{name}' created successfully!"));
        }

        [Test]
        public async Task CreateStudyGroup_InvalidName_Fails()
        {

            var name = "Invalid";
            var subject = "Physics";


            await _page.GotoAsync("http://localhost:5000/study-groups/create");
            await _page.FillAsync("#name", name);
            await _page.SelectOptionAsync("#subject", subject.ToString());
            await _page.ClickAsync("button[type='submit']");


            var errorMessage = await _page.TextContentAsync("#error-message");
            Assert.That(errorMessage, Contains.Substring("Name must be between 5 and 30 characters"));
        }

        [Test]
        public async Task CreateStudyGroup_DuplicateSubject_Fails()
        {

            var name = "Another Math Group";
            var subject = "Math";


            await _page.GotoAsync("http://localhost:5000/study-groups/create");
            await _page.FillAsync("#name", name);
            await _page.SelectOptionAsync("#subject", subject.ToString());
            await _page.ClickAsync("button[type='submit']");


            var errorMessage = await _page.TextContentAsync("#error-message");
            Assert.That(errorMessage, Contains.Substring("You already have a study group for this subject"));
        }
    }
}
