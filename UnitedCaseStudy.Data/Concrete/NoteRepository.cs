using UnitedCaseStudy.Data.Abstract;
using UnitedCaseStudy.Data.Context;
using UnitedCaseStudy.Entity.Entities;

namespace UnitedCaseStudy.Data.Concrete
{
    public class NoteRepository : INoteRepository
    {
        private AppDbContext _context;

        public NoteRepository(AppDbContext DbContext)
        {
            _context = DbContext;
        }
        public Note CreateNote(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
            return note;
        }

        public List<Note> GetAllNotes()
        {
            return _context.Notes.ToList();
        }

        public Note GetById(int id)
        {
            return _context.Notes.Find(id);
        }

        public Note UpdateNote(Note note)
        {
            var temp = _context.Notes.Find(note.Id);
            temp.NoteText = note.NoteText;
            _context.Notes.Update(temp);
            _context.SaveChanges();
            return temp;
        }
        public bool DeleteNote(int id)
        {
            var note = _context.Notes.Find(id);
            note.IsDeleted= true;
            return _context.SaveChanges()>0?true:false;
        }
    }
}
