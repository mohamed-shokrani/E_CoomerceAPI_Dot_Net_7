namespace Core.Specification;
public class ProductSpecParams
{
    private const int maxPageSize = 50;

    public int indexPage { get; set; }=1 ;

    private int _pageSize = 20;
   public int pageSize
    {
        get => _pageSize;
        set => _pageSize = (value > maxPageSize)? maxPageSize :value;
    }

    public int? BrandId { get; set; }
    public int? ProductTypeId { get; set; }
    public string? Sort { get; set; }
    public string? _search;
    public string? Search 
    {
        get => _search;
        set => _search = value.ToLower();
    }


}
