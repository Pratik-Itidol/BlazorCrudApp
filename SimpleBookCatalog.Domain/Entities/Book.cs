namespace SimpleBookCatalog.Domain.Entities;

public partial class Book
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public DateOnly? PublicationDate { get; set; }

    public int? Category { get; set; }

    public DateTime? CreatedAtDate { get; set; }

    public DateTime? UpdatedAtDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? RemovedAt { get; set; }
}
