using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers
{
    public class StoreController : Controller
    {

        IProductCategoryService _productCategoryService;
        IProductService _productService;
        ICommonService _commonService;
        public StoreController(IProductCategoryService productCategoryService,
            IProductService productService,
            ICommonService commonService)
        {
           this._productCategoryService = productCategoryService;
            this._productService = productService;
            this._commonService = commonService;
        }


        // GET: Store
        public ActionResult Index()
        {
            var slideModel = _commonService.GetSlides();

            var slideView = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(slideModel);
            var storeViewModel = new StoreViewModel();
            storeViewModel.Slides = slideView;

            var lastestProductModel = _productService.GetLastest(3);
            var topSaleProductModel = _productService.GetHotProduct(3);
            var lastestProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(lastestProductModel);
            var topSaleProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(topSaleProductModel);
            storeViewModel.LastestProducts = lastestProductViewModel;
            storeViewModel.TopSaleProducts = topSaleProductViewModel;
            return View(storeViewModel);
        }

        [ChildActionOnly]
        public ActionResult FooterStore()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult HeaderStore()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryViewModel);
        }

        [ChildActionOnly]
        public ActionResult CategoryStore()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryViewModel);
        }
    }
}