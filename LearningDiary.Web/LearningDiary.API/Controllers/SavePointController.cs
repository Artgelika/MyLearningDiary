using LearningDiary.API.Models.DTOs;
using LearningDiary.API.Models.Entities;
using LearningDiary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace LearningDiary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavePointController : ControllerBase
    {
        private readonly SavePointService _savePointService;

        public SavePointController(SavePointService savePointService)
        {
            _savePointService = savePointService;
        }   

        [HttpGet]
        public ActionResult<List<SavePoint>> GetAll()
            => _savePointService.GetAll();

        [HttpGet("{id:length(24)}", Name = "GetSavePoint")]
        public ActionResult<SavePoint> Get(string id)
        {
            var savePoint =  _savePointService.Get(id);
            if (savePoint == null)
            {
                return NotFound();
            }
            return savePoint;
        }

        [HttpPost]
        public IActionResult Create(SavePointCreate savePoint)
        {
            var newSavePoint = _savePointService.Create(savePoint);
            return CreatedAtRoute("GetSavePoint", new { id = newSavePoint.SavePointId.ToString() }, newSavePoint);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, SavePointUpdate savePointIn)
        {
            var savePoint = _savePointService.Get(id);

            if (savePoint == null)
            {
                return NotFound();
            }

            _savePointService.Update(id, savePointIn);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var savePoint = _savePointService.Get(id);

            if (savePoint == null)
            {
                return NotFound();
            }

            _savePointService.Remove(id);
            return NoContent();
        }


        
    }
}
