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
            return View("Index", Country.SortBy("code"));
        }

        [HttpGet("/country/name")]
        public ActionResult SortByName()
        {
            return View("Index", Country.SortBy("name"));
        }


        [HttpGet("/country/continent")]
        public ActionResult SortByContinent()
        {
            return View("Index", Country.SortBy("continent"));
        }

        [HttpGet("/country/population")]
        public ActionResult SortByPopulation()
        {
            return View("Index", Country.SortBy("population"));
        }
    }

}
