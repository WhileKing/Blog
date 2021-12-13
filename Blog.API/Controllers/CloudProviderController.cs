﻿using System;
using System.Collections.Generic;
using Blog.Core.Model.Input;
using Blog.Core.Model.Output;
using Blog.Core.Service;
using Microsoft.AspNetCore.Mvc;
using YH.Arch.Infrastructure;

namespace Blog.API.Controllers
{
    public class CloudProviderController : BaseController
    {
        private readonly ICloudProviderService service;

        public CloudProviderController(ICloudProviderService service)
        {
            this.service = service;
        }

        [HttpPost]
        public void Add(AddCloudProviderInput input)
        {
            service.Add(input);
        }

        [HttpPost]
        public void Edit(EditCloudProviderInput input)
        {
            service.Edit(input);
        }

        [HttpPost]
        public void Delete(DeleteCloudProviderInput input)
        {
            service.Delete(input.Id);
        }

        [HttpGet]
        public CloudProviderOutput Detail(Guid id)
        {
            return service.Detail(id);
        }

        [HttpPost]
        public IList<CloudProviderListOutput> List()
        {
            return service.List();
        }
    }
}