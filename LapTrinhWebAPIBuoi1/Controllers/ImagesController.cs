﻿using LapTrinhWebAPIBuoi1.Models;
using LapTrinhWebAPIBuoi1.Models.DTO;
using LapTrinhWebAPIBuoi1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LapTrinhWebAPIBuoi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;
        public ImagesController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        [HttpPost]
        [Route("Upload")]
        public IActionResult Upload([FromForm] ImageUploadRequestDTO request)
        {
            ValidateFileUpload(request);
            if (ModelState.IsValid)
            {
                //convert DTO to Domain model
                var imageDomainModel = new CustomImage
                {
                    File = request.File,
                    FileExtensison = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    FileName = request.FileName,
                    FileDescription = request.FileDescription,
                };
                // User repository to upload image
                _imageRepository.UpLoad(imageDomainModel);
                return Ok(imageDomainModel);
            }
            return BadRequest(ModelState);
        }
        private void ValidateFileUpload(ImageUploadRequestDTO request)
        {
            var allowExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            if (!allowExtensions.Contains(Path.GetExtension(request.File.FileName)))
            {
            }
            ModelState.AddModelError("file", "Unsupported file extension");
            if (request.File.Length > 1040000)
            {
                ModelState.AddModelError("file", "File size too big, please upload file <10M");
            }
        }
        [HttpGet]
        public IActionResult GetAllInfoImages()
        {
            var allImages = _imageRepository.GetAllInfoImages(); return Ok(allImages);
        }
        [HttpGet]
        [Route("Download")]
        public ActionResult DownloadImage(int id)
        {
            var result = _imageRepository.DownloadFile(id); return File(result.Item1, result.Item2, result.Item3);
        }
    }
}
