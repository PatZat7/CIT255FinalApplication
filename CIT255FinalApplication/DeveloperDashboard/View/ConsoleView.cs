using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperDashboard;

namespace DeveloperDashboard
{
    public static class ConsoleView
    {
        #region ENUMERABLES


        #endregion

        #region FIELDS

        //
        // window size
        //
        private const int WINDOW_WIDTH = ViewSettings.WINDOW_WIDTH;
        private const int WINDOW_HEIGHT = ViewSettings.WINDOW_HEIGHT;

        //
        // horizontal and vertical margins in console window for display
        //
        private const int DISPLAY_HORIZONTAL_MARGIN = ViewSettings.DISPLAY_HORIZONTAL_MARGIN;
        private const int DISPALY_VERITCAL_MARGIN = ViewSettings.DISPALY_VERITCAL_MARGIN;

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region METHODS

        /// <summary>
        /// method to display the manager menu and get the user's choice
        /// </summary>
        /// <returns></returns>
        public static AppEnum.ManagerAction GetUserActionChoice()
        {
            AppEnum.ManagerAction userActionChoice = AppEnum.ManagerAction.None;
            //
            // set a string variable with a length equal to the horizontal margin and filled with spaces
            //
            string leftTab = ConsoleUtil.FillStringWithSpaces(DISPLAY_HORIZONTAL_MARGIN);

            //
            // set up display area
            //
            DisplayReset();

            //
            // display the menu
            //
            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("Developer Dashboard Menu", WINDOW_WIDTH));
            DisplayMessage("");

            Console.WriteLine(
                leftTab + "1. Display All Langauges" + Environment.NewLine +
                leftTab + "2. Display a Language Detail" + Environment.NewLine +
                leftTab + "3. Add a Language" + Environment.NewLine +
                leftTab + "4. Delete a Language" + Environment.NewLine +
                leftTab + "5. Edit a Language" + Environment.NewLine +
                leftTab + "6. Query Langauges by 2017 Stack Overflow Popularity" + Environment.NewLine +
                leftTab + "E. Exit" + Environment.NewLine);

            DisplayMessage("");
            DisplayPromptMessage("Enter the number/letter for the menu choice: ");
            ConsoleKeyInfo userResponse = Console.ReadKey(true);

            switch (userResponse.KeyChar)
            {
                case '1':
                    userActionChoice = AppEnum.ManagerAction.ListAllLanguages;
                    break;
                case '2':
                    userActionChoice = AppEnum.ManagerAction.DisplayLanguageDetail;
                    break;
                case '3':
                    userActionChoice = AppEnum.ManagerAction.AddLanguage;
                    break;
                case '4':
                    userActionChoice = AppEnum.ManagerAction.DeleteLanguage;
                    break;
                case '5':
                    userActionChoice = AppEnum.ManagerAction.UpdateLanguage;
                    break;
                case '6':
                    userActionChoice = AppEnum.ManagerAction.QueryLanguagesByPopularity;
                    break;
                case 'E':
                case 'e':
                    userActionChoice = AppEnum.ManagerAction.Quit;
                    break;
                default:
                    DisplayMessage("");
                    DisplayMessage("");
                    DisplayMessage("It appears you have selected an incorrect choice.");
                    DisplayMessage("");
                    DisplayMessage("Press any key to try again or the ESC key to exit.");

                    userResponse = Console.ReadKey(true);
                    if (userResponse.Key == ConsoleKey.Escape)
                    {
                        userActionChoice = AppEnum.ManagerAction.Quit;
                    }
                    break;
            }

            return userActionChoice;
        }

