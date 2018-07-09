using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldData;
using System;

namespace WorldData.Models
{
    public class Country
    {
        private string _code;
        private string _name;
        private string _continent;
        private int _population;
        private static bool _isCodeAscend = false;
        private static bool _isNameAscend = false;
        private static bool _isContinentAscend = false;
        private static bool _isPopulationAscend = false;


        public Country(string code, string name, string continent, int population)
        {
            _code = code;
            _name = name;
            _continent = continent;
            _population = population;
        }

        public string GetCode()
        {
            return _code;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetContinent()
        {
            return _continent;
        }

        public int GetPopulation()
        {
            return _population;
        }

        public static bool GetisCodeAscend()
        {
            return _isCodeAscend;
        }

        public static void SetisCodeAscend(bool input)
        {
            _isCodeAscend = input;
        }

        public static bool GetisNameAscend()
        {
            return _isNameAscend;
        }

        public static void SetisNameAscend(bool input)
        {
            _isNameAscend = input;
        }

        public static bool GetisContinentAscend()
        {
            return _isContinentAscend;
        }

        public static void SetisContinentAscend(bool input)
        {
            _isContinentAscend = input;
        }

        public static bool GetisPopulationAscend()
        {
            return _isPopulationAscend;
        }

        public static void SetisPopulationAscend(bool input)
        {
            _isPopulationAscend = input;
        }

        public static List<Country> GetAllCountry()
        {
            List<Country> allCountries = new List<Country> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM country;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                string countryCode = rdr.GetString(0);
                string countryName = rdr.GetString(1);
                string countryContinent = rdr.GetString(2);
                int countryPopulation = rdr.GetInt32(3);
                Country newCountry = new Country(countryCode, countryName, countryContinent, countryPopulation);
                allCountries.Add(newCountry);
            }
            conn.Close();
            if (conn != null){
                conn.Dispose();
            }
            return allCountries;
        }

        public static List<Country> SortBy(string column, bool isAscend)
        {
            List<Country> allCountries = new List<Country> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            if (isAscend)
            {
                cmd.CommandText = @"SELECT * FROM country ORDER BY " + column + " ASC;";
            }
            else
            {
                cmd.CommandText = @"SELECT * FROM country ORDER BY " + column + " DESC;";
            }
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                string countryCode = rdr.GetString(0);
                string countryName = rdr.GetString(1);
                string countryContinent = rdr.GetString(2);
                int countryPopulation = rdr.GetInt32(3);
                Country newCountry = new Country(countryCode, countryName, countryContinent, countryPopulation);
                allCountries.Add(newCountry);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCountries;
        }
    }
}
