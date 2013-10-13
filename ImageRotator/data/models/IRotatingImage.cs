namespace ImageRotator.data.models
{
    public interface IRotatingImage
    {
        string Title { get; set; }
        string ImageUrl { get; set; }
        string SourceText { get; set; }
        string SourceUrl { get; set; }
        string PhotoCount { get; set; }
    }
}