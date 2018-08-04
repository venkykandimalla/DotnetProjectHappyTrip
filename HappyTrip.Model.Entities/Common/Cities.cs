using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace HappyTrip.Model.Entities.Common
{
    public class Cities : IEnumerable<City>, IComparer<City>, IEnumerable
    {
        List<City> _cities = new List<City>();

        #region IEnumerable<City> Members

        public IEnumerator<City> GetEnumerator()
        {
            foreach (City city in _cities)
            {
                yield return city;
            }
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (City city in _cities)
            {
                yield return city;
            }
        }

        #endregion

        /// <summary>
        /// Method to add a city
        /// </summary>
        /// <param name="city">City object to be added to the collection</param>
        public void Add(City city)
        {
            _cities.Add(city);
        }

        /// <summary>
        /// Method to remove the city from the collection
        /// </summary>
        /// <param name="city">The city object to be removed from the collection</param>
        public void Remove(City city)
        {
            _cities.Remove(city);
        }

        /// <summary>
        /// The count property
        /// </summary>
        public int Count
        {
            get { return _cities.Count; }
        }

        #region IComparer<City> Members

        public int Compare(City x, City y)
        {
            return x.Name.CompareTo(y.Name);
        }

        #endregion

        /// <summary>
        /// The indexer to retrieve the city object by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public City this[int index]
        {
            get { return _cities[index]; }
            set { _cities[index] = value; }
        }
    }
}
