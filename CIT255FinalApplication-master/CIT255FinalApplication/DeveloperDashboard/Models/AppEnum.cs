using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperDashboard
{
   public class AppEnum
    {
        public enum ManagerAction
        {
            None,
            ListAllLanguages,
            DisplayLanguageDetail,
            DeleteLanguage,
            AddLanguage,
            UpdateLanguage,
            QueryLanguagesByPopularity,
            Quit
        }
    }
}
