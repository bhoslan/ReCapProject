using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("getimagesbycarid")]
        public IActionResult GetImagesByCarId(int carId)
        {
            var result = _carImageService.GetImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(int imageId)
        {
            var result = _carImageService.GetById(imageId);
            if (result.Success)
            {
                Ok(result);
            }
            return BadRequest(result);

        }
        //Body/ form-data kısmından gönderdiğimiz file bir IFormFile nesnesidir.  [FormForm] kısmı ise bazı sürümler bu sistemi tanıyamadığı
        //için kullanılan attribute lerdir.
        //Buradaki Image ise Postman üzerinden ilgili dosyayı bir takma isim vasıtasıyla göndermek için verilmiş bir isimdir

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile[] files, [FromForm] CarImage carImage) // IFormFile web arayüzündeki formlardan gelecek dosyaları almak için kullanılır
        {                                         // FromForm denilmesi veri formdan gelecek anlamı taşır. Postman de body/form-data kullanılmalı
            var result = _carImageService.AddCollective(files, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
