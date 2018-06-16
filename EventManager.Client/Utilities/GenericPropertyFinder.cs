namespace EventManager.Client.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public static class GenericPropertyFinder<TModel> where TModel : class
    {
        public static string[] GetPropertiesValues(TModel tmodelObj)
        {
            //Getting Type of Generic Class Model
            Type tModelType = tmodelObj.GetType();
            //Getting properties of the type
            PropertyInfo[] properties = tModelType.GetProperties();
            //Getting the 
            string[] valuesOfProperties = properties.Select(p => p.GetValue(tmodelObj).ToString()).ToArray();

            return valuesOfProperties;
        }
    }
}
