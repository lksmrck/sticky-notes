using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Note;
using FluentValidation;
using static System.Net.Mime.MediaTypeNames;

namespace Notes.Validation.Validation
{
    public class NoteValidator : AbstractValidator<Note>
    {

        public NoteValidator()
        {
            int maxTagLength = 12;
            int minTagLength = 3;


            int maxHeadingLength = 10;
            int minHeadingLength = 5;


            int maxTextLength = 300;
            int minTextLength = 5;

            RuleFor(x => x.Heading).NotEmpty().MaximumLength(maxHeadingLength).WithMessage($"Maximum length of heading is {maxHeadingLength} characters.").MinimumLength(minHeadingLength).WithMessage($"Minimal length of heading is {minHeadingLength} characters.");
            RuleFor(x => x.Text).NotEmpty().MaximumLength(maxTextLength).WithMessage($"Maximum length of text is {maxTextLength} characters.").MinimumLength(minTextLength).WithMessage($"Minimal length of text is {minTextLength} characters.");
            RuleFor(x => x.AuthorId).NotEmpty();
            RuleFor(x => x.Author).NotEmpty();
            //RuleFor(x => x.Tags).NotEmpty();

            When(x => x.Tags.Any(), () =>
            {
                RuleForEach(x => x.Tags).MaximumLength(maxTagLength).WithMessage($"Maximum length of tag is {maxTagLength} characters.").MinimumLength(minTagLength).WithMessage($"Minimal length of tag is {minTagLength} characters.");

            });

        }
    }
}
