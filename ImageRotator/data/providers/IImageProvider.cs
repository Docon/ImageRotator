using ImageRotator.data.models;

namespace ImageRotator.data.providers
{
	public interface IImageProvider
	{
	    IRotatingImage GetRotatingImage();
	}
}
