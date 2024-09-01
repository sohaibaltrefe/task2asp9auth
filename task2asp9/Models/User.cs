using System.ComponentModel.DataAnnotations;

namespace task2asp9.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public string Rolename { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }= DateTime.Now;


    }
}
