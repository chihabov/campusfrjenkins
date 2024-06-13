using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using CampusFrance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Xml.Linq;



namespace CampusFrance.StepDefinitions
{
 

    [Binding]
    public class CreationDuCompteCampusFranceStepDefinitions
    {
        public IWebDriver driver;
        IJavaScriptExecutor js;
        ReadData read = new ReadData();
        public Client client;
        List<Client> clients;
        WebDriverWait wait;
        

       /* public CreationDuCompteCampusFranceStepDefinitions()
        {
            driver = new ChromeDriver(@"C:\\selenuim\\chromedriver-win64\\chromedriver-win64\\chromedriver.exe");
            js = (IJavaScriptExecutor)driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            read = new ReadData();
            clients = read.ReadDataFromJson();
            client = clients[0];
        }*/
       
     
        [Given(@"L'utilisateur se trouve sur la page daccueil de Campus France")]
        public void GivenLutilisateurSeTrouveSurLaPageDaccueilDeCampusFrance()
        {
            driver = new ChromeDriver(@"C:\\selenuim\\chromedriver-win64\\chromedriver-win64\\chromedriver.exe");
            driver.Navigate().GoToUrl("https://www.campusfrance.org/fr/user/register");
           
            Console.WriteLine("Pré requis");
            
                       
        }

        [When(@"L'utilisateur renseigne ""([^""]*)"" , ""([^""]*)"" , ""([^""]*)""")]
        public void WhenLutilisateurRenseigne(string email, string  Motdepass, string confMotPasse)
        {

            
            

           
            clients = read.ReadDataFromJson();
            js = (IJavaScriptExecutor)driver;
            client = clients[0];
            Thread.Sleep(2000);

            //clique sur accepter (cookiees)
            driver.FindElement(By.Id("tarteaucitronPersonalize2")).Click();
            Thread.Sleep(2000);
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//*[@id=\"user-form\"]/div[2]/h2")));
            Thread.Sleep(2000); // Inhsérer une pause de 1 seconde
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("edit-name")));
            //driver.FindElement(By.CssSelector("#edit-name")).SendKeys(client.email);
            driver.FindElement(By.XPath("//input[@id=\"edit-name\" and @autocorrect=\"off\"]")).SendKeys(client.email);
            Thread.Sleep(2000);

