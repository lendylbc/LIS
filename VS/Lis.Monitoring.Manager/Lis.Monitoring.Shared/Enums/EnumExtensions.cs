using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lis.Monitoring.Shared.Enums {
   public static class EnumExtensions {
      public static string ToDescriptionString(this ConditionType val) {
         DescriptionAttribute[] attributes = (DescriptionAttribute[])val
            .GetType()
            .GetField(val.ToString())
            .GetCustomAttributes(typeof(DescriptionAttribute), false);
         return attributes.Length > 0 ? attributes[0].Description : string.Empty;
      }

    //  public static DescriptionAttribute GetEnumDescriptionAttribute<T>(
    //this T value) where T : struct {
    //     // The type of the enum, it will be reused.
    //     Type type = typeof(T);

    //     // If T is not an enum, get out.
    //     if(!type.IsEnum)
    //        throw new InvalidOperationException(
    //            "The type parameter T must be an enum type.");

    //     // If the value isn't defined throw an exception.
    //     if(!Enum.IsDefined(type, value))
    //        throw new InvalidEnumArgumentException(
    //            "value", Convert.ToInt32(value), type);

    //     // Get the static field for the value.
    //     FieldInfo fi = type.GetField(value.ToString(),
    //         BindingFlags.Static | BindingFlags.Public);

    //     // Get the description attribute, if there is one.
    //     return fi.GetCustomAttributes(typeof(DescriptionAttribute), true).
    //         Cast<DescriptionAttribute>().SingleOrDefault();
    //  }

      public static T GetValueFromDescription<T>(string description) where T : Enum {
         foreach(var field in typeof(T).GetFields()) {
            if(Attribute.GetCustomAttribute(field,
            typeof(DescriptionAttribute)) is DescriptionAttribute attribute) {
               if(attribute.Description == description)
                  return (T)field.GetValue(null);
            } else {
               if(field.Name == description)
                  return (T)field.GetValue(null);
            }
         }

         throw new ArgumentException("Not found.", nameof(description));
         // Or return default(T);
      }

      //public static ConditionType GetValueFromDescription(string description) {
      //   foreach(var field in typeof(ConditionType).GetFields()) {
      //      if(Attribute.GetCustomAttribute(field,
      //      typeof(DescriptionAttribute)) is DescriptionAttribute attribute) {
      //         if(attribute.Description == description)
      //            return (ConditionType)field.GetValue(null);
      //      } else {
      //         if(field.Name == description)
      //            return (ConditionType)field.GetValue(null);
      //      }
      //   }

      //   throw new ArgumentException("Not found.", nameof(description));
      //   // Or return default(T);
      //}
   }
}
