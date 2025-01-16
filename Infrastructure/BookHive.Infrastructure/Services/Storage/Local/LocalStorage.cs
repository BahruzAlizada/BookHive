using Microsoft.AspNetCore.Hosting;
using BookHive.Application.Abstracts.Storage;
using BookHive.Application.Abstracts.Storage.Local;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace BookHive.Infrastructure.Services.Storage.Local;

//public class LocalStorage : Storage, ILocalStorage
//{
//    private readonly IWebHostEnvironment env;
//    public LocalStorage(IWebHostEnvironment env)
//    {
//        this.env = env;
//    }

//    public async Task DeleteAsync(string pathOrContainerName, string fileName)
//    {
//         File.Delete($"{pathOrContainerName}\\{fileName}");
//    }

//    public List<string> GetFiles(string pathOrContainerName)
//    {
//        DirectoryInfo directory = new(pathOrContainerName);
//        return directory.GetFiles().Select(f => f.Name).ToList();
//    }

//    public Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
//    {
//        string uploadPath = Path.Combine(env.WebRootPath, pathOrContainerName);
//        if (!Directory.Exists(uploadPath))
//            Directory.CreateDirectory(uploadPath);

//        List<(string fileName, string path)> datas = new();
//        foreach (IFormFile file in files)
//        {
//            string fileNewName = await FileRenameAsync(path, file.Name, HasFile);

//            await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
//            datas.Add((fileNewName, $"{pathOrContainerName}\\{fileNewName}"));
//        }

//        return datas;
//    }

//    bool IStorage.HasFile(string pathOrContainerName, string fileName)
//    {
//        File.Exists($"{path}\\{fileName}");
//        async Task<bool> CopyFileAsync(string path, IFormFile file)
//        {
//            try
//            {
//                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

//                await file.CopyToAsync(fileStream);
//                await fileStream.FlushAsync();
//                return true;
//            }
//            catch (Exception ex)
//            {
//                //todo log!
//                throw ex;
//            }
//        }
//    }

