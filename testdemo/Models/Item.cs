using System.ComponentModel;
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
        // [DisplayName("The Description")]
        [DisplayName("The Price")] 

        [Range(10, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]

        public string price { get; set; }

        public  DateTime  CreateDate { get; set; } = DateTime.Now;  


    }
}
