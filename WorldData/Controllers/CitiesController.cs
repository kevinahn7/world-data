using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorldData.Models;
using WorldData;

namespace WorldData.Controllers
{
    public class CitiesController : Controller
    {
        [HttpGet("/city")]
        public ActionResult CityIndex()
        {
            return View(City.GetAllCities());
        }


        [HttpGet("/city/name")]
        public ActionResult SortByName()
        {
            City.SetisNameAscend(!City.GetisNameAscend());
            City.SetisCodeAscend(false);
            City.SetisPopulationAscend(false);
            return View("CityIndex", City.SortBy("name", City.GetisNameAscend()));
        }

        [HttpGet("/city/code")]
        public ActionResult SortByCode()
        {
            City.SetisNameAscend(false);
            City.SetisCodeAscend(!City.GetisCodeAscend());
            City.SetisPopulationAscend(false);
            return View("CityIndex", City.SortBy("countrycode", City.GetisCodeAscend()));
        }

        [HttpGet("/city/population")]
        public ActionResult SortByPopulation()
        {
            City.SetisNameAscend(false);
            City.SetisCodeAscend(false);
            City.SetisPopulationAscend(!City.GetisPopulationAscend());
            return View("CityIndex", City.SortBy("population", City.GetisPopulationAscend()));
        }





        [HttpGet("/city/name/{code}")]
        public ActionResult DisplayCities(string code)
        {
            City.SetisNameAscend(!City.GetisNameAscend());
            City.SetisCodeAscend(false);
            City.SetisPopulationAscend(false);
            return View("CityIndex", City.GetSelectedCities());
        }
    }

}

