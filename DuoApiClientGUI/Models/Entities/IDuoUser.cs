namespace DuoApiClientGUI.Models.Entities
{
    internal interface IDuoUser
    {
        string Alias1 { get; set; }
        string Alias2 { get; set; }
        string Alias3 { get; set; }
        string Alias4 { get; set; }
        string Created { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        bool IsEnrolled { get; set; }
        string LastDirectorySync { get; set; }
        string LastLogin { get; set; }
        string LastName { get; set; }
        string Notes { get; set; }
        string RealName { get; set; }
        string UserId { get; set; }
        string UserName { get; set; }
    }
}