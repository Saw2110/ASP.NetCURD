namespace PracticeAPI.Model
{
    public class UserDetailModel
    {
        public int Id { get; set; } 
        public int UserID { get; set; } 
        public string UserName { get; set; } 
        public string UserAddress { get; set; } 
        public string UserEmail { get; set; } 
        public string UserContact { get; set; } 
    }

    public class AddUserDetailModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string UserEmail { get; set; }
        public string UserContact { get; set; }
    }

    public class UpdateUserDetailModel
    {
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string UserEmail { get; set; }
        public string UserContact { get; set; }
    }
}
