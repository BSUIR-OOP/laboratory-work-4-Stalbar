using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DI_Library
{
    public class CycleError
    {
        public List<Type> fields = new List<Type>();
        public List<Type> dependencyList = new List<Type>();

        public bool IsContainsCycle(Type objType)
        {
            fields.Add(objType);
            var objectFields = objType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            List<Type> fieldsList = new List<Type>();
            foreach(var field in objectFields)
            {
                if (field.FieldType.IsClass)
                {
                    if (fieldsList.Contains(field.FieldType) == false)
                        fieldsList.Add(field.FieldType);
                }
            }
            foreach(var field in fieldsList)
            {
                if (fields.Contains(field) == false)
                {
                    if (IsContainsCycle(field))
                    {
                        dependencyList.Add(field);
                        return true;
                    }
                }
                else
                {
                    dependencyList.Add(field);
                    return true;
                }
            }
            return false;
        }

        public string CheckForCycles(Type objType)
        {
            if (IsContainsCycle(objType))
            {
                string errMsg = $"Cycle: {dependencyList.Last().Name}";
                foreach(var dependency in dependencyList)
                {
                    errMsg += $"{dependency.Name} ";
                }
                return errMsg;
            }
            return null;
        }
    }
}
