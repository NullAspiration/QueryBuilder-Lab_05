namespace QueryBuilder
{
    public class Users : IComparable
    {
        public int Id { get; init; }
        public string UserName { get; init; }
        public string UserAddress { get; init; }
        public string OtherUserDetails { get; init; }
        public string AmountOfFine { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }

        public Users() { }
        public Users(int id, string userName, string userAddress, string otherUserDetails, string amountOfFine,string email, string phoneNumber)
        {
            Id = id;
            UserName = userName;
            UserAddress = userAddress;
            OtherUserDetails = otherUserDetails;
            AmountOfFine = amountOfFine;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        public override string ToString()
        {
            return
                $"Id:\t\t\t{Id}\n" +
                $"UserName:\t\t{UserName}\n" +
                $"UserAddress:\t\t{UserAddress}\n" +
                $"OtherUserDetails:\t{OtherUserDetails}\n" +
                $"AmmountOfFine:\t\t{AmountOfFine}\n" +
                $"Email:\t\t\t{Email}\n"+
                $"PhoneNumber:\t\t{PhoneNumber}";
        }
        public int CompareTo(object? obj)
        {
            Users compareUsers = (Users)obj;
            if (compareUsers.Id > this.Id)
                return -1;
            else if (compareUsers.Id == this.Id)
                return 0;
            else
                return 1;
        }
    }
}
