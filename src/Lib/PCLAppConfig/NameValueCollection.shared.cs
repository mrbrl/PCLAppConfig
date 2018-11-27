using System.Collections.Generic;
using System.Linq;

namespace PCLAppConfig
{
	public interface INameValueElement<T>
	{
		string Key { get; set; }
		T Value { get; set; }
	}

	public class NameValueCollection<TMapped> where TMapped : INameValueElement<string>
	{
		public NameValueCollection()
		{ }

		public NameValueCollection(IEnumerable<TMapped> datas)
		{
			this.datas = datas;
		}

		//
		// Summary:
		//     Gets the entry with the specified key in the PCLAppConfig.NameValueCollection.
		//
		// Parameters:
		//   name:
		//     The System.String key of the entry to locate. The key can be null.
		//
		// Returns:
		//     A System.String that contains the comma-separated list of values associated with
		//     the specified key, if found; otherwise, null.
		public string this[string name]
		{
			get
			{
				IEnumerable<string> values = datas.Where(x => x.Key == name).Select(x => x.Value);
				return values == null ? null : string.Join(",", values);
			}
		}

		//
		// Summary:
		//     Gets the values associated with the specified key from the PCLAppConfig.NameValueCollection
		//     combined into one comma-separated list.
		//
		// Parameters:
		//   name:
		//     The System.String key of the entry that contains the values to get. The key can
		//     be null.
		//
		// Returns:
		//     A System.String that contains a comma-separated list of the values associated
		//     with the specified key from the PCLAppConfig.NameValueCollection,
		//     if found; otherwise, null
		public string Get(string name)
		{
			return this[name];
		}

		//
		// Summary:
		//     Gets the values associated with the specified key from the PCLAppConfig.NameValueCollection.
		//
		// Parameters:
		//   name:
		//     The System.String key of the entry that contains the values to get. The key can
		//     be null.
		//
		// Returns:
		//     A System.String array that contains the values associated with the specified
		//     key from the PCLAppConfig.NameValueCollection, if found; otherwise,
		//     null.
		public string[] GetValues(string name)
		{
			return datas.Where(x => x.Key == name).Select(x => x.Value)?.ToArray();
		}

		private IEnumerable<TMapped> datas;
	}
}
