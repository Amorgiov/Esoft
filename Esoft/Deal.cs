using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Esoft
{
    public partial class Deal
    {
        public int Id { get; set; }
        public int NeedsId { get; set; }
        public int SentenceId { get; set; }

        public virtual Needs Needs { get; set; }
        public virtual Sentence Sentence { get; set; }
    }
}
