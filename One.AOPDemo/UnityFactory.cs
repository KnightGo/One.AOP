using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace One.AOPDemo
{
   public class UnityFactory
    {
        public static IUnityContainer _UnityContainer = null;
        static UnityFactory()
        {
            IUnityContainer container = new UnityContainer();
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "UnityConfig\\Unity.Config");
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
            section.Configure(container, "aopContainer");
            _UnityContainer = container;
        }

        public static IUnityContainer CreateUnityInit()
        {
            return _UnityContainer;
        }
    }
}
