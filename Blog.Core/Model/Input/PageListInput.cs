﻿namespace Blog.Core.Model.Input
{
    public class PageListInput
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 15;
    }
}