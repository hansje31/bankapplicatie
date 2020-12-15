using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BankAdmin
{
    [TableName("bankdetails")]
    public class BankDetails
    {
        [FieldName("bank_nummer_id", true)]
        public int BankDetailsId { get; set; }

        [FieldName("bank_rekeningnummer")]
        public Int64 BankAccountNumber { get; set; }

        [FieldName("saldo")]
        public double BankBalance { get; set; }

        [FieldName("pin")]
        public string BankAccountPin { get; set; }

        [FieldName("user_id")]
        public string UserId { get; set; }

        //public static User LoadUser(Dictionary<string, string> dict)
        //{
        //    var user = new User();
        //    PropertyInfo[] props = typeof(User).GetProperties();
        //    foreach (PropertyInfo prop in props.Where(x => x.CustomAttributes.First().AttributeType == typeof(FieldName)))
        //    {
        //        if (prop.PropertyType == typeof(int))
        //        {
        //            prop.SetValue(user, int.Parse(dict[prop.Name]));
        //        }
        //        else
        //        {
        //            prop.SetValue(user, dict[prop.Name]);
        //        }
        //    }
        //    return user;
        //}
    }
}

