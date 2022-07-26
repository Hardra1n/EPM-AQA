﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;

namespace QAAutomationLab.BusinessLayer.Utilities
{
    public class CsvDeserializator
    {
        private static string defaultPath = "../../../TestData/";

        public static List<Translations> ReadTranslationsFromCSV(string fileName)
        {
            using (StreamReader streamReader = new StreamReader(defaultPath + fileName))
            {
                using (CsvReader csvReader = new CsvReader(streamReader, System.Globalization.CultureInfo.InvariantCulture))
                {
                    return csvReader.GetRecords<Translations>().ToList();
                }
            }
        }

        public static List<Currencies> ReadCurrenciesFromCSV(string fileName)
        {
            using (StreamReader streamReader = new StreamReader(defaultPath + fileName))
            {
                using (CsvReader csvReader = new CsvReader(streamReader, System.Globalization.CultureInfo.InvariantCulture))
                {
                    return csvReader.GetRecords<Currencies>().ToList();
                }
            }
        }
    }
}