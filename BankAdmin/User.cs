using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BankAdmin
{
    [TableName("user")]
    public class User //: IConstructor<User>
    {
        [FieldName("user_id",true)]
        public int UserId { get; set; }

        [FieldName("voornaam")]
        public string FirstName { get; set; }

        [FieldName("wachtwoord")]
        public string Password { get; set; }

        [FieldName("achternaam")]
        public string LastName { get; set; }

        [FieldName("email")]
        public string Email { get; set; }

        [FieldName("geslacht")]
        public string Gender { get; set; }

        [FieldName("straat")]
        public string Street { get; set; }

        [FieldName("postcode")]
        public string PostalCode { get; set; }

        [FieldName("stad")]
        public string City { get; set; }

        [FieldName("telefoonnummer")]
        public int Telephone { get; set; }

       public static User LoadUser(Dictionary<string,string> dict)
       {
           var user = new User();
           PropertyInfo[] props = typeof(User).GetProperties();
           foreach (PropertyInfo prop in props.Where(x => x.CustomAttributes.First().AttributeType == typeof(FieldName)))
           {
               if (prop.PropertyType == typeof(int))
               {
                   prop.SetValue(user, int.Parse(dict[prop.Name]));
               }
               else
               {
                   prop.SetValue(user, dict[prop.Name]);
               }
           }
           return user;
       }
    }
}
