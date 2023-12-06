using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using CompetitionProjectMars.JSONDataObject;
using CompetitionProjectMars.Pages;
using CompetitionProjectMars.Utilities;


namespace CompetitionProjectMars.Tests
{
    [TestFixture]
    public class CertificationNunitTest : CommonDriver
    {
        LoginPage loginPageObj;
        CertificationsPage certificationsPageObj;
        JsonDataReader jsonFileObj;

        [Test, Order(1)]
        public void AddCertificationTest()
        {
            test = null;
            test = extent.CreateTest("AddCertification");
            test.Log(Status.Info, "AddCertification");
            loginPageObj = new LoginPage(driver);
            string loginFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\LoginInputFile\\Login.json";
            jsonFileObj = new JsonDataReader(loginFilePath);
            List<Login> login = new List<Login>();
            login = jsonFileObj.ReadLoginFile();
            foreach (var item in login)
            {
                loginPageObj.LoginActions(driver, item.LoginId, item.Password);
            }
            certificationsPageObj = new CertificationsPage(driver);
            certificationsPageObj.GoToCertificationsTab();
            certificationsPageObj.ResetCertificationTable(driver);
            string addCertificationFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\CertificationInputFiles\\AddCertifications.json";
            jsonFileObj = new JsonDataReader(addCertificationFilePath);
            List<AddCertifications> list = new List<AddCertifications>();
            list = jsonFileObj.ReadCertificationFile();

            if (list != null)
            {
                foreach (var certification in list)
                {
                    certificationsPageObj.CreateCertification(driver, certification.CertificationName, certification.Certifiedfrom, certification.year);
                    string addedname = certificationsPageObj.AssertCertification(driver);
                    string institutionName = certificationsPageObj.AssertCertifiedFrom(driver);
                    string certifiedYear = certificationsPageObj.AssertCertifiedYear(driver);
                    Assert.That(addedname == certification.CertificationName, "Certification added successfully");
                    Assert.That(institutionName == certification.Certifiedfrom, "Instituttion name added successfully");
                    Assert.That(certifiedYear == certification.year, "Certified Year added Successfully");
                }


            }
        }
        [Test, Order(2)]
        public void UpdateCertificationTest()
        {
            test = null;
            test = extent.CreateTest("Update Certification");
            test.Log(Status.Info, "Update Certification");
            loginPageObj = new LoginPage(driver);
            string loginFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\LoginInputFile\\Login.json";
            jsonFileObj = new JsonDataReader(loginFilePath);

            List<Login> login = new List<Login>();
            login = jsonFileObj.ReadLoginFile();
            foreach (var item in login)
            {
                loginPageObj.LoginActions(driver, item.LoginId, item.Password);

            }
            certificationsPageObj = new CertificationsPage(driver);
            certificationsPageObj.GoToCertificationsTab();
            certificationsPageObj.ResetCertificationTable(driver);
            string updateCertificationFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\CertificationInputFiles\\UpdateCertification.json";
            jsonFileObj = new JsonDataReader(updateCertificationFilePath);

            List<UpdateCertification> list = new List<UpdateCertification>();
            list = jsonFileObj.ReadUpdateCeritificationFile();
            if (list != null)
            {
                foreach (var certification in list)
                {
                    certificationsPageObj.CreateCertification(driver, certification.CertificationName, certification.CertifiedFrom, certification.Year);
                    certificationsPageObj.UpdateCertification(driver, certification.CertificationNameNew, certification.CertifiedFromNew, certification.YearNew);
                    string updatedname = certificationsPageObj.AssertCertification(driver);
                    string updatedCertifiedFrom = certificationsPageObj.AssertCertifiedFrom(driver);
                    string updatedYear = certificationsPageObj.AssertCertifiedYear(driver);

                    Assert.That(updatedname == certification.CertificationNameNew, "Certification not updated successfully");
                    Assert.That(updatedCertifiedFrom == certification.CertifiedFromNew, "Certified From not updated successfully");
                    Assert.That(updatedYear == certification.YearNew, "Year not updated successfully");
                }
            }
        }
        [Test, Order(3)]
        public void DeleteCertificationTest()
        {
            test = null;
            test = extent.CreateTest("Delete Certification");
            test.Log(Status.Info, "Delete Certification");
            loginPageObj = new LoginPage(driver);
            string loginFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\LoginInputFile\\Login.json";
            jsonFileObj = new JsonDataReader(loginFilePath);

            List<Login> login = new List<Login>();
            login = jsonFileObj.ReadLoginFile();
            foreach (var item in login)
            {
                loginPageObj.LoginActions(driver, item.LoginId, item.Password);
            }
            certificationsPageObj = new CertificationsPage(driver);
            certificationsPageObj.GoToCertificationsTab();
            certificationsPageObj.ResetCertificationTable(driver);
            string deleteCertificationFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\CertificationInputFiles\\DeleteCertification.json";
            jsonFileObj = new JsonDataReader(deleteCertificationFilePath);

            List<DeleteCertification> list = new List<DeleteCertification>();
            list = jsonFileObj.ReadDeleteCertificationFile();

            if (list != null)
            {
                foreach (var certification in list)
                {
                    certificationsPageObj.CreateCertification(driver, certification.CertificationName, certification.CertifiedFrom, certification.Year);
                    //Console.WriteLine("Before Delete certification Action");
                    certificationsPageObj.DeleteCertification();
                    //Console.WriteLine("After Delete Certification Action");
                    string expectedMessage = certificationsPageObj.PopUpMessage(driver);
                    //string actualPopUpMessage = certificationsPageObj.PopUpMessage(driver);
                    //string expectedMessage = $"{certification} has been deleted from your certification";
                    Assert.That(expectedMessage == certification.PopUpMessage, "Certification has been deleted");
                }
            }

        }    

