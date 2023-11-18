using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RandomGenerate.Models
{
    public class Word
    {
        [Key]
        public int VocableId { get; set; }

        public int VocableIndex { get; set; }



        [Column(TypeName = "nvarchar(50)")]
        public string Vocable { get; set; }



        [Column(TypeName = "nvarchar(50)")]
        public string Counter { get; set; }


    }
}
