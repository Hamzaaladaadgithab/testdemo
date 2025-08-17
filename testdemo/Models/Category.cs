using Humanizer.Bytes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testdemo.Models
{
    public class Category
    { 


        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Item>? Items { get; set; } // Item sınıfıyla ilişkili öğeleri tutar  

        [NotMapped]

        public IFormFile? clientFile { get; set; }

        public byte[]? dbImage { get; set; } // Veritabanında saklanacak resim verisi 

        [NotMapped]
        public string ? ImageSrc
        {
            get
            {
                if (dbImage != null && dbImage.Length > 0)
                { 

                    string base64String = Convert.ToBase64String(dbImage, 0 , dbImage.Length); 
                    return "data:image/jpg;base64," +  base64String;

                }
                else
                {
                    return string.Empty; // Eğer dbImage null veya boşsa, boş bir string döndür
                }
                 
            }
        }   
    }
}

