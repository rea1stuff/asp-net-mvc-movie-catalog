namespace MovieCatalog.Application.Movies.ViewModels;

public class PageInfoViewModel
{
    public int TotalPagesCount { get; set; }
    public int CurrentPageNumber { get; set; }
    public int NextPageNumber { get; set; }
}