using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LinXi_IService;
using LinXi_Model;

//using LinXi_Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LinXi_ERPApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AcDepartmentController : ControllerBase
    {
        #region 字段

        private ILogger<AcDepartmentController> _logger;

        private IAcDepartmentService _IAcDepartmentService;
        private IServiceProvider _service;

        private IMapper _IMapper;
        private IHttpContextAccessor _httpContext;

        //private int UserId
        //{
        //    get
        //    {
        //        return int.Parse(_httpContext.HttpContext.User.Claims.Where(u => u.Type == "UserId").FirstOrDefault().Value);
        //    }
        //}

        private readonly static object obj = new object();

        #endregion 字段

        #region 构造函数注入

        public AcDepartmentController(
            ILogger<AcDepartmentController> logger,
            IAcDepartmentService IAcDepartmentService,
            IServiceProvider service,
            IMapper IMapper,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _logger = logger;
            _IAcDepartmentService = IAcDepartmentService;
            _service = service;
            _IMapper = IMapper;
            _httpContext = httpContextAccessor;
        }

        #endregion 构造函数注入

        /// <summary>
        /// 获取单个用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<AcDepartment> GetAC(int id)
        {
            return await _IAcDepartmentService.FindAsyncById(1); ;
        }

        /// <summary>
        /// 修改xx表的资料
        /// </summary>
        /// <param name="de">xx类</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<int> EditAC(AcDepartment de)
        {
            return await _IAcDepartmentService.Edit(de); ;
        }
    }
}