namespace ClaimSystem.Importer.Converters.Base
{
    #region

    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;
    using ClaimSystem.Core.Models;

    #endregion

    /// <summary>
    /// Our base class for xml conversions
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="TSource"></typeparam>
    public abstract class XmlConverterBase<TModel, TSource> : IConverter<TModel>
    {
        protected List<TModel> ConvertionResults;
       
        public IEnumerable<TModel> Process(string feedPath)
        {
            var source = GetSourceObject(feedPath);
            var models = MapSourceToModel(source);
            return models;
        }

        /// <summary>
        /// This will need to be implemented for each customer. 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected abstract IEnumerable<TModel> MapSourceToModel(TSource source);

        protected TSource GetSourceObject(string feedPath)
        {
            if (!File.Exists(feedPath))
                throw new FileNotFoundException();

            var serializer = new XmlSerializer(typeof (TSource));
            using (var reader = new StreamReader(feedPath))
            {
                try
                {
                    var sourceObject = (TSource) serializer.Deserialize(reader);
                    return sourceObject;
                }
                catch
                {
                    throw new SerializationException("Could not deserialize.");
                }
            }
        }
    }
}