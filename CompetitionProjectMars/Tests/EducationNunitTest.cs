using AventStack.ExtentReports;
using CompetitionProjectMars.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompetitionProjectMars.Utilities;
using CompetitionProjectMars.JSONDataObject;

namespace CompetitionProjectMars.Tests
{
    [TestFixture]
    public class EducationNunitTest : CommonDriver
    {
        LoginPage loginPageObj;
        EducationPage educationPageObj;
        JsonDataReader jsonFileObj;

        [Test, Order(1)]
        public void AddEducationTest()
        {
            // Your test logic here
            test = null;
            test = extent.CreateTest("Add Education");
            test.Log(Status.Info, "Add Education");
            loginPageObj = new LoginPage(driver);
            string loginFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\LoginInputFile\\Login.json";

            jsonFileObj = new JsonDataReader(loginFilePath);
            List<Login> login = new List<Login>();
            login = jsonFileObj.ReadLoginFile();
            foreach (var item in login)
            {
                loginPageObj.LoginActions(driver, item.LoginId, item.Password);

            }
            educationPageObj = new EducationPage(driver);
            educationPageObj.GoToEducationTab();
            educationPageObj.ResetEducationTable(driver);
            string addEducationFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\EducationInputFiles\\AddEducation.json";
            jsonFileObj = new JsonDataReader(addEducationFilePath);
            List<AddEducation> list = new List<AddEducation>();
            list = jsonFileObj.ReadAddEducationFile();

            if (list != null)
            {
                foreach (var education in list)
                {
                    educationPageObj.AddEducation(driver, education.CollegeName, education.Country, education.Title, education.Degree, education.Year);
                    string instituteName = educationPageObj.AssertEducation(driver);
                    string countryName = educationPageObj.AssertCountry(driver);
                    string title = educationPageObj.AssertTitle(driver);
                    string degree = educationPageObj.AssertDegree(driver);
                    string educationYear = educationPageObj.AssertEducationYear(driver);

                    Assert.That(instituteName == education.CollegeName, "Education not added successfully");
                    Assert.That(countryName == education.Country, "Country not added successfully");
                    Assert.That(title == education.Title, "Title not added successfully");
                    Assert.That(degree == education.Degree, "Degree not added successfully");
                    Assert.That(educationYear == education.Year, "Year not added successfully");
                }
            }

        }
        [Test, Order(2)]
        public void UpdateEducationTest()
        {
            test = null;
            test = extent.CreateTest("Update Education");
            test.Log(Status.Info, "Update Education");
            loginPageObj = new LoginPage(driver);
            string loginFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\LoginInputFile\\Login.json";
            jsonFileObj = new JsonDataReader(loginFilePath);

            List<Login> login = new List<Login>();
            login = jsonFileObj.ReadLoginFile();
            foreach (var item in login)
            {
                loginPageObj.LoginActions(driver, item.LoginId, item.Password);
            }
            educationPageObj = new EducationPage(driver);
            educationPageObj.GoToEducationTab();
            educationPageObj.ResetEducationTable(driver);
            string updateEducationFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\EducationInputFiles\\UpdateEducation.json";
            jsonFileObj = new JsonDataReader(updateEducationFilePath);
            List<UpdateEducation> list = new List<UpdateEducation>();
            list = jsonFileObj.ReadUpdateEducationFile();
            if (list != null)
            {
                foreach (var education in list)
                {
                    educationPageObj.AddEducation(driver, education.CollegeName, education.Country, education.Title, education.Degree, education.Year);
                    educationPageObj.UpdateEducation(driver, education.CollegeNameNew, education.CountryNew, education.TitleNew, education.DegreeNew, education.YearNew);
                    string updatedInstituteName = educationPageObj.AssertEducation(driver);
                    string updatedCountry = educationPageObj.AssertCountry(driver);
                    string updatedTitle = educationPageObj.AssertTitle(driver);
                    string updatedDegree = educationPageObj.AssertDegree(driver);
                    string updatedYear = educationPageObj.AssertEducationYear(driver);

                    Assert.That(updatedInstituteName == education.CollegeNameNew, "Education not updated successfully");
                    Assert.That(updatedCountry == education.CountryNew, "Country not updated successfully");
                    Assert.That(updatedTitle == education.TitleNew, "Title not updated successfully");
                    Assert.That(updatedDegree == education.DegreeNew, "Degree not updated successfully");
                    Assert.That(updatedYear == education.YearNew, "Year not updated successfully");


                }

            }
        }
        [Test, Order(3)]
        public void DeleteEducationTest()
        {
            test = null;
            test = extent.CreateTest("Delete Education");
            test.Log(Status.Info, "Delete Education");
            loginPageObj = new LoginPage(driver);
            string loginFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\LoginInputFile\\Login.json";
            jsonFileObj = new JsonDataReader(loginFilePath);

            List<Login> login = new List<Login>();
            login = jsonFileObj.ReadLoginFile();
            foreach (var item in login)
            {
                loginPageObj.LoginActions(driver, item.LoginId, item.Password);
            }
            educationPageObj = new EducationPage(driver);
            educationPageObj.GoToEducationTab();
            educationPageObj.ResetEducationTable(driver);
            string deleteEducationFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\EducationInputFiles\\DeleteEducation.json";
            jsonFileObj = new JsonDataReader(deleteEducationFilePath);
            List<DeleteEducation> list = new List<DeleteEducation>();
            list = jsonFileObj.ReadDeleteEducationFile();

            if (list != null)
            {
                foreach (var education in list)
                {
                    educationPageObj.AddEducation(driver, education.CollegeName, education.Country, education.Title, education.Degree, education.Year);
                    
                    educationPageObj.DeleteEducation();
                    Thread.Sleep(4000);
                    
                    string PopUpMessage = educationPageObj.PopUpMessage(driver);
                    
                    Assert.That(PopUpMessage == education.PopUpMessage, "Education not Deleted");
                }
            }
        }
        [Test, Order(4)]
        public void AddEducationInvalidInputTest()
        {
            test = null;
            test = extent.CreateTest("Add Education with Invalid Input");
            test.Log(Status.Info, "Add Education with Invalid Input");
            loginPageObj = new LoginPage(driver);
            string loginFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\LoginInputFile\\Login.json";
            jsonFileObj = new JsonDataReader(loginFilePath);

            List<Login> login = new List<Login>();
            login = jsonFileObj.ReadLoginFile();
            foreach (var item in login)
            {
                loginPageObj.LoginActions(driver, item.LoginId, item.Password);
            }
            educationPageObj = new EducationPage(driver);
            educationPageObj.GoToEducationTab();
            educationPageObj.ResetEducationTable(driver);
            string addInvalidEducationFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\EducationInputFiles\\AddEducationinvalidInput.json";
            jsonFileObj = new JsonDataReader(addInvalidEducationFilePath);
            List<AddEducationInvalidInput> list = new List<AddEducationInvalidInput>();
            list = jsonFileObj.ReadEducationInvalidInputFile();

            if (list != null)
            {
                foreach (var education in list)
                {
                    educationPageObj.AddEducation(driver, education.CollegeName, education.Country, education.Title, education.Degree, education.Year);
                    
                    string PopUpMessage = educationPageObj.PopUpMessage(driver);
                    
                    
                    Assert.That(PopUpMessage == education.PopUpMessage, "Education not Deleted");
                    

                }
            }
        }
        [Test, Order(5)]
        public void AddExistingEducationTest()
        {
            test = null;
            test = extent.CreateTest("Add Existing Education");
            test.Log(Status.Info, "Add Existing Education");
            loginPageObj = new LoginPage(driver);
            string loginFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\LoginInputFile\\Login.json";
            jsonFileObj = new JsonDataReader(loginFilePath);

            List<Login> login = new List<Login>();
            login = jsonFileObj.ReadLoginFile();
            foreach (var item in login)
            {
                loginPageObj.LoginActions(driver, item.LoginId, item.Password);
            }
            educationPageObj = new EducationPage(driver);
            educationPageObj.GoToEducationTab();
            educationPageObj.ResetEducationTable(driver);
            string addExistingEducationFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\EducationInputFiles\\AddExistingEducation.json";
            jsonFileObj = new JsonDataReader(addExistingEducationFilePath);
            List<AddExistingEducation> list = new List<AddExistingEducation>();
            list = jsonFileObj.ReadAddExistingEducationFile();

            if (list != null)
            {
                foreach (var education in list)
                {
                    educationPageObj.AddEducation(driver, education.CollegeName, education.Country, education.Title, education.Degree, education.Year);
                    educationPageObj.AddEducation(driver,education.CollegeNameNew, education.CountryNew, education.TitleNew, education.DegreeNew, education.YearNew);
                    
                    string PopUpMessage = educationPageObj.PopUpMessage(driver);
                    
                    Assert.That(PopUpMessage == education.PopUpMessage, "Existing Education Added");
                    
                }
            }
        }
        [Test, Order(6)]
        public void AddExistingEducationwithDifferentYear()
        {
            test = null;
            test = extent.CreateTest("Add Existing Education");
            test.Log(Status.Info, "Add Existing Education");
            loginPageObj = new LoginPage(driver);
            string loginFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\LoginInputFile\\Login.json";
            jsonFileObj = new JsonDataReader(loginFilePath);

            List<Login> login = new List<Login>();
            login = jsonFileObj.ReadLoginFile();
            foreach (var item in login)
            {
                loginPageObj.LoginActions(driver, item.LoginId, item.Password);
            }
            educationPageObj = new EducationPage(driver);
            educationPageObj.GoToEducationTab();
            educationPageObj.ResetEducationTable(driver);
            string addExistingEducationwithDifferentyearFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\EducationInputFiles\\AddExistingEducationWithDifferentYear.json";
            jsonFileObj = new JsonDataReader(addExistingEducationwithDifferentyearFilePath);

            List<AddExistingEducationwithDifferentYear> list = new List<AddExistingEducationwithDifferentYear>();
            list = jsonFileObj.ReadAddExistingEducationWithDifferentYearFile();

            if (list != null)
            {
                foreach (var education in list)
                {
                    educationPageObj.AddEducation(driver, education.CollegeName, education.Country, education.Title, education.Degree, education.Year);
                    educationPageObj.AddEducation(driver, education.CollegeNameNew, education.CountryNew, education.TitleNew, education.DegreeNew, education.YearNew);
                    string popUpMessage = educationPageObj.PopUpMessage(driver);
                    Assert.That(popUpMessage == education.PopUpMessage, "Existing Education Added");
                }
            }

        }

    }

}


        







    
  


