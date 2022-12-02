using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedCaseStudy.Entity.Entities;

namespace UnitedCaseStudy.Data.Abstract
{
    public interface INoteRepository
    {
        List<Note> GetAllNotes();
        Note GetById(int id);
        Note CreateNote(Note note);
        Note UpdateNote(Note note);
        bool DeleteNote(int id);

    }
}
