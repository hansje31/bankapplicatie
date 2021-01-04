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
        public static Field IdInfo(Type t, object instace)
        {
            var result = new Field();
            PropertyInfo[] props = t.GetProperties();
            var idField = props.Where(x => x.CustomAttributes.Count() > 0).Where(x => x.GetCustomAttribute<FieldName>().isId == true).First();
            result.Value = idField.GetValue(instace).ToString();
            result.Name = idField.GetCustomAttribute<FieldName>().value;
            return result;

        } 
        public static List<string> FieldNames(Type t)
        {
            List<string> list = new List<string>();
            PropertyInfo[] props = t.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    FieldName authAttr = attr as FieldName;
                    if (authAttr != null && authAttr.readOnly == false)
                    {
                        list.Add(authAttr.value);
                    }
                }
            }
            return list;

        }
        public static List<string> ValuesList(Type t, object instance)
        {
            List<string> list = new List<string>();
            PropertyInfo[] props = t.GetProperties();
            foreach (PropertyInfo prop in props.Where(x=> x.CustomAttributes.Count() != 0).Where(x=> x.CustomAttributes.First().AttributeType == typeof(FieldName) && x.GetCustomAttribute<FieldName>().readOnly == false))
            {
                string value = prop.GetValue(instance)?.ToString() ?? "";
                list.Add(value);
            }
            return list;
        }
        public static Dictionary<string, string> ClassToDictionary(Type t)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            PropertyInfo[] props = t.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    FieldName authAttr = attr as FieldName;
                    if (authAttr != null)
                    {
                        string propName = prop.Name;
                        string auth = authAttr.value;
        
                        dict.Add(auth, propName);
                    }
                }
            }
            return dict;
        
        }

    }
    public struct Field
    {
        public Field(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }

    }
}
