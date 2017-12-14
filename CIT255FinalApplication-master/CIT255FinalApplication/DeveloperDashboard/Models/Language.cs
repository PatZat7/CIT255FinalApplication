using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperDashboard
{
   

    public class Language
    {

        public int LangID { get; set; }
        public string LangName { get; set; }
        public string ImgFilePath { get; set; }
        public string FileExtension { get; set; }
        public string Description { get; set; }
        public decimal StackOverflow { get; set; }
        public decimal IEEE { get; set; }
        public decimal PYPL { get; set; }

        public Language()
        {

        }

        public Language(int id, string Name, string imgFilePath, string fileExtension, string description, decimal stackOverflow, decimal ieee, decimal pypl)
        {
            this.LangID = id;
            this.LangName = Name;
            this.ImgFilePath = imgFilePath;
            this.FileExtension = fileExtension;
            this.Description = description;
            this.StackOverflow = stackOverflow;
            this.IEEE = ieee;
            this.PYPL = pypl;
        }

    }
}
