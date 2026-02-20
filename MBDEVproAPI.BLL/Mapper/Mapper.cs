using System;
using System.Collections.Generic;
using System.Text;

namespace MBDEVproAPI.BLL.Mapper
{

    internal class Mapper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="DestinationObject"></typeparam>
        /// <param name="sourceObject"></param>
        /// <param name="destinationObject"></param>
        /// <param name="isPropertyTypeNeedsMatch"></param>
        /// <returns></returns>
        internal static DestinationObject MapObject<DestinationObject>(object sourceObject,
                                                                            DestinationObject destinationObject,
                                                                            bool isPropertyTypeNeedsMatch = true) where DestinationObject : class
        {
            //Boundary Condition
            if (sourceObject == null || destinationObject == null)
            {
                return destinationObject;
            }

            PropertyInfo[] destinationPropList = destinationObject.GetType().GetProperties();

            PropertyInfo[] sourcePropList = sourceObject.GetType().GetProperties();

            foreach (PropertyInfo destinationPropInfo in destinationPropList)
            {
                foreach (PropertyInfo sourcePropInfo in sourcePropList)
                {
                    if (sourcePropInfo.Name == destinationPropInfo.Name
                        && !sourcePropInfo.GetGetMethod().IsVirtual
                        && !destinationPropInfo.GetGetMethod().IsVirtual
                        && (!isPropertyTypeNeedsMatch || sourcePropInfo.PropertyType == destinationPropInfo.PropertyType)
                        )
                    {
                        destinationPropInfo.SetValue(destinationObject, sourcePropInfo.GetValue(sourceObject, null), null);
                        break;
                    }
                }
            }
            return destinationObject;
        }



    }


}
