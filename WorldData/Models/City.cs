using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldData;
using System;

namespace WorldData.Models
{
    public class City
    {
        private int _id;
        private string _name;
        private string _code;
        private int _population;
        private static bool _isNameAscend = false;
        private static bool _isCodeAscend = false;
        private static bool _isPopulationAscend = false;

        public City(int id, string name, string code, int population)
        {
            _id = id;
            _name = name;
            _code = code;
            _population = population;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetCode()
        {
            return _code;
        }

        public int GetPopulation()
        {
            return _population;
        }

        public static bool GetisNameAscend()
        {
            return _isNameAscend;
        }

        public static void SetisNameAscend(bool input)
        {
            _isNameAscend = input;
        }

        public static bool GetisCodeAscend()
        {
            return _isCodeAscend;
        }

        public static void SetisCodeAscend(bool input)
        {
            _isCodeAscend = input;
        }

        public static bool GetisPopulationAscend()
        {
            return _isPopulationAscend;
        }

        public static void SetisPopulationAscend(bool input)
        {
            _isPopulationAscend = input;
        }


        public static List<City> GetAllCities()
        {
            List<City> allCities = new List<City> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM city ORDER BY name;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int cityId = rdr.GetInt32(0);
                string cityName = rdr.GetString(1);
                string cityCode = rdr.GetString(2);
                int cityPopulation = rdr.GetInt32(3);
                City newCity = new City(cityId, cityName, cityCode, cityPopulation);
                allCities.Add(newCity);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCities;
        }

        public static List<City> GetSpecificCities(string code)
        {
            List<City> allCities = new List<City> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM city ORDER BY name;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int cityId = rdr.GetInt32(0);
                string cityName = rdr.GetString(1);
                string cityCode = rdr.GetString(2);
                int cityPopulation = rdr.GetInt32(3);
                City newCity = new City(cityId, cityName, cityCode, cityPopulation);
                allCities.Add(newCity);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCities;
        }

        public static List<City> SortBy(string column, bool isAscend)
        {
            List<City> allCities = new List<City> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            if (isAscend)
            {
                cmd.CommandText = @"SELECT * FROM city ORDER BY " + column + " ASC;";
            }
            else
            {
                cmd.CommandText = @"SELECT * FROM city ORDER BY " + column + " DESC;";
            }


            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int cityId = rdr.GetInt32(0);
                string cityName = rdr.GetString(1);
                string cityCode = rdr.GetString(2);
                int cityPopulation = rdr.GetInt32(3);
                City newCity = new City(cityId, cityName, cityCode, cityPopulation);
                allCities.Add(newCity);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCities;
        }

    }
}
