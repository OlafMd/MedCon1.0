using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CSV2Core
{
    class CoreSupport
    {
        /// <summary>
        /// Makes a deep copy of an object by serializing and deserializing it.
        /// </summary>
        /// <typeparam name="T">needs to be serializable</typeparam>
        /// <param name="original">The original.</param>
        /// <returns></returns>
        public static T DeepClone<T>( T original ) where T : System.Runtime.Serialization.ISerializable
        {
            using ( var memoryStream = new MemoryStream() )
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, original);
                memoryStream.Position = 0;
                return (T) formatter.Deserialize(memoryStream);
            }
        }
    }
}
