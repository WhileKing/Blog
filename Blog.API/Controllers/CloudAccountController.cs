﻿using System;
using Blog.Core.Model.Input;
using Blog.Core.Model.Output;
using Blog.Core.Service;
using Microsoft.AspNetCore.Mvc;
using YH.Arch.Infrastructure;

namespace Blog.API.Controllers
{
    /// <summary>
    /// 云账号管理
    /// </summary>
    public class CloudAccountController :  BaseController
    {
        private readonly ICloudAccountService service;

        public CloudAccountController(ICloudAccountService service)
        {
            this.service = service;
        }

        /// <summary>
        /// 添加云账号
        /// </summary>
        /// <param name="input"></param>
        [HttpPost]
        public void Add(AddCloudAccountInput input)
        {
            service.Add(input);
        }

        /// <summary>
        /// 编辑云账号
        /// </summary>
        /// <param name="input"></param>
        [HttpPost]
        public void Edit(EditCloudAccountInput input)
        {
            service.Edit(input);
        }

        
        /// <summary>
        /// 账号详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public CloudAccountOutput Detail(Guid id)
        {
            return service.Detail(id);
        }

        /// <summary>
        /// 删除账号
        /// </summary>
        /// <param name="input"></param>
        [HttpPost]
        public void Delete(DeleteCloudAccountInput input)
        {
            service.Delete(input.Id);
        }
    }
}