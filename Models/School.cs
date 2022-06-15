using System.Collections.Generic;

namespace project.Models
{
    public class School 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; private set; } = new List<Student>();
    }
}