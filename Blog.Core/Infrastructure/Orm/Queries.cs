﻿using System;
using Blog.Core.Domain;
using YH.Arch.Domain;
using YH.Arch.Infrastructure.ORM;

namespace Blog.Core.Infrastructure.Orm
{
    public interface Queries
    {
        Query<FavoriteLink> GetFavoriteLink(Guid id);
        Query<Article> GetArticle(Guid id);
        QueryByEntity<Article> GetArticles();
    }
}