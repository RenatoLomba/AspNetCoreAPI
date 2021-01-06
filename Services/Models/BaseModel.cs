using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class BaseModel
    {
        private Guid _Id;
        public Guid Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private DateTime _CreateAt;
        public DateTime CreateAt
        {
            get { return _CreateAt; }
            set { _CreateAt = value; }
        }

        private DateTime _UpdateAt;
        public DateTime UpdateAt
        {
            get { return _UpdateAt; }
            set { _UpdateAt = value; }
        }
    }
}
