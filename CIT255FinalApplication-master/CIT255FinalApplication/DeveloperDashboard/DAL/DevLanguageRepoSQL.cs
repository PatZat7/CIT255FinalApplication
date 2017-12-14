using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace DeveloperDashboard
{
    public class DevLanguageRepoSQL : IDeveloperRepository
    {
        private IEnumerable<Language> _languages = new List<Language>();

        public DevLanguageRepoSQL()
        {
            _languages = ReadAllLanguages();
        }

        private IEnumerable<Language> ReadAllLanguages()
        {
            IList<Language> languages = new List<Language>();

            string connString = GetConnectionString();
            string sqlCommandString = "SELECT * from Languages";

            using (SqlConnection sqlConn = new SqlConnection(connString))
            using (SqlCommand sqlCommand = new SqlCommand(sqlCommandString, sqlConn))
            {
                try
                {
                    sqlConn.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                Language language = new Language();
                                language.LangID = Convert.ToInt32(reader["LangID"]);
                                language.LangName = reader["LangName"].ToString();
                                language.ImgFilePath = reader["ImgFilePath"].ToString();
                                language.FileExtension = reader["FileExtension"].ToString();
                                language.Description = reader["Description"].ToString();
                                //TODO null coalesce operator (use of syntactic sugar)
                                if (!Convert.IsDBNull(reader["StackOverflow"])) {
                                 language.StackOverflow = Convert.ToDecimal(reader["StackOverflow"]);
                                }
                                else
                                {
                                    language.StackOverflow = 0;
                                }

                                if (!Convert.IsDBNull(reader["IEEE"]))
                                {
                                    language.IEEE = Convert.ToDecimal(reader["IEEE"]);
                                }
                                else
                                {
                                    language.IEEE = 0;
                                }

                                if (!Convert.IsDBNull(reader["PYPL"]))
                                {
                                    language.PYPL = Convert.ToDecimal(reader["PYPL"]);
                                }
                                else
                                {
                                    language.PYPL = 0;
                                }
                                    


                                languages.Add(language);
                            }
                        }
                        
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("SQL Exception: {0}", sqlEx.Message);
                    Console.WriteLine(sqlCommandString);
                }
            }

            return languages;
        }

        //TODO CRUD Operations
        /// <summary>
        /// method to return a language given the ID
        /// uses a DataSet to hold language info
        /// </summary>
        /// <param name="ID">int ID</param>
        /// <returns>ski run object</returns>
        public Language SelectById(int Id)
        {
            return _languages.Where(lg => lg.LangID == Id).FirstOrDefault();
        }

        /// <summary>
        /// method to return a list of languages
        /// uses a DataSet to hold language info
        /// </summary>
        /// <returns>list of ski run objects</returns>
        public List<Language> SelectAll()
        {
            return _languages as List<Language>;
        }




        /// <summary>
        /// method to add a new language
        /// </summary>
        /// <param name="language"></param>
        public void Insert(Language language)
        {
            string connString = GetConnectionString();

            // build out SQL command
            var sb = new StringBuilder("INSERT INTO dbo.Languages");
            sb.Append(" ([LangID],[LangName],[ImgFilePath],[FileExtension],[Description],[StackOverflow],[IEEE],[PYPL])");
            sb.Append(" Values (");
            sb.Append("'").Append(language.LangID).Append("',");
            sb.Append("'").Append(language.LangName).Append("',");
            sb.Append("'").Append(language.ImgFilePath).Append("',");
            sb.Append("'").Append(language.FileExtension).Append("',");
            sb.Append("'").Append(language.Description).Append("',");
            sb.Append("'").Append(language.StackOverflow).Append("',");
            sb.Append("'").Append(language.IEEE).Append("',");
            sb.Append("'").Append(language.PYPL).Append("')");
            string sqlCommandString = sb.ToString();

            using (SqlConnection sqlConn = new SqlConnection(connString))
            using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
            {
                try
                {
                    sqlConn.Open();
                    sqlAdapter.InsertCommand = new SqlCommand(sqlCommandString, sqlConn);
                    sqlAdapter.InsertCommand.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("SQL Exception: {0}", sqlEx.Message);
                    Console.WriteLine(sqlCommandString);
                }
            }
        }

        /// <summary>
        /// method to delete a language by LangID
        /// </summary>
        /// <param name="ID"></param>
        public void Delete(int LangID)
        {
            string connString = GetConnectionString();

            // build out SQL command
            var sb = new StringBuilder("DELETE FROM Languages");
            sb.Append(" WHERE ID = ").Append(LangID);
            string sqlCommandString = sb.ToString();

            using (SqlConnection sqlConn = new SqlConnection(connString))
            using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
            {
                try
                {
                    sqlConn.Open();
                    sqlAdapter.DeleteCommand = new SqlCommand(sqlCommandString, sqlConn);
                    sqlAdapter.DeleteCommand.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("SQL Exception: {0}", sqlEx.Message);
                    Console.WriteLine(sqlCommandString);
                }
            }
        }

        /// <summary>
        /// method to update an existing language
        /// </summary>
        /// <param name="language">language object</param>
        public void Update(Language language)
        {
            string connString = GetConnectionString();

            // build out SQL command
            var sb = new StringBuilder("UPDATE Languages SET ");
            sb.Append("Name = '").Append(language.LangName).Append("', ");
            sb.Append("ImgFilePath = ").Append(language.ImgFilePath).Append(" ");
            sb.Append("FileExtension = ").Append(language.FileExtension).Append(" ");
            sb.Append("Description = ").Append(language.Description).Append(" ");
            sb.Append("StackOverflow = ").Append(language.StackOverflow).Append(" ");
            sb.Append("IEEE = ").Append(language.IEEE).Append(" ");
            sb.Append("PYPL = ").Append(language.PYPL).Append(" ");
            sb.Append("WHERE ");
            sb.Append("ID = ").Append(language.LangID);
            string sqlCommandString = sb.ToString();

            using (SqlConnection sqlConn = new SqlConnection(connString))
            using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
            {
                try
                {
                    sqlConn.Open();
                    sqlAdapter.UpdateCommand = new SqlCommand(sqlCommandString, sqlConn);
                    sqlAdapter.UpdateCommand.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("SQL Exception: {0}", sqlEx.Message);
                    Console.WriteLine(sqlCommandString);
                }
            }
        }

        public IEnumerable<Language> QueryByPopularity(decimal minPopularity, decimal maxPopularity)
        {
            return _languages.Where(lg => lg.StackOverflow >= minPopularity && lg.StackOverflow <= maxPopularity);
        }

        private static string GetConnectionString()
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            var settings = ConfigurationManager.ConnectionStrings["ProgrammerData_Local"];

            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }



        /// <summary>
        /// method to handle the IDisposable interface contract
        /// </summary>
        public void Dispose()
        {
            _languages = null;
        }
    }
}
