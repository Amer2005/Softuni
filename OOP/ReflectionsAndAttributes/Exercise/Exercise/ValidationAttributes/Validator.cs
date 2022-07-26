using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ValidationAttributes.Utility;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();

            PropertyInfo[] properties = type
                .GetProperties()
                .Where(pi => pi.CustomAttributes.Any(a => a.AttributeType.BaseType == typeof(MyValidationAttribute)))
                .ToArray();

            foreach (PropertyInfo property in properties)
            {
                object properyValue = property.GetValue(obj);
                foreach (CustomAttributeData customAttributeData in property.CustomAttributes)
                {
                    Type customAttributeType = customAttributeData.AttributeType;

                    object attributeInstance = property.GetCustomAttribute(customAttributeType);

                    MethodInfo validationMethod = customAttributeType.GetMethod("IsValid");

                    bool result = (bool)validationMethod.Invoke(attributeInstance, new object[] { properyValue });

                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
