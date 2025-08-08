using System.ComponentModel.DataAnnotations; 



namespace testdemo.Models
{
    public class Item
    {


        [Key]

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string price { get; set; }

        public  DateTime  CreateDate { get; set; } = DateTime.Now;  


    }
}
