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
        public ActionResult Index()
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
            return View("Index", Country.SortBy("code", Country.GetisCodeAscend()));
        }

        [HttpGet("/country/name")]
        public ActionResult SortByName()
        {
            Country.SetisCodeAscend(false);
            Country.SetisNameAscend(!Country.GetisNameAscend());
            Country.SetisContinentAscend(false);
            Country.SetisPopulationAscend(false);
            return View("Index", Country.SortBy("name", Country.GetisNameAscend()));
        }

        [HttpGet("/country/continent")]
        public ActionResult SortByContinent()
        {
            Country.SetisCodeAscend(false);
            Country.SetisNameAscend(false);
            Country.SetisContinentAscend(!Country.GetisContinentAscend());
            Country.SetisPopulationAscend(false);
            return View("Index", Country.SortBy("continent", Country.GetisContinentAscend()));
        }

        [HttpGet("/country/population")]
        public ActionResult SortByPopulation()
        {
            Country.SetisCodeAscend(false);
            Country.SetisNameAscend(false);
            Country.SetisContinentAscend(false);
            Country.SetisPopulationAscend(!Country.GetisPopulationAscend());
            return View("Index", Country.SortBy("population", Country.GetisPopulationAscend()));
        }

        [HttpGet("/country/{code}")]
        public ActionResult DisplayCities(string code)
        {
            return View("city/Index", City.GetSpecificCities(code));
        }
    }

}
