using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionJuridica.Utilities
{
	public class Rpta
	{
        public int status { get; set; }
        public bool error { get; set; }
        public string message { get; set; }
        public string answer { get; set; }
        public bool result { get; set; }
        public MenuDto obj { get; set; }
    }
}