using System.ComponentModel.Design;
using WebAddressBookCF.Services.Interfaces;

namespace WebAddressBookCF.Services
{
    public class BasicImageService : IImageService
    {

        public string ConvertByteArrayToFile(byte[] fileData, string extension)
        {
            if (fileData is null)
            {
                return string.Empty;
            }

            
            string ImageBase64Data = Convert.ToBase64String(fileData);
            return $"data:{extension};base,{ImageBase64Data}";
            
        }

        public async Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file)
        {
            using MemoryStream memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            byte[] fileByte = memoryStream.ToArray();

            return fileByte;
        }
    }
}
