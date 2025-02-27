using Azure.Data.Tables;

using System.Reflection;

namespace ASWA.CCD.API
{
    public static class ExtensionMethods
    {
        public static T ToEntity<T>(this TableEntity source) where T : ITableEntity, new()
        {
            T destination = new();
            foreach (var propertyInfo in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                propertyInfo.SetValue(destination, source[propertyInfo.Name]);
            }

            return destination;
        }
    }
}
