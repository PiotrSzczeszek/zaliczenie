namespace Zaliczenie.Data.DTO;

public class ColumnsConfig
{
    public string PropertyName { get; set; }
    public string DisplayName { get; set; }
    public int Width { get; set; }
    public string CssWidth => $"{Width}px";
    public bool Hidden { get; set; } = false;
}