using System;
using Newtonsoft.Json.Serialization;

namespace SodaDungeonTracker
{
    public class TrackSerializationBinder : ISerializationBinder
    {
        public string TypeName { get; private set; }
        public string AssemblyName { get; private set; }

        public TrackSerializationBinder(string typeName, string assemblyName)
        {
            TypeName = typeName;
            AssemblyName = assemblyName;
        }

        public Type BindToType(string assemblyName, string typeName)
        {
            var resolvedTypeName = string.Format(assemblyName, typeName);
            return Type.GetType(resolvedTypeName, true);
        }

        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;
            typeName = serializedType.Name;
        }
    }
}