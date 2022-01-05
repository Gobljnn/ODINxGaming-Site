namespace OdinXSiteMVC2.Models {
    public class CheckEmail {

        string Email { get; set; }

        public bool IsChecked(string emailOld, string emailNew) {
            if (emailOld.Equals(emailNew)) {
                return true;

            }

            return false;

        }
    }
}
