using SimpleBookCatalog.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SimpleBookCatalog.Domain.DTO;

public class BookDTO
{
    public Guid? BookId { get; set; } 

    [Required(ErrorMessage ="Please provide a title")]
    [StringLength(100)]
    public string Title { get; set; }

    [Required(ErrorMessage = "Please provide a Author-name")]
    [StringLength(100)]
    public string Author { get; set; }

    [Required(ErrorMessage = "Please provide a Publication-Date")]
    public DateOnly? PublicationDate { get; set; }/* = DateOnly.FromDateTime(DateTime.Now);*/

    [Required]
    [EnumDataType(typeof(Category),ErrorMessage ="Please select a Category")]
    public Category? Category { get; set; }
}
