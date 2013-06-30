using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.Service.Common;
using MessagingToolkit.Service.Provider.Commands;

namespace MessagingToolkit.Service.Provider
{
    /// <summary>
    /// Get all supported parameter types.
    /// </summary>
    public static class CommandTypesProvider
    {
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            List<Type> typesList1 = GetTypesByAssembly(typeof(ICommand<>).Assembly);
            List<Type> typesList2 = GetTypesByAssembly(Assembly.GetEntryAssembly());
            typesList1.AddRange(typesList2);
            return typesList1.ToArray();
        }


        public static List<Type> GetTypesByAssembly(Assembly assembly)
        {
            var contractAssembly = assembly;

            var commandTypes = (
                from type in contractAssembly.GetExportedTypes()
                where TypeIsCommandType(type)
                select type)
                .ToList();

            var resultTypes =
                from queryType in commandTypes
                select GetCommandResultType(queryType);

            //return commandTypes.Union(resultTypes).ToArray();

             return commandTypes.Union(resultTypes).ToList();
        }

        public static bool TypeIsCommandType(Type type)
        {
            return GetCommandInterface(type) != null;
        }

        public static Type GetCommandResultType(Type commandType)
        {
            return GetCommandInterface(commandType).GetGenericArguments()[0];
        }

        public static Type GetCommandInterface(Type type)
        {
            return (
                from theInterface in type.GetInterfaces()
                where theInterface.IsGenericType
                where typeof(ICommand<>).IsAssignableFrom(theInterface.GetGenericTypeDefinition())
                select theInterface)
                .SingleOrDefault();
        }
    }
}
