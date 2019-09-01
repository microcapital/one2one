using System.Collections.Generic;

namespace OneTwoOne.Infrastructure.Modules
{
    public interface IModuleConfigurationManager
    {
        IEnumerable<ModuleInfo> GetModules();
    }
}