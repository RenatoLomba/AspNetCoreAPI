using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.User;

namespace ServiceTest.User
{
    public class UserTest
    {
        public static string NameUser { get; set; }
        public string EmailUser { get; set; }
        public static string NameUserAlter { get; set; }
        public string EmailUserAlter { get; set; }
        public static Guid IdUser { get; set; }
        public UserDTOEntry userDTOEntry { get; set; }
        public List<UserDTOSelectResult> listaUserDto = new List<UserDTOSelectResult>();
        public UserDTOSelectResult userDTOSelect { get; set; }
        public UserDTOCreateResult userDTOCreate { get; set; }
        public UserDTOUpdateResult userDTOUpdate { get; set; }

        public UserTest()
        {
            NameUser = Faker.Name.FullName();
            NameUserAlter = Faker.Name.FullName();
            EmailUser = Faker.Internet.Email();
            EmailUserAlter = Faker.Internet.Email();
            IdUser = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UserDTOSelectResult {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                };
                listaUserDto.Add(dto);
            }

            userDTOEntry = new UserDTOEntry
            {
                Id = IdUser,
                Name = NameUser,
                Email = EmailUser
            };

            userDTOSelect = new UserDTOSelectResult
            {
                Id = IdUser,
                Name = NameUser,
                Email = EmailUser
            };

            userDTOCreate = new UserDTOCreateResult
            {
                Id = IdUser,
                Name = NameUser,
                Email = EmailUser,
                CreateAt = DateTime.UtcNow
            };

            userDTOUpdate = new UserDTOUpdateResult
            {
                Id = IdUser,
                Name = NameUser,
                Email = EmailUser,
                UpdateAt = DateTime.UtcNow
            };

        }
    }
}
