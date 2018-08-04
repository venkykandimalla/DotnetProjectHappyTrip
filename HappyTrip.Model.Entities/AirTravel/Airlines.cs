using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace HappyTrip.Model.Entities.AirTravel
{
    public class Airlines : IEnumerable<Airline>, IComparer<Airline>, IEnumerable
    {
        List<Airline> _airlines = new List<Airline>();

        #region IEnumerable<Airline> Members

        public IEnumerator<Airline> GetEnumerator()
        {
            foreach (Airline airline in _airlines)
            {
                yield return airline;
            }
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (Airline airline in _airlines)
            {
                yield return airline;
            }
        }

        #endregion

        /// <summary>
        /// Method to add an airlne
        /// </summary>
        /// <param name="airline">Airline object to be added to the collection</param>
        public void Add(Airline airline)
        {
            _airlines.Add(airline);
        }

        /// <summary>
        /// Method to remove the airline from the collection
        /// </summary>
        /// <param name="airline">The airline object to be removed from the collection</param>
        public void Remove(Airline airline)
        {
            _airlines.Remove(airline);
        }

        /// <summary>
        /// The count property
        /// </summary>
        public int Count
        {
            get { return _airlines.Count; }
        }

        #region IComparer<Airline> Members

        public int Compare(Airline x, Airline y)
        {
            return x.Name.CompareTo(y.Name);
        }

        #endregion

        /// <summary>
        /// The indexer to retrieve the airline object by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Airline this[int index]
        {
            get { return _airlines[index]; }
            set { _airlines[index] = value; }
        }
    }
}
