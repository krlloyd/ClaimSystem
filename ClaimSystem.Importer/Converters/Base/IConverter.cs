namespace ClaimSystem.Importer.Converters.Base
{
    #region

    using System.Collections.Generic;

    #endregion

    public interface IConverter<out TDomainObject>
    {
        IEnumerable<TDomainObject> Process(string feedPath);
    }
}