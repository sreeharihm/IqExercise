using System.Drawing;

namespace Application.Helper
{
    public static class ImageOperationHelper
    {
        public static async Task<string> UploadImageAsync(string data, string imageName, Guid imageId)
        {
            var folderName = Path.Combine("Uploads", "Images");
            var imageFolder = Path.Combine(folderName, imageId.ToString());
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), imageFolder);
            string imagePath = Path.Combine(pathToSave, imageName);
            if (!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);
            }

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
            byte[] imageBytes = Convert.FromBase64String(data);
            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                //Convert byte[] to Image
                await ms.WriteAsync(imageBytes, 0, imageBytes.Length);
                Image image = Image.FromStream(ms, true);
                image.Save(imagePath);
            }
            return imagePath;
        }

        public static void DeleteImage(string imagePath, Guid guid)
        {
            var folderName = Path.Combine("Uploads", "Images");
            var imageFolder = Path.Combine(folderName, guid.ToString());
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), imageFolder);
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
            Directory.Delete(pathToSave);
        }
    }
}
