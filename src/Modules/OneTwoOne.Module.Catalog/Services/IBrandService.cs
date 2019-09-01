﻿using System.Threading.Tasks;
using OneTwoOne.Module.Catalog.Models;

namespace OneTwoOne.Module.Catalog.Services
{
    public interface IBrandService
    {
        Task Create(Brand brand);

        Task Update(Brand brand);

        Task Delete(long id);

        Task Delete(Brand brand);
    }
}
