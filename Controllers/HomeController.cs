﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WorldCup2022_MVC.Interfaces;
using WorldCup2022_MVC.Models;
using WorldCup2022_MVC.ViewModels;

namespace WorldCup2022_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITeamService _TeamService;
        public List<TeamVM> List;

        private ITeamRespository _TeamRespository;
        public HomeController(ILogger<HomeController> logger, ITeamService TeamService, ITeamRespository teamRespository)
        {
            _TeamService = TeamService;
            _logger = logger;
            _TeamRespository = teamRespository;
        }
        //public ITeamService Get_TeamService()
        //{
        //    return _TeamService;
        //}

        public IActionResult Index(ITeamService TeamService)
        {
            //List = _TeamService.GetAllEntries();
            List = (List<TeamVM>)_TeamRespository.GetAllEntries();
            return View(List);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}