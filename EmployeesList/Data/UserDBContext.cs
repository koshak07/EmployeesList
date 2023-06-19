using EmployeesList.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeesList.Data
{
    public class UserDBContext : IdentityDbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {

        }

    }

}


