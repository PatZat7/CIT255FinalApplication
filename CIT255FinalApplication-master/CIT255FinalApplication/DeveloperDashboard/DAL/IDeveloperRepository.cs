using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperDashboard
{
    interface IDeveloperRepository : IDisposable
    {
        Language SelectById(int LangID);
        List<Language> SelectAll();
        void Insert(Language language);
        void Update(Language language);
        void Delete(int LangID);

  
    }
}
