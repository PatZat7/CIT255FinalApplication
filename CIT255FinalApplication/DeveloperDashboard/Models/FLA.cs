namespace DeveloperDashboard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

 
    public class FLA
    {
      
        public int flaID { get; set; }
        public int? LangID { get; set; }
        public int? FLAtypeID { get; set; }      
        public string flaName { get; set; }       
        public string Description { get; set; }      
        public string ImgFilePath { get; set; }      
        public string URL { get; set; }
        public int? PlatformID { get; set; }
        
        public FLA()
        {

        }

        public FLA(int FLAid, int langID, int flaTypeID, string Name, string description, string imgFilePath, string url, int platformID)
        {
            this.flaID = FLAid;
            this.LangID = langID;
            this.FLAtypeID = flaTypeID;
            this.flaName = Name;
            this.Description = description;
            this.ImgFilePath = imgFilePath;
            this.URL = url;         
            this.PlatformID = platformID;
           
        }


    }
}
