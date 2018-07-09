using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorldData.Models;
using WorldData;

namespace WorldData.Controllers
{
    public class CountriesController : Controller
    {
        [HttpGet("/country")]
        public ActionResult CountryIndex()
        {
            return View(Country.GetAllCountry());
        }

        [HttpGet("/country/code")]
        public ActionResult SortByCode()
        {
            Country.SetisCodeAscend(!Country.GetisCodeAscend());
            Country.SetisNameAscend(false);
			Country.SetisContinentAscend(false);
            Country.SetisPopulationAscend(false);
            return View("CountryIndex", Country.SortBy("code", Country.GetisCodeAscend()));
        }

        [HttpGet("/country/name")]
        public ActionResult SortByName()
        {
            Country.SetisCodeAscend(false);
            Country.SetisNameAscend(!Country.GetisNameAscend());
            Country.SetisContinentAscend(false);
            Country.SetisPopulationAscend(false);
            return View("CountryIndex", Country.SortBy("name", Country.GetisNameAscend()));
        }

        [HttpGet("/country/continent")]
        public ActionResult SortByContinent()
        {
            Country.SetisCodeAscend(false);
            Country.SetisNameAscend(false);
            Country.SetisContinentAscend(!Country.GetisContinentAscend());
            Country.SetisPopulationAscend(false);
            return View("CountryIndex", Country.SortBy("continent", Country.GetisContinentAscend()));
        }

        [HttpGet("/country/population")]
        public ActionResult SortByPopulation()
        {
            Country.SetisCodeAscend(false);
            Country.SetisNameAscend(false);
            Country.SetisContinentAscend(false);
            Country.SetisPopulationAscend(!Country.GetisPopulationAscend());
            return View("CountryIndex", Country.SortBy("population", Country.GetisPopulationAscend()));
        }

        [HttpGet("/country/{code}")]
        public ActionResult DisplayCities(string code)
        {
            return View("CityIndex", City.GetSpecificCities(code));
        }

        [HttpGet("/country/pop-filter")]
        public ActionResult FilterCountries(string min, string max)
        {
            if (min == null)
            {
                min = "0";
            }
            if (max == null)
            {
                max = "2000000000";
            }
            int minInt = int.Parse(min);
            int maxInt = int.Parse(max);
            return View("CountryIndex", Country.FilterCountries(minInt, maxInt));
        }

        [HttpGet("/country/continent-filter")]
        public ActionResult FilterCountriesByContinent(string africa, string antarctica, string asia, string europe, string northAmerica, string oceania, string southAmerica)
        {
            List<string> continentList = Country.IsChecked(africa, antarctica, asia, europe, northAmerica, oceania, southAmerica);

            return View("CountryIndex", Country.FilterCountriesByContinent(continentList));
        }
    }

}
