using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedCaseStudy.Entity.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string NoteText { get; set; }
        public int? ParentNoteId { get; set; }
        public virtual Note? ParentNote { get; set; }
        public bool IsDeleted { get; set; } = false;
       
    }
}
