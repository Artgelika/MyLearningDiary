using AutoMapper;
using LearningDiary.API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using LearningDiary.API.Controllers;
using LearningDiary.API.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;
//using MongoDB.Bson.IO;

namespace LearningDiary.Web.Controllers
{
    public class SavePointEntryController : Controller
    {
        private readonly HttpClient _httpClient;
        //private readonly IMapper _mapper;
        private readonly ISavePointService _savePointService;

        public SavePointEntryController(IHttpClientFactory httpClientFactory,/* IMapper mapper,*/ ISavePointService savePointService)
        {
            _httpClient = httpClientFactory.CreateClient();
            //_mapper = mapper;
            _savePointService = savePointService;
        }

        [HttpGet]
        public async Task<IActionResult> Forms(SavePointCreate Model)
        {
            if (Model.Result == "valid")
                return View();
            else
                ViewBag.Invalid = Model.Result;
            return View(Model);
        }
        

        [HttpPost]
        public async Task<IActionResult> CreateForms(SavePointCreate model)
        {
            if (!ModelState.IsValid)
            {
                model.Result = "invalid";
                return RedirectToAction("Forms", "SavePointEntry", model);
            }
            model.Result = "valid";
            var modelTemp = _savePointService.Create(model);

            return RedirectToAction("Forms", "SavePointEntry", model);
        }

        private async Task AddNewRecord(SavePointCreate model, string url)
        {
            SavePointRead mappedSavePoint = _savePointService.Create(model);
            var json = JsonConvert.SerializeObject(mappedSavePoint);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(url, content);
        }


    }
}
