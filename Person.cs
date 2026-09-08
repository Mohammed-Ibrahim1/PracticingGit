public class clsEmployee
{
    public string Fullname { get; set; } = string.Empty;
    public int Age { get; set; }
    private string _ID ;

    public string ID
    {
        get {return _ID; }
        set {_ID  = value;}
    }
}