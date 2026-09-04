using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.BusinessLayer.Exceptions;
using Rentaly.DtoLayer.CarModelDtos;

namespace Rentaly.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarModelController : Controller
    {
        private readonly ICarModelService _carModelService;
        private readonly IBrandService _brandService;

        public CarModelController(ICarModelService carModelService, IBrandService brandService)
        {
            _carModelService = carModelService;
            _brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _carModelService.TGetListAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCarModel()
        {
            await LoadBrandsAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarModel(CreateCarModelDto dto)
        {
            try
            {
                await _carModelService.TInsertAsync(dto);
                TempData["Success"] = "Model başarıyla eklendi.";
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

            await LoadBrandsAsync();
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCarModel(int id)
        {
            var value = await _carModelService.TGetByIdAsync(id);

            if (value is null)
                return NotFound();

            var dto = new UpdateCarModelDto
            {
                CarModelId = value.CarModelId,
                ModelName = value.ModelName,
                BrandId = value.BrandId
            };

            await LoadBrandsAsync();
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCarModel(UpdateCarModelDto dto)
        {
            try
            {
                await _carModelService.TUpdateAsync(dto);
                TempData["Success"] = "Model başarıyla güncellendi.";
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

            await LoadBrandsAsync();
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCarModel(int id)
        {
            try
            {
                await _carModelService.TDeleteAsync(id);
                TempData["Success"] = "Model başarıyla silindi.";
            }
            catch (BusinessRuleException ex)
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToAction("Index");
        }

        private async Task LoadBrandsAsync()
        {
            var brands = await _brandService.TGetListAsync();
            ViewBag.Brands = new SelectList(brands, "BrandId", "BrandName");
        }
    }
}