        /// <summary>
        /// method to display all ski run info
        /// </summary>
        public static void DisplayAllLanguages(List<Language> languages)
        {
            DisplayReset();

            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("Display All Langauges", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayMessage("All of the existing languages are displayed below;");
            DisplayMessage("");

            StringBuilder columnHeader = new StringBuilder();

            columnHeader.Append("LangID".PadRight(8));
            columnHeader.Append("LangName".PadRight(25));

            DisplayMessage(columnHeader.ToString());

            foreach (Language language in languages)
            {
                StringBuilder languageInfo = new StringBuilder();

                languageInfo.Append(language.LangID.ToString().PadRight(8));
                languageInfo.Append(language.LangName.PadRight(25));

                DisplayMessage(languageInfo.ToString());
            }
        }

        /// <summary>
        /// method to get the user's choice of ski run id
        /// </summary>
        public static int GetLanguageID(List<Language> languages)
        {
            int languageID = -1;

            DisplayAllLanguages(languages);

            DisplayMessage("");
            DisplayPromptMessage("Enter the Language ID: ");

            languageID = ConsoleUtil.ValidateIntegerResponse("Please enter the Language ID: ", Console.ReadLine());

            return languageID;
        }

        /// <summary>
        /// method to display a ski run info
        /// </summary>
        public static void DisplayLanguage(Language language)
        {
            DisplayReset();

            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("Language Detail", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayMessage(String.Format("Language: {0}", language.LangName));
            DisplayMessage("");

            DisplayMessage(String.Format("ID: {0}", language.LangID.ToString()));
            DisplayMessage(String.Format("Stack OverFlow Percent: {0}", language.StackOverflow.ToString()));

            DisplayMessage("");
        }

        /// <summary>
        /// method to add a ski run info
        /// </summary>
        public static Language AddLanguage()
        {
            Language language = new Language();

            DisplayReset();

            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("Add A Language", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayPromptMessage("Enter the Langauge ID: ");
            language.LangID = ConsoleUtil.ValidateIntegerResponse("Please enter the Language ID: ", Console.ReadLine());
            DisplayMessage("");

            DisplayPromptMessage("Enter the Langauge name: ");
            language.LangName = Console.ReadLine();
            DisplayMessage("");

            DisplayPromptMessage("Enter The Stack Overflow Popularity: ");
            language.StackOverflow = ConsoleUtil.ValidateDecimalResponse("Please Enter The Stack Overflow Popularity percent ", Console.ReadLine());

            return language;
        }

        public static Language UpdateLanguage(Language language)
        {
            string userResponse = "";

            DisplayReset();

            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("Edit A Language", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayMessage(String.Format("Current Name: {0}", language.LangName));
            DisplayPromptMessage("Enter a new name or just press Enter to keep the current name: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                language.LangName = userResponse;
            }

            DisplayMessage("");

            DisplayMessage(String.Format("Current Popularity on Stack Overflow: {0}", language.StackOverflow.ToString()));
            DisplayPromptMessage("Enter the new stack Overlflow Popularity or just press Enter to keep the current percent");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                language.StackOverflow = ConsoleUtil.ValidateDecimalResponse("Please enter the percent Popularity", userResponse);
            }

            DisplayContinuePrompt();

            return language;
        }

        /// <summary>
        /// method gets the minimum and maximum values for the vertical query
        /// </summary>
        /// <param name="minimumVertical">minimum vertical</param>
        /// <param name="maximumVertical">maximum vertical</param>
        public static void GetPopularityQueryMinMaxValues(out decimal minPopularity, out decimal maxPopularity)
        {
            minPopularity = 0;
            maxPopularity = 0;
            string userResponse = "";

            DisplayReset();

            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("Query Languages by Stack Overflow Popularity", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayPromptMessage("Enter the minimum Popularity: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                minPopularity = ConsoleUtil.ValidateDecimalResponse("Please enter the minimum popularity percent.", userResponse);
            }

            DisplayMessage("");

            DisplayPromptMessage("Enter the maximum Popularity: ");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                maxPopularity = ConsoleUtil.ValidateDecimalResponse("Please enter the maximum popularity percent.", userResponse);
            }

            DisplayMessage("");

            DisplayMessage(String.Format("You have entered {0} percent as the minimum value and {1} as the maximum value.", minPopularity, maxPopularity));

            DisplayMessage("");

            DisplayContinuePrompt();
        }

        public static void DisplayQueryResults(IEnumerable<Language> matchingLanguages)
        {
            DisplayReset();

            DisplayMessage("");
            Console.WriteLine(ConsoleUtil.Center("Display Language Query Results", WINDOW_WIDTH));
            DisplayMessage("");

            DisplayMessage("All of the matching languages are displayed below;");
            DisplayMessage("");

            StringBuilder columnHeader = new StringBuilder();

            columnHeader.Append("ID".PadRight(8));
            columnHeader.Append("Langauge".PadRight(25));

            DisplayMessage(columnHeader.ToString());

            foreach (Language language in matchingLanguages)
            {
                StringBuilder languageInfo = new StringBuilder();

                languageInfo.Append(language.LangID.ToString().PadRight(8));
                languageInfo.Append(language.LangName.PadRight(25));

                DisplayMessage(languageInfo.ToString());
            }
        }

        /// <summary>
        /// reset display to default size and colors including the header
        /// </summary>
        public static void DisplayReset()
        {
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);

            Console.Clear();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("The Developer Dashboard", WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));

            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// display the Continue prompt
        /// </summary>
        public static void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;

            Console.WriteLine();

            Console.WriteLine(ConsoleUtil.Center("Press any key to continue.", WINDOW_WIDTH));
            ConsoleKeyInfo response = Console.ReadKey();

            Console.WriteLine();

            Console.CursorVisible = true;
        }


        /// <summary>
        /// display the Exit prompt
        /// </summary>
        public static void DisplayExitPrompt()
        {
            DisplayReset();

            Console.CursorVisible = false;

            Console.WriteLine();
            DisplayMessage("Thank you for using my application. Press any key to Exit.");

            Console.ReadKey();

            System.Environment.Exit(1);
        }

        /// <summary>
        /// display the welcome screen
        /// </summary>
        public static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("Welcome to", WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("The Developer Dashboard", WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));

            Console.ResetColor();
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a message in the message area
        /// </summary>
        /// <param name="message">string to display</param>
        public static void DisplayMessage(string message)
        {
            //
            // calculate the message area location on the console window
            //
            const int MESSAGE_BOX_TEXT_LENGTH = WINDOW_WIDTH - (2 * DISPLAY_HORIZONTAL_MARGIN);
            const int MESSAGE_BOX_HORIZONTAL_MARGIN = DISPLAY_HORIZONTAL_MARGIN;

            // message is not an empty line, display text
            if (message != "")
            {
                //
                // create a list of strings to hold the wrapped text message
                //
                List<string> messageLines;

                //
                // call utility method to wrap text and loop through list of strings to display
                //
                messageLines = ConsoleUtil.Wrap(message, MESSAGE_BOX_TEXT_LENGTH, MESSAGE_BOX_HORIZONTAL_MARGIN);
                foreach (var messageLine in messageLines)
                {
                    Console.WriteLine(messageLine);
                }
            }
            // display an empty line
            else
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// display a message in the message area without a new line for the prompt
        /// </summary>
        /// <param name="message">string to display</param>
        public static void DisplayPromptMessage(string message)
        {
            //
            // calculate the message area location on the console window
            //
            const int MESSAGE_BOX_TEXT_LENGTH = WINDOW_WIDTH - (2 * DISPLAY_HORIZONTAL_MARGIN);
            const int MESSAGE_BOX_HORIZONTAL_MARGIN = DISPLAY_HORIZONTAL_MARGIN;

            //
            // create a list of strings to hold the wrapped text message
            //
            List<string> messageLines;

            //
            // call utility method to wrap text and loop through list of strings to display
            //
            messageLines = ConsoleUtil.Wrap(message, MESSAGE_BOX_TEXT_LENGTH, MESSAGE_BOX_HORIZONTAL_MARGIN);

            for (int lineNumber = 0; lineNumber < messageLines.Count() - 1; lineNumber++)
            {
                Console.WriteLine(messageLines[lineNumber]);
            }

            Console.Write(messageLines[messageLines.Count() - 1]);
        }


        #endregion
    }
}
