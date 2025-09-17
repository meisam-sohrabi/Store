namespace ShopService.ApplicationContract.Interfaces
{
    public interface ICookieService
    {
        void SetCookie(string key, string valus, TimeSpan? expireTime = null);
        string GetCookie(string key);
        bool DeleteCookie(string key);
    }
}
