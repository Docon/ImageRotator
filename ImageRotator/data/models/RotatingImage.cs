namespace ImageRotator.data.models
{
    public class RotatingImage : IRotatingImage
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string SourceText { get; set; }
        public string SourceUrl { get; set; }
        public string PhotoCount { get; set; }
    }
}