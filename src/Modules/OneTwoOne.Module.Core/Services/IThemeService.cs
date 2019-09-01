﻿using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using OneTwoOne.Module.Core.Areas.Core.ViewModels;

namespace OneTwoOne.Module.Core.Services
{
    public interface IThemeService
    {
        Task<IList<ThemeListItem>> GetInstalledThemes();

        Task SetCurrentTheme(string themeName);

        string PackTheme(string themeName);

        Task Install(Stream stream, string themeName);

        void Delete(string themeName);
    }
}
