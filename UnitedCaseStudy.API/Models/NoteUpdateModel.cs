namespace UnitedCaseStudy.API.Models
{
    public class NoteUpdateModel
    {
        public int Id { get; set; }

        public string NoteText { get; set; }
        /// <summary>
        /// Boş bırakılırsa en üst seviye not demektir.
        /// </summary>


    }
}
