﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Esoft
{
    public partial class Clients
    {
        public Clients()
        {
            Needs = new HashSet<Needs>();
            Sentence = new HashSet<Sentence>();
        }

        public int Id { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool? ClientState { get; set; }
        public string ClientInfo { get; set; }

        public virtual ICollection<Needs> Needs { get; set; }
        public virtual ICollection<Sentence> Sentence { get; set; }
    }
}
