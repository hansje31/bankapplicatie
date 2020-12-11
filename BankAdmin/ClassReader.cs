using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BankAdmin
{
    public class ClassReader
    {
        public List<string> AttributeList(Type t)
        {
            List<string> list = new List<string>();
            PropertyInfo[] props = t.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    FieldName authAttr = attr as FieldName;
                    if (authAttr != null)
                    {
                        list.Add(authAttr.value);
                    }
                }
            }
            return list;

        }
        public List<string> ValuesList(Type t, object instance)
        {
            List<string> list = new List<string>();
            PropertyInfo[] props = t.GetProperties();
            foreach (PropertyInfo prop in props.Where(x=> x.CustomAttributes.First().AttributeType == typeof(FieldName)))
            {
                string value = prop.GetValue(instance)?.ToString() ?? "";
                list.Add(value);
            }
            return list;
        }
        //public Dictionary<string, string> ClassToDictionary(Type t)
        //{
        //    Dictionary<string, string> dict = new Dictionary<string, string>();
        //    PropertyInfo[] props = t.GetProperties();
        //    foreach (PropertyInfo prop in props)
        //    {
        //        object[] attrs = prop.GetCustomAttributes(true);
        //        foreach (object attr in attrs)
        //        {
        //            FieldName authAttr = attr as FieldName;
        //            if (authAttr != null)
        //            {
        //                string propName = prop.Name;
        //                string auth = authAttr.value;
        //
        //                dict.Add(propName, auth);
        //            }
        //        }
        //    }
        //    return dict;
        //
        //}
    }
}
