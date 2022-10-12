using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class FileService
    {
        static public async Task<string> UploadFile(IFormFile formFile, string subPath = "StaticFiles\\images", string fileName = null)
        {

            if (fileName == null)
                fileName = generateRandomString();

            Console.WriteLine(fileName);

            try
            {
                string[] splitted = formFile.FileName.Split('.');
                string extension = splitted[splitted.Length - 1];

                string combinedFileName = fileName;

                if (splitted.Length > 0)
                    combinedFileName += $".{extension}";

                var path = Path.Combine(
                    subPath,
                    combinedFileName
                );

                var uploadPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    path
                );
                var stream = new FileStream(uploadPath, FileMode.Create);
                await formFile.CopyToAsync(stream);

                return path;
            }
            catch
            {
                // TODO: LOG
                return null;
            }
        }

        static public string generateRandomString(int length = 12)
        {
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }

            return str_build.ToString();
        }
    }
}

