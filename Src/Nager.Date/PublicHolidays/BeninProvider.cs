﻿using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Benin
    /// https://en.wikipedia.org/wiki/Public_holidays_in_Benin
    /// </summary>
    public class BeninProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// BeninProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public BeninProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.BJ;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            //TODO: Add islamic public holidays

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 10, "Traditional Day", "Traditional Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 25, "Ascension Day", "Ascension Day", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Easter Sunday", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Easter Monday", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Whit Monday", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(year, 8, 1, "Independence Day", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Assumption Day", "Assumption Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 26, "Armed Forces Day", "Armed Forces Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "All Saints' Day", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 30, "National Day", "National Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
