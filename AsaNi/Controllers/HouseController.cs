using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AsaNi.Business;
using AsaNi.Business.Contracts;
using AsaNi.DomainClasses;
using AsaNi.Helper;
using AsaNi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace AsaNi.Controllers
{
    public class HouseController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHouseManager _houseManager;
        private readonly IOwnerManager _ownerManager;
        public HouseController(ILogger<HomeController> logger, IHouseManager houseManager, IOwnerManager ownerManager)
        {
            _logger = logger;
            _houseManager = houseManager;
            _ownerManager = ownerManager;
        }

        public IActionResult List()
        {
            try
            {
                var houses = _houseManager.GetAll();
                return View(houses);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return View("Error", new ErrorViewModel() { Exception = ex, ActionName = "List", ControllerName = "House", RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        public IActionResult Details(int id)
        {
            try
            {
                var foundHouse = _houseManager.GetById(id);
                var operateHouseViewModel = ObjectAutoMapper.MapToOperateHouseViewModel(foundHouse);
                return View(operateHouseViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return View("Error", new ErrorViewModel() { Exception = ex, ActionName = "Details", ControllerName = "House", RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        public IActionResult Operate(int id)
        {
            try
            {

                ViewBag.Owners = new SelectList(_ownerManager.GetAll().Select(c => new OwnerViewModel
                {
                    FullName = c.FirstName + " " + c.LastName,
                    Id = c.Id
                }), "Id", "FullName");

                if (id != 0)
                {
                    var foundHouse = _houseManager.GetById(id);

                    var operateHouseViewModel = ObjectAutoMapper.MapToOperateHouseViewModel(foundHouse);

                    if (operateHouseViewModel != null)
                    {
                        ViewBag.OperationName = "Edit";
                        return View("Operate", operateHouseViewModel);
                    }
                    else
                    {
                        ViewBag.OperationName = "Create";
                        return View("Operate");
                    }
                }
                else
                {
                    ViewBag.OperationName = "Create";
                    return View("Operate");
                }

            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return View("Error", new ErrorViewModel() { Exception = ex, ActionName = "Operate", ControllerName = "House", RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Operate(OperateHouseViewModel operateHouseViewModel)
        {
            try
            {
                var house = ObjectAutoMapper.MapToHouse(operateHouseViewModel);

                ViewBag.Owners = new SelectList(_ownerManager.GetAll().Select(c => new OwnerViewModel
                {
                    FullName = c.FirstName + " " + c.LastName,
                    Id = c.Id
                }), "Id", "FullName");

                if (ModelState.IsValid)
                {
                    if (house.Id != 0)
                    {
                        house.UpdatedDateTime = DateTime.Now;
                        house.UpdatedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                        _houseManager.Update(house);
                        return RedirectToAction("List");
                    }
                    else if (house.Id == 0)
                    {
                        house.CreatedDateTime = DateTime.Now;
                        house.CreatedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                        _houseManager.Create(house);
                        return RedirectToAction("List");
                    }
                    else
                        return View("Operate");
                }
                else
                    return View("Operate");
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return View("Error", new ErrorViewModel() { Exception = ex, ActionName = "Operate", ControllerName = "House", RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        public IActionResult Delete(House house)
        {
            try
            {
                _houseManager.Delete(house);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return View("Error", new ErrorViewModel() { Exception = ex, ActionName = "Delete", ControllerName = "House", RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
}
