using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.AirTravel
{
	public class Routes : IEnumerable<Route>, IComparer<Route>, IEnumerable
	{
		List<Route> _routes = new List<Route>();

		#region IEnumerable<Route> Members

		public IEnumerator<Route> GetEnumerator()
		{
			foreach (Route route in _routes)
			{
				yield return route;
			}
		}

		#endregion

		#region IEnumerable Members

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			foreach (Route route in _routes)
			{
				yield return route;
			}
		}

		#endregion

		/// <summary>
		/// Method to add the route
		/// </summary>
		/// <param name="route">Route object to be added to the collection</param>
		public void Add(Route route)
		{
			_routes.Add(route);
		}

		/// <summary>
		/// Method to remove the route from the collection
		/// </summary>
		/// <param name="route">The route object to be removed from the collection</param>
		public void Remove(Route route)
		{
			_routes.Remove(route);
		}

		/// <summary>
		/// The count property
		/// </summary>
		public int Count 
		{
			get { return _routes.Count; }
		}

		#region IComparer<Route> Members

		public int Compare(Route x, Route y)
		{
			return (int)(x.DistanceInKms - y.DistanceInKms);
		}

		#endregion

		/// <summary>
		/// The indexer to retrieve the route object by index
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public Route this[int index]
		{
			get { return _routes[index]; }
			set { _routes[index] = value; }
		}
	}
}
