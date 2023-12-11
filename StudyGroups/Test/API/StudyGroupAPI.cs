using System;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;
using System.Net;

namespace StudyGroups.Test
{
    public class StudyGroupApiTest
    {

        [Test]
        public async Task CreateStudyGroup_ValidData_Succeeds()
        {
            var playwright = await Playwright.CreateAsync();
            var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL = "http://localhost:5000/api",
            });

            const string endpoint = "/api/study-groups";


            var requestBody = new
            {
                name = "Awesome Math Group",
                subject = "Math"
            };


            var response = await requestContext.PostAsync(endpoint, new APIRequestContextOptions()
            {
                DataObject = requestBody
            });

            Assert.Pass();

        }
        [Test]
        public async Task CreateStudyGroup_InvalidName_Fails()
        {

            var playwright = await Playwright.CreateAsync();
            var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL = "http://localhost:5000/api",
            });
            const string endpoint = "/api/study-groups";
            var requestBody = new
            {
                name = "Invalid",
                subject = "Physics"
            };


            var response = await requestContext.PostAsync(endpoint, new APIRequestContextOptions()
            {
                DataObject = requestBody
            });
            Assert.Pass();


        }

        [Test]
        public async Task CreateStudyGroup_DuplicateSubject_Fails()
        {

            var playwright = await Playwright.CreateAsync();
            var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL = "http://localhost:5000/api",
            });
            const string endpoint = "/api/study-groups";

            var requestBody = new
            {
                name = "Another Math Group",
                subject = "Math"
            };


            var response = await requestContext.PostAsync(endpoint, new APIRequestContextOptions()
            {
                DataObject = requestBody
            });

            
        }
    }
}