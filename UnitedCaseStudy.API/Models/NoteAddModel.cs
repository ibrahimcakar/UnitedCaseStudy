using UnitedCaseStudy.Entity.Entities;

namespace UnitedCaseStudy.API.Models
{
    public class NoteAddModel
    {
        public string NoteText { get; set; }
        /// <summary>
        /// Boş bırakılırsa en üst seviye not demektir.
        /// </summary>
        public int? ParentNoteId { get; set; }
    }
}
