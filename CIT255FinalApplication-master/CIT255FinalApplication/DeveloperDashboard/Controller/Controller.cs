using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperDashboard
{
    public class Controller
    {
        #region ENUMERABLES


        #endregion

        #region FIELDS

        bool active = true;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            ApplicationControl();
        }

        #endregion

        #region METHODS

        private void ApplicationControl()
        {
            AppEnum.ManagerAction userActionChoice;

            ConsoleView.DisplayWelcomeScreen();

            while (active)
            {
                userActionChoice = ConsoleView.GetUserActionChoice();

                switch (userActionChoice)
                {
                    case AppEnum.ManagerAction.None:
                        break;

                    case AppEnum.ManagerAction.ListAllLanguages:
                        ListAllLanguages();
                        break;

                    case AppEnum.ManagerAction.DisplayLanguageDetail:
                        DisplayLanguageDetail();
                        break;

                    case AppEnum.ManagerAction.AddLanguage:
                        AddLanguage();
                        break;

                    case AppEnum.ManagerAction.UpdateLanguage:
                        UpdateLanguage();
                        break;

                    case AppEnum.ManagerAction.DeleteLanguage:
                        DeleteLanguage();
                        break;

                    case AppEnum.ManagerAction.QueryLanguagesByPopularity:
                        QueryLanguagesByPopularity();
                        break;

                    case AppEnum.ManagerAction.Quit:
                        active = false;
                        break;

                    default:
                        break;
                }

            }

            ConsoleView.DisplayExitPrompt();
        }

        private static void ListAllLanguages()
        {
            DevLanguageRepoSQL devLanguageRepo = new DevLanguageRepoSQL();
            List<Language> languages;

            using (devLanguageRepo)
            {
                languages = devLanguageRepo.SelectAll();
                ConsoleView.DisplayAllLanguages(languages);
                ConsoleView.DisplayContinuePrompt();
            }
        }

        private static void DisplayLanguageDetail()
        {
            DevLanguageRepoSQL devLanguageRepo = new DevLanguageRepoSQL();
            List<Language> languages;
            Language language = new Language();
            int languageID;

            using (devLanguageRepo)
            {
                languages = devLanguageRepo.SelectAll();
                languageID = ConsoleView.GetLanguageID(languages);
                language = devLanguageRepo.SelectById(languageID);
            }

            ConsoleView.DisplayLanguage(language);
            ConsoleView.DisplayContinuePrompt();
        }

        private static void AddLanguage()
        {
            DevLanguageRepoSQL devLanguageRepo = new DevLanguageRepoSQL();
            Language language = new Language();

            language = ConsoleView.AddLanguage();
            using (devLanguageRepo)
            {
                devLanguageRepo.Insert(language);
            }

            ConsoleView.DisplayContinuePrompt();
        }

        private static void UpdateLanguage()
        {
            DevLanguageRepoSQL devLanguageRepo = new DevLanguageRepoSQL();
            List<Language> languages;
            Language language = new Language();
            int languageID;

            using (devLanguageRepo)
            {
                languages = devLanguageRepo.SelectAll();
                languageID = ConsoleView.GetLanguageID(languages);
                language = devLanguageRepo.SelectById(languageID);
                language = ConsoleView.UpdateLanguage(language);
                devLanguageRepo.Update(language);
            }

        }

        private static void DeleteLanguage()
        {
            DevLanguageRepoSQL devLanguageRepo = new DevLanguageRepoSQL();
            List<Language> languages = devLanguageRepo.SelectAll();
            Language language = new Language();
            int languageID;
            string message;

            languageID = ConsoleView.GetLanguageID(languages);

            using (devLanguageRepo)
            {
                devLanguageRepo.Delete(languageID);
            }

            ConsoleView.DisplayReset();

            // TODO refactor
            message = String.Format("Language ID: {0} had been deleted.", languageID);

            ConsoleView.DisplayMessage(message);
            ConsoleView.DisplayContinuePrompt();
        }

        private static void QueryLanguagesByPopularity()
        {
            DevLanguageRepoSQL devLanguageRepo = new DevLanguageRepoSQL();
            IEnumerable<Language> matchingLanguages = new List<Language>();
            decimal minPopularity;
            decimal maxPopularity;

            ConsoleView.GetPopularityQueryMinMaxValues(out minPopularity, out maxPopularity);

            using (devLanguageRepo)
            {
                matchingLanguages = devLanguageRepo.QueryByPopularity(minPopularity, maxPopularity);
            }

            ConsoleView.DisplayQueryResults(matchingLanguages);
            ConsoleView.DisplayContinuePrompt();
        }

        #endregion
    }
}
