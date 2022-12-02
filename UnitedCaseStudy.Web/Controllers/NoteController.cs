using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using UnitedCaseStudy.Entity.Entities;
using Microsoft.Extensions.Configuration;
using UnitedCaseStudy.Data.Abstract;
using UnitedCaseStudy.Web.Services;

namespace UnitedCaseStudy.Web.Controllers
{
    public class NoteController : Controller
    {
        private readonly IRestService _restService;
        public NoteController( IRestService restService)
        {
            _restService = restService;
        }

        public IActionResult Index()
        {
          var result= _restService.RestGetAllMethod("GetAllNotes");
            if (!string.IsNullOrEmpty(result))
            {
                var model=JsonConvert.DeserializeObject<List<Note>>(result).Where(x => x.IsDeleted == false && x.ParentNoteId == null).ToList();
                return View(model);
            }
            else
            {
                return View(new List<Note>());
            }
        }

        [HttpGet("Note/Index/ParentNoteId{id:int}")]
        public IActionResult Index(int id)
        {
            ViewBag.ParentNoteId = id;
            var parentNotes = _restService.RestGetAllMethod("GetAllNotes");
            var notes = JsonConvert.DeserializeObject<List<Note>>(parentNotes).Where(x => x.ParentNoteId == id).ToList();
            //if (notes.Count>0)
            return View(notes);

        }

        [HttpGet("Note/Update/{id:int}")]
        public IActionResult Update(int id)
        {
            var allNotes = _restService.RestGetAllMethod("GetAllNotes");
            var notes = JsonConvert.DeserializeObject<List<Note>>(allNotes).Where(x => x.Id == id).FirstOrDefault();
            return View(notes);
        }

        [HttpPost]
        public IActionResult Update(Note model)
        {
            var result = _restService.RestUpdateMethod("UpdateNote", JsonConvert.SerializeObject(model));
            if (!string.IsNullOrEmpty(result)) { 
                var updateNote = JsonConvert.DeserializeObject<Note>(result);
                if (updateNote.ParentNoteId != null && updateNote.ParentNoteId > 0)
                    return RedirectToAction("Index", new { id = updateNote.ParentNoteId });
                else
                    return RedirectToAction("Index");
            }
            else
                return View(model);
        }
  
        public IActionResult Create(int? id)
        {
            Note model = new Note();
            model.ParentNoteId=id;
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Note model)
        {
            if (_restService.RestCreateMethod("CreateNote", JsonConvert.SerializeObject(model)))
            {
                if(model.ParentNoteId!=null&&model.ParentNoteId>0)
                    return RedirectToAction("Index", new { id = model.ParentNoteId });
                else
                    return RedirectToAction("Index");
            }
                
            else
                return View(model);
        }

        [HttpGet("Note/Delete/{id:int}")]
        public IActionResult Delete(Note model)
        {
            if (_restService.RestDeleteMethod("DeleteNote", JsonConvert.SerializeObject(model)))
                return RedirectToAction("Index");
            else
                return View(model);
        }
    
    }
}
