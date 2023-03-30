namespace WebApplication3_Cookies.DB
{
    public class DBInstance
    {
        private static User503Context instance;
        public static User503Context GetInstance()
        {
            if(instance == null)
                instance = new User503Context();
            return instance;
        }
    }
}
