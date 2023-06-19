using System.ComponentModel.DataAnnotations;

namespace EmployeesList.Models
{
    public class Children
    {
        public Guid Id { get; set; }
        public string? Fullname
        { get { return Surname + " " + Name + " " + Patronymic; } }

        public string? Name { get; set; }

        public string? Patronymic { get; set; }

        public string? Surname { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateОfBirth { get; set; }

        public Guid ParentId { get; set; }
    }
}