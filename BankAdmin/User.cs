using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAdmin
{
    [TableName("user")]
    public class User
    {
        [FieldName("user_id")]
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
    }
}
