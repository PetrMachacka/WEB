using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Joomla20.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set;}
        public DateTime CreatedAt { get; set; }
        public Guid AutorId { get; set; }
        [ForeignKey("AutorId")]
        public JUser Autor { get; set; }
    }
}