        [Test, Order(4)]
        public void AddCertificationInvalidInputTest()
        { 
        
            test = null;
            test = extent.CreateTest("Add Certification with Invalid Input");
            test.Log(Status.Info, "Add Certification");
            loginPageObj = new LoginPage(driver);
            string loginFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\LoginInputFile\\Login.json";
            jsonFileObj = new JsonDataReader(loginFilePath);
            List<Login> login = new List<Login>();
            login = jsonFileObj.ReadLoginFile();
            foreach (var item in login)
            {
                loginPageObj.LoginActions(driver, item.LoginId, item.Password);
            }
            certificationsPageObj = new CertificationsPage(driver);
            certificationsPageObj.GoToCertificationsTab();
            certificationsPageObj.ResetCertificationTable(driver);
            string addInvalidCertificationFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\CertificationInputFiles\\AddCertificationInvalidInput.json";
            jsonFileObj = new JsonDataReader(addInvalidCertificationFilePath);

            List<AddCertificationInvalidInput> list = new List<AddCertificationInvalidInput>();
            list = jsonFileObj.ReadCertificationInvalidInputFile();
            if (list != null)
            {
                foreach (var certification in list)
                {
                    certificationsPageObj.CreateCertification(driver, certification.CertificationName, certification.CertifiedFrom, certification.Year);
                    string expectedMessage = certificationsPageObj.PopUpMessage(driver);
                    Assert.That(expectedMessage == certification.PopUpMessage, "Certification added with Invalid Data");
                }
            }
        }
        [Test, Order(5)]
        public void AddExistingCertificationTest()
        {
            test = null;
            test = extent.CreateTest("Add Existing Certification");
            test.Log(Status.Info, "Add Existing Certification");
            loginPageObj = new LoginPage(driver);
            string loginFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\LoginInputFile\\Login.json";
            jsonFileObj = new JsonDataReader(loginFilePath);

            List<Login> login = new List<Login>();
            login = jsonFileObj.ReadLoginFile();
            foreach (var item in login)
            {
                loginPageObj.LoginActions(driver, item.LoginId, item.Password);
            }
            certificationsPageObj = new CertificationsPage(driver);
            certificationsPageObj.GoToCertificationsTab();
            certificationsPageObj.ResetCertificationTable(driver);
            string addExistingCertificationFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\CertificationInputFiles\\AddExistingCertification.json";
            jsonFileObj = new JsonDataReader(addExistingCertificationFilePath);

            List<AddExistingCertification> list = new List<AddExistingCertification>();
            list = jsonFileObj.ReadExistingCertificationFile();
            if (list != null)
            {
                foreach (var certification in list)
                {
                    certificationsPageObj.CreateCertification(driver, certification.CertificationName, certification.CertifiedFrom, certification.Year);
                    certificationsPageObj.CreateCertification(driver, certification.CertificationNameNew, certification.CertifiedFromNew, certification.YearNew);
                    string expectedMessage = certificationsPageObj.PopUpMessage(driver);
                    Assert.That(expectedMessage == certification.PopUpMessage, "Certification added with Duplicate Data");

                }
            }

        }
        [Test, Order(6)]
        public void AddExistingCertificationwithDifferentYearTest()
        {
            test = null;
            test = extent.CreateTest("Add Existing Certification with Different Year");
            test.Log(Status.Info, "Add Existing Certification with Different Year");
            loginPageObj = new LoginPage(driver);
            string loginFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\LoginInputFile\\Login.json";
            jsonFileObj = new JsonDataReader(loginFilePath);

            List<Login> login = new List<Login>();
            login = jsonFileObj.ReadLoginFile();
            foreach (var item in login)
            {
                loginPageObj.LoginActions(driver, item.LoginId, item.Password);
            }
            certificationsPageObj = new CertificationsPage(driver);
            certificationsPageObj.GoToCertificationsTab();
            certificationsPageObj.ResetCertificationTable(driver);

            string addExistingCertificationwithDifferentYearFilePath = ProjectPathHelper.projectPath + "\\JSONInputFiles\\CertificationInputFiles\\AddExistingCertificationwithDifferentYear.json";
            jsonFileObj = new JsonDataReader(addExistingCertificationwithDifferentYearFilePath);

            List<AddExistingCertificationwithDifferentYear> list = new List<AddExistingCertificationwithDifferentYear>();
            list = jsonFileObj.ReadExistingCertificationWithDifferentYearFile();

            if (list != null)
            {
                foreach (var certification in list)
                {
                    certificationsPageObj.CreateCertification(driver, certification.CertificationName, certification.CertifiedFrom, certification.Year);
                    certificationsPageObj.CreateCertification(driver, certification.CertificationNameNew, certification.CertifiedFromNew, certification.YearNew);
                    string expectedMessage = certificationsPageObj.PopUpMessage(driver);
                    Assert.That(expectedMessage == certification.PopUpMessage, "Certification added with Duplicate Data");

                }
            }

        }


    }

}




        


       


     

        
        
        
    

