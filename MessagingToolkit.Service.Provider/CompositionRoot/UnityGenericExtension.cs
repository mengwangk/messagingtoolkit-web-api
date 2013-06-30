using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Practices.Unity;
using MessagingToolkit.Service.Common.Log;
using MessagingToolkit.Service.Provider.Commands;

namespace MessagingToolkit.Service.Provider.CompositionRoot
{
    /// <summary>
    /// Unity generic extension
    /// </summary>
    public class UnityGenericExtension : UnityContainerExtension, IOpenGenericExtension
    {
        // Logger
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

        protected override void Initialize()
        {

        }

        public void RegisterOpenGenericMany(Type genericType)
        {
            RegisterOpenGenericManyByAssembly(genericType, Assembly.GetExecutingAssembly());
            RegisterOpenGenericManyByAssembly(genericType, Assembly.GetEntryAssembly());
        }

        private void RegisterOpenGenericManyByAssembly(Type genericType, Assembly assembly)
        {
            // Register for executing asssembly
            var types = assembly.GetTypes().Where(p => p.GetInterfaces().Any(x => x.IsGenericType
                    && x.GetGenericTypeDefinition() == genericType));

            foreach (var t in types)
            {
                Type commandInterface = t.GetInterfaces().First(i => i.Name.ToLower().Contains(genericType.Name.ToLower()));
                Container.RegisterType(commandInterface, t);
            }
        }

    }

    public interface IOpenGenericExtension : IUnityContainerExtensionConfigurator
    {
        void RegisterOpenGenericMany(Type type);
    }
}
