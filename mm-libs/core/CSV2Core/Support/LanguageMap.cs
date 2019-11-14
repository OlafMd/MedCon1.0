using System;
using System.Collections.Generic;
using System.Linq;

namespace CSV2Core.Support
{
    public class LanguageMap
    {
        private static LanguageMap _instance = new LanguageMap();

        private Dictionary<Guid, Language> _languageMap = new Dictionary<Guid, Language>();

        private LanguageMap()
        {


            Language english = new Language()
            {
                ISO_639_1 = "en",
                ISO_639_2 = "eng",
                LanguageID = Guid.Parse("2409e338-63ba-479f-8fbe-499aca231630")
            };

            Language german = new Language()
            {
                ISO_639_1 = "de",
                ISO_639_2 = "deu",
                LanguageID = Guid.Parse("6bdbf56e-06c8-4f57-b1ed-041adf2af180")
            };

            Language serbian = new Language()
            {
                ISO_639_1 = "sr",
                ISO_639_2 = "srb",
                LanguageID = Guid.Parse("b5599a44-6e48-42e3-9b4a-85304fb77d4f")
            };

            _languageMap.Add(english.LanguageID, english);
            _languageMap.Add(german.LanguageID, german);
            _languageMap.Add(serbian.LanguageID, serbian);

        }

        public static Language GetLanguageFor(string iso)
        {
            return _instance._languageMap.Values.FirstOrDefault(language => language.ISO_639_1 == iso.ToLower() || language.ISO_639_2 == iso.ToLower());
        }

        public static Language GetLanguageFor(Guid languageId)
        {
            return _instance._languageMap[languageId];
        }

        public static Language[] Languages
        {
            get
            {
                return _instance._languageMap.Values.ToArray();
            }
        }
    }

    public class Language
    {
        public Guid LanguageID { get; set; }
        public string ISO_639_2 { get; set; }
        public string ISO_639_1 { get; set; }
    }
}
