using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




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

        [Required]
        [DisplayName("Category")]
        // CategoryId, Item sınıfının Category sınıfıyla ilişkisini temsil eder
        // Bu, Item nesnesinin hangi kategoriye ait olduğunu belirtir
        // Bu ilişki, Entity Framework Core'un veritabanı ilişkilerini yönetmesine olanak tanır
        [ForeignKey("Category")]
        public int CategoryId { get; set; }


        // Category.cs dosyasındaki Category sınıfına referans
        // Bu, Item sınıfının Category sınıfıyla ilişkili olduğunu gösterir
        // Bu ilişki sayesinde, bir Item nesnesi ile ilişkili Category bilgilerine erişebiliriz
        // Bu, Entity Framework Core'un ilişkileri yönetmesine olanak tanır

        public Category?  Category { get; set; } // Category.cs dosyasındaki Category sınıfına referans   

    }
}
