using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace EmployeesList.Models
{
    public class Employee
    {
        
        public int Id { get; set; }
        public string? Fullname { get { return Surname + " " + Name + " " + Patronymic; } }

        public string? Name { get; set; }
       
        public string? Patronymic { get; set; }
        
        public string? Surname { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateОfBirth { get; set; }
        public string? Position { get; set; }
        public ICollection<Children> Childrens { get; set; }



    }
}


