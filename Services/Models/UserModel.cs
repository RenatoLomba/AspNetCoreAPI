using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class UserModel : BaseModel
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
    }
}
