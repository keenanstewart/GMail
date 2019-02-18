using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WordAPI.Models
{
	public class WordDefinition
	{
		public int Id { get; set; }
		public int WordsmithThemeId { get; set; }
		public string DailyWord { get; set; }
		public string WordThemeName { get; set; }
		public string Pronunciation { get; set; }
		public string Meaning { get; set; }
		public string Etymology { get; set; }
		public string Usage { get; set; }
		public string ThoughtADay { get; set; }
		public string Notes { get; set; }
		public DateTime InputDate { get; set; }
		public DateTime UpdateDate { get; set; }

		public override string ToString()
		{
			return Id + ":" +
				DailyWord + ":" +
				WordsmithThemeId + ":" +
				WordThemeName + ":" +
				Pronunciation + ":" +
				Meaning + ":" +
				Etymology + ":" +
				Usage + ":" +
				ThoughtADay + ":" +
				Notes;
		}
	}
}