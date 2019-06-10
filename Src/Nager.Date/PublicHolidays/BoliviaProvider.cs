﻿using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Bolivia
    /// </summary>
    public class BoliviaProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// BoliviaProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public BoliviaProvider(ICatholicProvider catholicProvider)
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
            var countryCode = CountryCode.BO;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Año Nuevo", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 2, 2, "Fiesta de la Virgen de Candelaria", "Feast of the Virgin of Candelaria", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-48), "Feriado por Carnaval", "Carnival", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-47), "Feriado por Carnaval", "Carnival", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Viernes Santo", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(60), "Corpus Christi", "Corpus Christi", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Dia del trabajo", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 6, 21, "Año Nuevo Andino", "Andean New Year", countryCode));
            items.Add(new PublicHoliday(year, 8, 2, "Día de la Revolución Agraria", "Agrarian Reform Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 6, "Dia de la Patria", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 2, "Todos Santos", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Navidad", "Christmas Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        /// <summary>
        /// Get the Holiday Sources
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Bolivia"
            };
        }
    }
}
