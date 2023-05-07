namespace _0_Framework.Infrastucture
{
    public static class Roles
    {
        public const string Administrator = "1";
        public const string SystemUser = "2";
        public const string ContentUploader = "10002";

        public static string GetRoleBy(long id)
        {
            switch (id)
            {
                case 1:
                    return "مدیرسیستم";
                case 10002:
                    return "محتوا گذار";
                default:
                    return "";
            }
        }
    }
}
