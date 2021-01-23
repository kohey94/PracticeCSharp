using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AspNetCore0003.Persistence.Abstractions;
using AspNetCore0003.Persistence.Model;
using Newtonsoft.Json;

namespace AspNetCore0003.Persistence.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private static IList<Country> _countries;

        public IQueryable<Country> All()
        {
            EnsureCountriesAreLoaded();
            return _countries.AsQueryable();
        }

        public IQueryable<Country> AllBy(string filter)
        {
            return string.IsNullOrEmpty(filter)
                ? All()
                : All().Where(c => c.CountryName.ToLower().StartsWith(filter.ToLower()));
        }

        public Country Find(string code)
        {
            return All().Where(c => c.CurrencyCode.Equals(code, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        }

        #region PRIVATE
        /// <summary>
        /// Countryの読み込み確認
        /// </summary>
        private static void EnsureCountriesAreLoaded()
        {
            if (_countries == null)
                _countries = LoadCountriesFromStream();

        }

        /// <summary>
        /// jsonを読み込む
        /// </summary>
        /// <returns>国リスト</returns>
        private static IList<Country> LoadCountriesFromStream()
        {
            var json = File.ReadAllText("Countries.json");
            var countries = JsonConvert.DeserializeObject<Country[]>(json);
            return countries.OrderBy(c => c.CountryName).ToList();
        }
        #endregion
    }
}
