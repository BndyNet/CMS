using System;
using System.IO;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace CMS.Common
{
	public class JsonNetFormatter : MediaTypeFormatter
	{
		private JsonSerializerSettings _settings;
		public JsonNetFormatter(JsonSerializerSettings settings)
		{
			_settings = settings ?? new JsonSerializerSettings();

			_settings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;

			_settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

			SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));
		}
		public override bool CanReadType(Type type)
		{
			return true;
		}

		public override bool CanWriteType(Type type)
		{
			return true;
		}

		public override System.Threading.Tasks.Task<object> ReadFromStreamAsync(Type type, System.IO.Stream readStream, System.Net.Http.HttpContent content, IFormatterLogger formatterLogger)
		{
			var serializer = JsonSerializer.Create(_settings);

			return Task.Factory.StartNew(() =>
			{
				using (var stream = new StreamReader(readStream, System.Text.Encoding.UTF8))
				{
					using (var jsonTextReader = new JsonTextReader(stream))
					{
						return serializer.Deserialize(jsonTextReader);
					}
				}
			});
		}

		public override System.Threading.Tasks.Task WriteToStreamAsync(Type type, object value, System.IO.Stream writeStream, System.Net.Http.HttpContent content, System.Net.TransportContext transportContext)
		{
			var serializer = JsonSerializer.Create(_settings);

			return Task.Factory.StartNew(() =>
			{
				using (var jsonTextWriter = new JsonTextWriter(new StreamWriter(writeStream, System.Text.Encoding.UTF8)))
				{
					serializer.Serialize(jsonTextWriter, value);
					jsonTextWriter.Flush();
				}
			});
		}
	}
}
