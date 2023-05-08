namespace PolyclinicChecker.Model;

public class PoliclinicResponse
{
    public int code { get; set; }
    public string message { get; set; }
    public bool success { get; set; }
    public Items[] items { get; set; }
    public int all_count_tickets { get; set; }
}

public class Items
{
    public string lpu_code { get; set; }
    public Uchastok uchastok { get; set; }
    public Lpu lpu { get; set; }
    public Doctors[] doctors { get; set; }
    public string iswaiting { get; set; }
    public int count_tickets_lpu { get; set; }
    public Count_tickets count_tickets { get; set; }
}

public class Uchastok
{
    public string name { get; set; }
    public string code { get; set; }
    public string docPrvd { get; set; }
}

public class Lpu
{
    public string guid { get; set; }
    public string oid { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    public string phone { get; set; }
    public string mcod { get; set; }
    public bool recipe { get; set; }
    public bool wlist { get; set; }
}

public class Doctors
{
    public Schedule[] schedule { get; set; }
    public string separation { get; set; }
    public double rating { get; set; }
    public string photo { get; set; }
    public string uchastokName { get; set; }
    public string id { get; set; }
    public string displayName { get; set; }
    public string person_id { get; set; }
    public string lpu_code { get; set; }
    public int type { get; set; }
    public string type_name { get; set; }
    public string name { get; set; }
    public string family { get; set; }
    public string surname { get; set; }
    public string position { get; set; }
    public string department { get; set; }
    public string room { get; set; }
    public bool isWaitingList { get; set; }
    public bool isSpecial { get; set; }
    public string snils { get; set; }
    public string description { get; set; }
    public int count_tickets { get; set; }
    public Week1[] week1 { get; set; }
    public Week2[] week2 { get; set; }
    public string birthday { get; set; }
}

public class Schedule
{
    public string date { get; set; }
    public string time_from { get; set; }
    public string time_to { get; set; }
    public DocBusyType docBusyType { get; set; }
    public int count_tickets { get; set; }
    public string date_short { get; set; }
    public string day { get; set; }
    public Formatting formatting { get; set; }
}

public class DocBusyType
{
    public string name { get; set; }
    public int type { get; set; }
    public string code { get; set; }
}

public class Formatting
{
    public string day { get; set; }
    public string date { get; set; }
    public string time_from { get; set; }
    public string time_to { get; set; }
    public int count_tickets { get; set; }
}

public class Week1
{
    public string date { get; set; }
    public string time_from { get; set; }
    public string time_to { get; set; }
    public DocBusyType1 docBusyType { get; set; }
    public int count_tickets { get; set; }
    public string date_short { get; set; }
    public string day { get; set; }
    public Formatting1 formatting { get; set; }
}

public class DocBusyType1
{
    public string name { get; set; }
    public int type { get; set; }
    public string code { get; set; }
}

public class Formatting1
{
    public string day { get; set; }
    public string date { get; set; }
    public string time_from { get; set; }
    public string time_to { get; set; }
    public int count_tickets { get; set; }
}

public class Week2
{
    public string date { get; set; }
    public string time_from { get; set; }
    public string time_to { get; set; }
    public DocBusyType2 docBusyType { get; set; }
    public int count_tickets { get; set; }
    public string date_short { get; set; }
    public string day { get; set; }
    public Formatting2 formatting { get; set; }
}

public class DocBusyType2
{
    public string name { get; set; }
    public int type { get; set; }
    public string code { get; set; }
}

public class Formatting2
{
    public string day { get; set; }
    public string date { get; set; }
    public string time_from { get; set; }
    public string time_to { get; set; }
    public int count_tickets { get; set; }
}

public class Count_tickets
{
    public int week1 { get; set; }
    public int week2 { get; set; }
}
