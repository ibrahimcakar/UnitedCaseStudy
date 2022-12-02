using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitedCaseStudy.API.Models;
using UnitedCaseStudy.Data.Abstract;
using UnitedCaseStudy.Entity.Entities;

namespace UnitedCaseStudy.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;
        public NoteController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        [HttpGet]
        public List<Note> GetAllNotes()
        {
            return _noteRepository.GetAllNotes();
        }

        /// <summary>
        /// En üst seviye not için ParentNoteId alanına değer girmeyiniz.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public Note CreateNote(NoteAddModel model)
        {
            var note = new Note();
            note.ParentNoteId = model.ParentNoteId;
            note.NoteText = model.NoteText;
            return _noteRepository.CreateNote(note);
        }
        [HttpPut]
        public bool DeleteNote(NoteDeleteModel model)
        {
            return _noteRepository.DeleteNote(model.Id);
        }
        [HttpPut]
        public Note UpdateNote(NoteUpdateModel model)
        {
            var note = new Note();
            note.Id=model.Id;
            note.NoteText = model.NoteText;
            return _noteRepository.UpdateNote(note);
        }
    }
}
