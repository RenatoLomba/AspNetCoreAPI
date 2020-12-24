using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.User
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? CreatAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
