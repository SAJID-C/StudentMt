namespace StudentWeb.Models
{
    public class StdDeptAss
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int DeptId { get; set;  }

       public virtual Student Student { get; set; }
       public virtual Dept Dept { get; set; }

    }
}
