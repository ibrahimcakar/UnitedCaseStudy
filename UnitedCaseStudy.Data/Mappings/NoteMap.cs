using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedCaseStudy.Entity.Entities;

namespace UnitedCaseStudy.Data.Mappings
{
    public class NoteMap : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasData(new Note
            {
                NoteText="Parent 1 Note",
                ParentNoteId=null,
                IsDeleted=false,
            },
            new Note
            {
                NoteText = "Child 1 Note(Parent:Parent 1)",
                ParentNoteId = 1,
                IsDeleted = false,
            },
            new Note
            {
                NoteText = "Child 2 Note(Parent:Child 1)",
                ParentNoteId = 2,
                IsDeleted = false,
            },
            new Note
            {
                NoteText = "Child 3 Note(Parent:Child 2)",
                ParentNoteId = 3,
                IsDeleted = false,
            },
            new Note
            {
                NoteText = "Child 4 Note(Parent:Parent 1)",
                ParentNoteId = 1,
                IsDeleted = false,
            },
            new Note
            {
                NoteText = "Parent 2 Note",
                ParentNoteId = null,
                IsDeleted = false,
            },
            new Note
            {
                NoteText = "Child 5 Note(Parent:Parent 2)",
                ParentNoteId = 6,
                IsDeleted = false,
            },
            new Note
            {
                NoteText = "Child 6 Note(Parent:Parent 1)",
                ParentNoteId = 6,
                IsDeleted = false,
            }
            );
        }
    }
}
