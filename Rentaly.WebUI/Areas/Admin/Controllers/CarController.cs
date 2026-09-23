using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.BusinessLayer.Exceptions;
using Rentaly.DtoLayer.CarDtos;
using Rentaly.EntityLayer.Enums;
using Rentaly.WebUI.Helpers;

namespace Rentaly.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICarModelService _carModelService;
        private readonly IBranchService _branchService;
        private readonly IMapper _mapper;

        public CarController(
            ICarService carService,
            ICarModelService carModelService,
            IBranchService branchService,
            IMapper mapper)
        {
            _carService = carService;
            _carModelService = carModelService;
            _branchService = branchService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _carService.TGetListAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            await LoadSelectListsAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto dto)
        {
            try
            {
                await _carService.TInsertAsync(dto);
                TempData["Success"] = "Araç başarıyla eklendi.";
                return RedirectToAction("Index");
            }
            catch (BusinessValidationException ex)
            {
                foreach (var error in ex.Errors)
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            catch (BusinessRuleException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            await LoadSelectListsAsync();
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var value = await _carService.TGetByIdAsync(id);

            if (value is null)
                return NotFound();

            var dto = _mapper.Map<UpdateCarDto>(value);

            await LoadSelectListsAsync();
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto dto)
        {
            try
            {
                await _carService.TUpdateAsync(dto);
                TempData["Success"] = "Araç başarıyla güncellendi.";
                return RedirectToAction("Index");
            }
            catch (BusinessValidationException ex)
            {
                foreach (var error in ex.Errors)
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            catch (BusinessRuleException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            await LoadSelectListsAsync();
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCar(int id)
        {
            try
            {
                await _carService.TDeleteAsync(id);
                TempData["Success"] = "Araç başarıyla silindi.";
            }
            catch (BusinessRuleException ex)
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToAction("Index");
        }

        private async Task LoadSelectListsAsync()
        {
            var models = await _carModelService.TGetListAsync();
            var branches = await _branchService.TGetListAsync();

            ViewBag.CarModels = new SelectList(
                models.Select(x => new { x.CarModelId, DisplayName = $"{x.BrandName} {x.ModelName}" }),
                "CarModelId", "DisplayName");

            ViewBag.Branches = new SelectList(branches, "BranchId", "BranchName");
            ViewBag.FuelTypes = EnumHelper.ToSelectList<FuelType>();
            ViewBag.Transmissions = EnumHelper.ToSelectList<TransmissionType>();
        }
    }
}