using System;
using System.Linq;
using System.Web.UI;
using FlickrNet;
using ImageRotator.data.models;
using ImageRotator.data.providers;

namespace ImageRotator
{
	public partial class _Default : Page
	{

        /// <summary>
        /// This page displays a different random image and information about it on each page reload.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		protected void Page_Load(object sender, EventArgs e)
		{   
            //First, we will cruft the code to set a random image using the Flickr.NET API

			//SetImageFromFlickr();

            //The above method is an example of working code - simple and short - and satisfies the requirement.
            //However, it violates the Open/Closed Principle.
            //If you wanted to get images from somewhere else - a database, file server, 
            //or another API - you would have to alter the method.

            //Now we will lok at how to do this in a more object-oriented way by abstracting the data provider
            IImageProvider flowerProvider = new FlickrImageProvider("flower");
            IRotatingImage rotatingImage = GetImageWithAnyImageProvider(flowerProvider);
            SetPageImageDetails(rotatingImage);

		}

        /// <summary>
        /// Example of crufted code to figure out implementation details
        /// </summary>
		private void SetImageFromFlickr()
		{
			var flickr = new Flickr("04319f11190169ccc6c9613b739d239f", "9a1d30cc8681f2f9");

			var options = new PhotoSearchOptions();
			options.Tags = "flower,flowers";

			PhotoCollection photos = flickr.PhotosSearch(options);

			int count = photos.Count();
			if (count > 0)
			{
				Random rnd = new Random();
				int randomNum = rnd.Next(1, count);
				Photo photo = photos[randomNum];

				ltlTitle.Text = photo.Title;
				hlUrl.Text = "View on Flickr";
				hlUrl.NavigateUrl = photo.WebUrl;
				imgFlower.ImageUrl = photo.Medium640Url;
			}
		}

        /// <summary>
        /// Gets an image using an interface - abstracting the implementation details with interfaces
        /// </summary>
        private IRotatingImage GetImageWithAnyImageProvider(IImageProvider imageProvider)
        {
            IRotatingImage rotatingImage = imageProvider.GetRotatingImage();
            return rotatingImage;
        }

		/// <summary>
		/// This sets an image using an interface - abstracting the implementation details
		/// </summary>
		private void SetPageImageDetails(IRotatingImage rotatingImage)
		{
            ltlTitle.Text = rotatingImage.Title;
            hlUrl.Text = rotatingImage.SourceText;
            hlUrl.NavigateUrl = rotatingImage.SourceUrl;
            imgFlower.ImageUrl = rotatingImage.ImageUrl;
            ltlCount.Text = rotatingImage.PhotoCount;
		}
		
	}
}