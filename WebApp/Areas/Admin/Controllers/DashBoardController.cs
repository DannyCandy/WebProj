using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashBoardController : Controller
    {
        private readonly ISanPhamRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public DashBoardController(ISanPhamRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        // Hiển thị danh sách sản phẩm
        public async Task<IActionResult> Index()
        {
            var productList = await _productRepository.GetAllAsync();
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(productList);
        }

        // Hiển thị form thêm sản phẩm mới
        
        public async Task<IActionResult> AddAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        // Xử lý thêm sản phẩm mới
       
        [HttpPost]
        public async Task<IActionResult> Add(SanPham product, IFormFile imageUrl)
        {
            if (ModelState.IsValid)
            {
                if (imageUrl.Length > 0)
                {
                    using (var dataStream = new MemoryStream())
                    {
                        await imageUrl.CopyToAsync(dataStream);
                        product.HinhAnhSp = dataStream.ToArray();
                    }
                }
                await _productRepository.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }
            // Nếu ModelState không hợp lệ, hiển thị form với dữ liệu đã nhập
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(product);
        }

        public async Task<IActionResult> Action()
        {
            var products = await _productRepository.GetAllAsync();
            if (products.Any())
            {
                return View(products);
            }
            return RedirectToAction("Page");
        }


        // Hiển thị thông tin chi tiết sản phẩm
        public async Task<IActionResult> Display(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(product);
        }

        // Hiển thị form cập nhật sản phẩm
        
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", product.Idcategory);
            return View(product);
        }

        // Xử lý cập nhật sản phẩm
        
        [HttpPost]
        public async Task<IActionResult> Update(string id, SanPham product, IFormFile imageUrl)
        {
            if (id != product.Idsp)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                if (imageUrl.Length > 0)
                {
                    using (var dataStream = new MemoryStream())
                    {
                        await imageUrl.CopyToAsync(dataStream);
                        product.HinhAnhSp = dataStream.ToArray();
                    }
                }
                await _productRepository.UpdateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(product);
        }

        // Hiển thị form xác nhận xóa sản phẩm
        
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            //Lọc ra category ứng với sán phẩm
            var categories = await _categoryRepository.GetAllAsync();
            var selectedCategory = categories.FirstOrDefault(c => c.Idcategory == product.Idcategory);
            ViewBag.CategoryName = selectedCategory?.NameCategory;
            return View(product);
        }

        // Xử lý xóa sản phẩm
        
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Page()
        {
            return View();
        }
    }
}
