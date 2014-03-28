namespace ClaimSystem.Data.DbInteractions
{
    #region

    using System;

    #endregion

    /// <summary>
    /// Although it doesn't look like it does much, this is useful when dealing with more than one context type.
    /// </summary>
    public interface IDbFactory : IDisposable
    {
        DataContext GetDataContext();
    }


    // This is what what I use at work
    /*
    
    public interface IDbFactory : IDisposable
    {
        DataContext GetDataContext();
        PrismContext GetPrismContext();
    }
    
    */
}