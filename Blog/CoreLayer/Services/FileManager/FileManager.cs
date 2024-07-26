using Microsoft.AspNetCore.Http;

namespace CoreLayer.Services.FileManager
{
    public class FileManager : IFileManager
    {
        public string SaveFile(IFormFile file, string savePath)
        {
            if (file == null) throw new Exception("File is null");

            var fileName = $"{Guid.NewGuid()}{file.FileName}";

            var path = Path.Combine(Directory.GetCurrentDirectory(), savePath.Replace("/", "\\"));

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var fullPath = Path.Combine(path, fileName);

            using var stream = new FileStream(fullPath, FileMode.Create);
            file.CopyTo(stream);

            return fileName;
        }

        public void DeleteFile(string fileName, string path)
        {
            var file = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);

            if (File.Exists(file)) File.Delete(file);
        }
    }
}