            /*js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//*[@id=\"edit-pass-pass1\"]")));
            Thread.Sleep(2000);*/
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("edit-name")));
            driver.FindElement(By.XPath("//*[@id=\"edit-pass-pass1\"]")).SendKeys(client.Motdepass);
            Thread.Sleep(2000);
            /*//wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("edit-pass-pass1")));
            driver.FindElement(By.Id("edit-pass-pass1")).SendKeys(MotdePasse);

            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("edit-pass-pass2")));*/
            driver.FindElement(By.XPath("//*[@id=\"edit-pass-pass2\"]")).SendKeys(client.confMotPasse);
            Thread.Sleep(2000);
        }

        [When(@"L'utilisateur clique sur le bouton ""([^""]*)""")]
        public void WhenLutilisateurCliqueSurLeBouton(string civilité)
        {
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//*[@id=\"user-form\"]/div[3]/h2")));
            driver.FindElement(By.XPath("//*[@id=\"edit-field-civilite\"]/div[1]/label")).Click();
            Thread.Sleep(2000);
        }

       
        [When(@"L'utilisateur renseigne les champs ""([^""]*)"",""([^""]*)""")]
        public void WhenLutilisateurRenseigneLesChamps(string Nom, string Prénom)
        {
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("nom")));
            driver.FindElement(By.Id("edit-field-nom-0-value")).SendKeys(client.Nom);

            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("prenom")));
            driver.FindElement(By.Id("edit-field-prenom-0-value")).SendKeys(client.Prénom);
            Thread.Sleep(2000);
        }

        [When(@"L'utilisateur séléctionne ""([^""]*)"", ""([^""]*)""")]
        public void WhenLutilisateurSelectionne(string Paysderésidence, string PaysdeNationalité)
        {
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Scroll to the element
            var nomWrapperLabel = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"edit-field-nom-wrapper\"]/div/label")));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", nomWrapperLabel);

            // Click on the element to open the dropdown list
            var dropdownLabel = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"edit-field-pays-concernes-wrapper\"]/div/label")));
            dropdownLabel.Click();

            // Wait for the dropdown options to be visible
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-value='495']")));
            var countryOption = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@data-value='169']")));
            Thread.Sleep(2000);
            countryOption.Click();


            // Set the nationality
            var nationalityField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"edit-field-nationalite-0-target-id\"]")));
            nationalityField.SendKeys(client.PaysdeNationalité);

        }

        [When(@"L'utilisateur remplie ""([^""]*)"", ""([^""]*)"", ""([^""]*)""")]
        public void WhenLutilisateurRemplie(string Codepostal, string Ville, string Telephone)
        {
            //js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//*[@id=\"field-nationalite-values\"]/thead/tr/th[1]/h4")));
            Thread.Sleep(2000);
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"edit-field-code-postal-0-value\"]")));
            driver.FindElement(By.XPath("//*[@id=\"edit-field-code-postal-0-value\"]")).SendKeys(client.Codepostal);
            Thread.Sleep(2000);
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"edit-field-ville-0-value\"]")));
            driver.FindElement(By.XPath("//*[@id=\"edit-field-ville-0-value\"]")).SendKeys(client.Ville);
            Thread.Sleep(2000);
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"edit-field-telephone-0-value\"]")));
            driver.FindElement(By.XPath("//*[@id=\"edit-field-telephone-0-value\"]")).SendKeys(client.Telephone);
            Thread.Sleep(2000);
        }

        [When(@"L'utilisateur Clique sur le bouton Etudiants ""([^""]*)""")]
        public void WhenLutilisateurCliqueSurLeBoutonEtudiants(string etudiants)
        {


            //js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//input[@value='2']")));
            //driver.FindElement(By.CssSelector("#edit-field-publics-cibles > div:nth-child(1)")).Click();
            driver.FindElement(By.CssSelector("#edit-field-publics-cibles > div:nth-child(1)")).Click();
            Thread.Sleep(2000);
            
        }

        [When(@"L'utilisateur séléctionne le domaine ""([^""]*)""")]
        public void WhenLutilisateurSelectionneLeDomaine(string domaineEtude)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Scroll to the element
            //var nomWrapperLabel = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#edit-field-publics-cibles > div:nth-child(1)")));
            //js.ExecuteScript("arguments[0].scrollIntoView(true);", nomWrapperLabel);

            // Click on the element to open the dropdown list
            var dropdownLabel = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"edit-field-domaine-etudes-wrapper\"]/div/div/div[1]")));
            dropdownLabel.Click();

            // Wait for the dropdown options to be visible
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-value='319']")));
            var DomaineOption = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@data-value='319']")));
            Thread.Sleep(2000);
            DomaineOption.Click();
        }

        [When(@"L'utilisateur séléctionne le niveau ""([^""]*)""")]
        public void WhenLutilisateurSelectionneLeNiveau(string Licence1)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Scroll to the element
            //var nomWrapperLabelK = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#edit-field-domaine-etudes-wrapper > div > label")));
            //js.ExecuteScript("arguments[0].scrollIntoView(true);", nomWrapperLabelK);

            // Click on the element to open the dropdown list
            var dropdownLabelK = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"edit-field-niveaux-etude-wrapper\"]/div/div/div[1]")));
            dropdownLabelK.Click();

            // Wait for the dropdown options to be visible
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-value='69']")));
            var NiveauOption = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@data-value='69']")));
            Thread.Sleep(2000);
            NiveauOption.Click();
            //Thread.Sleep(2000);
        }

        [When(@"L'utillisateur clique sur ""([^""]*)""")]
        public void WhenLutillisateurCliqueSur(string accepter)
        {
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#edit-field-accepte-communications-wrapper > div")));
            driver.FindElement(By.CssSelector("#edit-field-accepte-communications-wrapper > div")).Click();
            //Thread.Sleep(2000);
        }




        [Then(@"afficher le message")]
        public void ThenAfficherLeMessage()
        {
            Assert.AreEqual("J’accepte que mes données soient traitées pour recevoir des communications adaptées, de la part de Campus France.", driver.FindElement(By.CssSelector("#edit-field-accepte-communications-wrapper > div > label")).Text);
        }

        [Given(@"L'Utilisateur se trouve sur la page daccueil de Campus France")]
        public void GivenLUtilisateurSeTrouveSurLaPageDaccueilDeCampusFrance()
        {
            driver = new ChromeDriver(@"C:\\selenuim\\chromedriver-win64\\chromedriver-win64\\chromedriver.exe");
            driver.Navigate().GoToUrl("https://www.campusfrance.org/fr/user/register");
        }

        [When(@"L'Utilisateur renseigne ""([^""]*)"" , ""([^""]*)"" , ""([^""]*)""")]
        public void WhenLUtilisateurRenseigne(string email, string motdepass, string confMotPasse)
        {
            clients = read.ReadDataFromJson();
            js = (IJavaScriptExecutor)driver;
            client = clients[1];
            Thread.Sleep(2000);

            //clique sur accepter (cookiees)
            driver.FindElement(By.Id("tarteaucitronPersonalize2")).Click();
            Thread.Sleep(2000);
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//*[@id=\"user-form\"]/div[2]/h2")));
            Thread.Sleep(2000); // Insérer une pause de 1 seconde
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("edit-name")));
            //driver.FindElement(By.CssSelector("#edit-name")).SendKeys(client.email);
            driver.FindElement(By.XPath("//input[@id=\"edit-name\" and @autocorrect=\"off\"]")).SendKeys(client.email);
            Thread.Sleep(2000);

            /*js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//*[@id=\"edit-pass-pass1\"]")));
            Thread.Sleep(2000);*/
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("edit-name")));
            driver.FindElement(By.XPath("//*[@id=\"edit-pass-pass1\"]")).SendKeys(client.Motdepass);
            Thread.Sleep(2000);
            /*//wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("edit-pass-pass1")));
            driver.FindElement(By.Id("edit-pass-pass1")).SendKeys(MotdePasse);

            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("edit-pass-pass2")));*/
            driver.FindElement(By.XPath("//*[@id=\"edit-pass-pass2\"]")).SendKeys(client.confMotPasse);
            Thread.Sleep(2000); ;
        }

        [When(@"L'Utilisateur clique sur le bouton ""([^""]*)""")]
        public void WhenLUtilisateurCliqueSurLeBouton(string mme)
        {
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//*[@id=\"user-form\"]/div[3]/h2")));
            driver.FindElement(By.XPath("//*[@id=\"edit-field-civilite\"]/div[1]/label")).Click();
            Thread.Sleep(2000);
        }

        [When(@"L'Utilisateur renseigne les champs ""([^""]*)"",""([^""]*)""")]
        public void WhenLUtilisateurRenseigneLesChamps(string nom, string prénom)
        {
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("nom")));
            driver.FindElement(By.Id("edit-field-nom-0-value")).SendKeys(client.Nom);

            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("prenom")));
            driver.FindElement(By.Id("edit-field-prenom-0-value")).SendKeys(client.Prénom);
            Thread.Sleep(2000);
        }

        [When(@"L'Utilisateur séléctionne ""([^""]*)"", ""([^""]*)""")]
        public void WhenLUtilisateurSelectionne(string afrique, string paysdeNationalité)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Scroll to the element
            var nomWrapperLabel = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"edit-field-nom-wrapper\"]/div/label")));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", nomWrapperLabel);

            // Click on the element to open the dropdown list
            var dropdownLabel = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"edit-field-pays-concernes-wrapper\"]/div/label")));
            dropdownLabel.Click();

            // Wait for the dropdown options to be visible
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-value='495']")));
            var countryOption = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@data-value='169']")));
            Thread.Sleep(2000);
            countryOption.Click();


            // Set the nationality
            var nationalityField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"edit-field-nationalite-0-target-id\"]")));
            nationalityField.SendKeys(client.PaysdeNationalité);
        }

        [When(@"L'Utilisateur remplie ""([^""]*)"", ""([^""]*)"", ""([^""]*)""")]
        public void WhenLUtilisateurRemplie(string codepostal, string ville, string telephone)
        {
            //js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//*[@id=\"field-nationalite-values\"]/thead/tr/th[1]/h4")));
            Thread.Sleep(2000);
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"edit-field-code-postal-0-value\"]")));
            driver.FindElement(By.XPath("//*[@id=\"edit-field-code-postal-0-value\"]")).SendKeys(client.Codepostal);
            Thread.Sleep(2000);
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"edit-field-ville-0-value\"]")));
            driver.FindElement(By.XPath("//*[@id=\"edit-field-ville-0-value\"]")).SendKeys(client.Ville);
            Thread.Sleep(2000);
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"edit-field-telephone-0-value\"]")));
            driver.FindElement(By.XPath("//*[@id=\"edit-field-telephone-0-value\"]")).SendKeys(client.Telephone);
            Thread.Sleep(2000);
        }

        [When(@"L'Utilisateur Clique sur le bouton Etudiants ""([^""]*)""")]
        public void WhenLUtilisateurCliqueSurLeBoutonEtudiants(string institutionnel)
        {
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//*[@id=\"user-form\"]/div[3]/h2")));
            driver.FindElement(By.XPath("//*[@id=\"edit-field-publics-cibles\"]/div[3]/label")).Click();
            Thread.Sleep(2000);
        }

        [When(@"L'utilisateur renseigne la fonction ""([^""]*)""")]
        public void WhenLutilisateurRenseigneLaFonction(string fonction)
        {
            driver.FindElement(By.Id("edit-field-fonction-0-value")).SendKeys(client.Institution.Fonction);

        }
        [When(@"L'([^']*)'organisme""")]
        public void WhenLorganisme(string p0)
        {
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#edit-field-type-organisme-wrapper > div > div > div.selectize-input.items.full.has-options.has-items")).Click();

            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[@data-value=600]")).Click();
        }

        [When(@"L'utilisateur renseigne le nom de lorganisme ""([^""]*)""")]
        public void WhenLutilisateurRenseigneLeNomDeLorganisme(string NomdeLorganisation)
        {
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id=\"edit-field-nom-organisme-0-value\"]")).SendKeys(client.Institution.NomdeLorganisation);
            Thread.Sleep(2000);
        }
                
        [When(@"L'Utillisateur clique sur ""([^""]*)""")]
        public void WhenLUtillisateurCliqueSur(string accepter)
        {
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#edit-field-accepte-communications-wrapper > div")));
            driver.FindElement(By.CssSelector("#edit-field-accepte-communications-wrapper > div")).Click();
            //Thread.Sleep(2000);

        }

        [Then(@"afficher les messagess")]
        public void ThenAfficherLesMessagess()
        {
            Assert.AreEqual("J’accepte que mes données soient traitées pour recevoir des communications adaptées, de la part de Campus France.", driver.FindElement(By.CssSelector("#edit-field-accepte-communications-wrapper > div > label")).Text);
        }

        public void Dispose()
        {
            //driver.Quit();
            //driver.Dispose();
        }

    }
}
