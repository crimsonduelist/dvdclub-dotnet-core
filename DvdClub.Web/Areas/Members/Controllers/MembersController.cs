using AutoMapper;
using DvdClub.Core.Entities;
using DvdClub.Core.Interfaces;
using DvdClub.Web.Areas.Members.Models;
//using DvdClub.Web.Mappings;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdClub.Web.Areas.Members {
    public class MembersController : Controller {
        private readonly IUsersService db;
        protected IMapper _mapper { get; set; }

        //constructor
        public MembersController(IUsersService db/*, IMapper mapper*/) {
            this.db = db;
            //this._mapper = mapper;
        }
        // GET: Users
        //[HttpGet]
        //public ActionResult Index() {
        //    var users = db.GetAll();
        //    var membersIndexViewModel = new MembersIndexViewModel(users);
        //    return View(membersIndexViewModel);
        //}

    }
}