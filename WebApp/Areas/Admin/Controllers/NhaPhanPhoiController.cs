using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class NhaPhanPhoiController : Controller
    {
        private readonly INhaPhanPhoiRepository _nhaPhanPhoiRepository;

        public NhaPhanPhoiController(INhaPhanPhoiRepository nhaPhanPhoiRepository)
        {
            _nhaPhanPhoiRepository = nhaPhanPhoiRepository;
        }

        // Hiển thị danh sách nhà phân phối
        public async Task<IActionResult> Index()
        {
            var nppList = await _nhaPhanPhoiRepository.GetAllAsync();
            return View(nppList);
        }

        // Hiển thị form thêm nhà phân phối mới

        public IActionResult AddAsync()
        {
            return View();
        }

        // Xử lý thêm nhà phân phối mới

        [HttpPost]
        public async Task<IActionResult> Add(NhaPhanPhoi vendor, IFormFile HinhAnhNPP)
        {
            vendor.Idnpp = Guid.NewGuid().ToString();
            ModelState.Remove("Idnpp");
            if (ModelState.IsValid)
            {
                if (HinhAnhNPP is not null)
                {
                    // Lưu hình ảnh sản phẩm
                    vendor.HinhAnhNPP = await SaveImage(HinhAnhNPP);
                }
                await _nhaPhanPhoiRepository.AddAsync(vendor);
                return RedirectToAction(nameof(Index));
            }
            // Nếu ModelState không hợp lệ, hiển thị form với dữ liệu đã nhập
            return View(vendor);
        }

        //Xử lý lưu đường dẫn hình ảnh
        private async Task<string> SaveImage(IFormFile image)
        {
            var savePath = Path.Combine("wwwroot/images/NppImg", image.FileName); // Thay đổi đường dẫn theo cấu hình của bạn
            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return "/images/NppImg/" + image.FileName; // Trả về đường dẫn tương đối
        }

        public async Task<IActionResult> Action()
        {
            var vendors = await _nhaPhanPhoiRepository.GetAllAsync();
            if (vendors.Any())
            {
                return View(vendors);
            }
            return RedirectToAction("Page");
        }


        // Hiển thị thông tin chi tiết nhà phân phối
        public async Task<IActionResult> Display(string id)
        {
            var vendor = await _nhaPhanPhoiRepository.GetByIdAsync(id);
            if (vendor is null)
            {
                return NotFound();
            }
            return View(vendor);
        }

        // Hiển thị form cập nhật nhà phân phối
        public async Task<IActionResult> Update(string id)
        {
            var vendor = await _nhaPhanPhoiRepository.GetByIdAsync(id);
            if (vendor is null)
            {
                return NotFound();
            }

            return View(vendor);
        }

        // Xử lý cập nhật nhà phân phối

        [HttpPost]
        public async Task<IActionResult> Update(string id, NhaPhanPhoi vendor, IFormFile HinhAnhNPP)
        {
            if (id != vendor.Idnpp)
            {
                return BadRequest();
            }
            ModelState.Remove("HinhAnhNPP");
            if (ModelState.IsValid)
            {
                if (HinhAnhNPP is not null)
                {
                    // Lưu hình ảnh sản phẩm
                    vendor.HinhAnhNPP = await SaveImage(HinhAnhNPP);
                }
                await _nhaPhanPhoiRepository.UpdateAsync(vendor);
                return RedirectToAction(nameof(Index));
            }
            return View(vendor);
        }

        // Hiển thị form xác nhận xóa nhà phân phối

        public async Task<IActionResult> Delete(string id)
        {
            var vendor = await _nhaPhanPhoiRepository.GetByIdAsync(id);
            if (vendor == null)
            {
                return NotFound();
            }
            return View(vendor);
        }

        // Xử lý xóa sản phẩm

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _nhaPhanPhoiRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Page()
        {
            return View();
        }
    }
}
