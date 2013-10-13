using System;
using System.Linq;
using FlickrNet;
using ImageRotator.data.models;

namespace ImageRotator.data.providers
{
	public class FlickrImageProvider : IImageProvider
	{
		private const string ApiKey = "04319f11190169ccc6c9613b739d239f";
		private const string SharedSecret = "9a1d30cc8681f2f9";
		private readonly Flickr _flickr;
		private Photo _photo;

        public FlickrImageProvider(string tag)
        {
            _flickr = new Flickr(ApiKey, SharedSecret);
            _photo = GetRandomFlickrPhoto(tag);
        }

        private Photo GetRandomFlickrPhoto(string tag)
        {
            var options = new PhotoSearchOptions {Tags = tag};
			PhotoCollection photos = _flickr.PhotosSearch(options);

			Random rnd = new Random();
			int count = photos.Count();
			if (count > 0)
			{
				int randomNum = rnd.Next(1, count);
				_photo = photos[randomNum];
			}

            return _photo;
        }

        public IRotatingImage GetRotatingImage()
        {
            IRotatingImage rotatingImage = new RotatingImage();
            rotatingImage.Title = _photo.Title;
            rotatingImage.ImageUrl = _photo.Medium640Url;
            rotatingImage.SourceText = "View on Flickr!";
            rotatingImage.SourceUrl = _photo.WebUrl;
            rotatingImage.PhotoCount = _photo.ToString();
            return rotatingImage;
        }
		
	}
}