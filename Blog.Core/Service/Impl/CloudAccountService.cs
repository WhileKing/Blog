﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Blog.Core.Domain;
using Blog.Core.Infrastructure.Orm;
using Blog.Core.Model.Input;
using Blog.Core.Model.Output;
using YH.Arch.Infrastructure.Extension;
using YH.Arch.Infrastructure.ORM;

namespace Blog.Core.Service.Impl
{
    public class CloudAccountService : ICloudAccountService
    {
        private readonly Repository repository;
        private readonly Queries queries;
        private readonly IMapper mapper;

        public CloudAccountService(Repository repository, Queries queries, IMapper mapper)
        {
            this.repository = repository;
            this.queries = queries;
            this.mapper = mapper;
        }

        public void Add(AddCloudAccountInput input)
        {
            var account = new TencentCloudAccount()
            {
                Name = input.Name,
                AppId = input.AppId,
                SecretId = input.SecretId,
                SecretKey = input.SecretKey,
            };
            repository.Add(account);
        }

        public void Edit(EditCloudAccountInput input)
        {
            var account = GetAccount(input.Id);
            account.Name = input.Name;
            account.AppId = input.AppId;
            account.SecretId = input.SecretId;
            account.SecretKey = input.SecretKey;
            repository.Update(account);
        }

        public CloudAccountOutput Detail(Guid id)
        {
            var account = GetAccount(id);
            return new CloudAccountOutput()
            {
                Id = account.Id,
                Name = account.Name,
                AppId = account.AppId,
                SecrectId = account.SecretId,
                SecrectKey = account.SecretKey
            };
        }

        public void Delete(Guid id)
        {
            var account = GetAccount(id);
            repository.Remove(account);
        }

        public IList<CloudAccountListOutput> List()
        {
            var list = repository.GetMulti(queries.GetCLoudAccount()).ToList();
            return mapper.MapList<TencentCloudAccount, CloudAccountListOutput>(list);
        }

        private TencentCloudAccount GetAccount(Guid id)
        {
            return repository.GetSingle(queries.GetCloudAccountBy(id));
        }
    }
}